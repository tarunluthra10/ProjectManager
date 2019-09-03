import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { WebApiConstants,ApiMockUrl } from '../web-api-constants';
import { environment } from '../../environments/environment';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private endpoint = environment.baseApiUrl;
  private isMock = environment.isMock;
 private httpOptions = {
   headers: new HttpHeaders({
     'Content-Type':  'application/json'
   })
 };

constructor(private http: HttpClient) { } 
 

  GetFromApi(url:string, params:any): Observable<any> {

    //return this.http.get(this.endpoint + 'ProjectManager/Get').pipe(map(this.extractData));
    return this.http.get(this.endpoint + WebApiConstants.GetAllProjects.api);
  }

  PostToApi(url:string, params:any): Observable<any> {
    return this.http.post<any>(this.endpoint + url, JSON.stringify(params), this.httpOptions);
  }

  GetAllUsers() : Observable<any> {
    return this.http.get(this.endpoint + this.GetURLToCall(WebApiConstants.GetAllUsers));
  }

  AddNewUser(objUser: User) : Observable<any>
  {
    return this.http.post<any>(this.endpoint + this.GetURLToCall(WebApiConstants.AddNewUser), JSON.stringify(objUser), this.httpOptions);
  }

  private GetURLToCall(objApiMockUrl: ApiMockUrl): string{
    return this.isMock ? objApiMockUrl.mock : objApiMockUrl.api;
  }
  
  // addProduct (product): Observable<any> {
  //   console.log(product);
  //   return this.http.post<any>(this.endpoint + 'products', JSON.stringify(product), this.httpOptions).pipe(
  //     tap((product) => console.log(`added product w/ id=${product.id}`)),
  //     catchError(this.handleError<any>('addProduct'))
  //   );
  // }
  
  // updateProduct (id, product): Observable<any> {
  //   return this.http.put(this.endpoint + 'products/' + id, JSON.stringify(product), this.httpOptions).pipe(
  //     tap(_ => console.log(`updated product id=${id}`)),
  //     catchError(this.handleError<any>('updateProduct'))
  //   );
  // }
  
  // deleteProduct (id): Observable<any> {
  //   return this.http.delete<any>(this.endpoint + 'products/' + id, this.httpOptions).pipe(
  //     tap(_ => console.log(`deleted product id=${id}`)),
  //     catchError(this.handleError<any>('deleteProduct'))
  //   );
  // }

  private extractData(res: Response) {
    let body = res;
    return body || { };
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
