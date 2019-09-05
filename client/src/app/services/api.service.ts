import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { WebApiConstants, ApiMockUrl } from '../web-api-constants';
import { environment } from '../../environments/environment';
import { User } from '../models/user.model';
import { Project } from '../models/project.model';
import { Task } from '../models/task.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private endpoint = environment.baseApiUrl;
  private isMock = environment.isMock;
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }


  GetFromApi(url: string, params: any): Observable<any> {

    //return this.http.get(this.endpoint + 'ProjectManager/Get').pipe(map(this.extractData));
    return this.http.get(this.endpoint + WebApiConstants.GetAllProjects.api);
  }

  PostToApi(url: string, params: any): Observable<any> {
    return this.http.post<any>(this.endpoint + url, JSON.stringify(params), this.httpOptions);
  }

  private GetURLToCall(objApiMockUrl: ApiMockUrl): string {
    return this.isMock ? objApiMockUrl.mock : objApiMockUrl.api;
  }



  GetAllUsers(): Observable<any> {
    return this.http.get(this.endpoint + this.GetURLToCall(WebApiConstants.GetAllUsers));
  }

  AddNewUser(objUser: User): Observable<any> {
    return this.http.post<any>(this.endpoint + this.GetURLToCall(WebApiConstants.AddNewUser), JSON.stringify(objUser), this.httpOptions);
  }

  UpdateUser(objUser: User): Observable<any> {
    return this.http.post<any>(this.endpoint + this.GetURLToCall(WebApiConstants.UpdateUser), JSON.stringify(objUser), this.httpOptions);
  }

  RemoveUser(objUser: User): Observable<any> {
    return this.http.post<any>(this.endpoint + this.GetURLToCall(WebApiConstants.RemoveUser), JSON.stringify(objUser), this.httpOptions);
  }

  GetAllProjects(): Observable<any> {
    return this.http.get(this.endpoint + this.GetURLToCall(WebApiConstants.GetAllProjects));
  }

  AddNewProject(objUser: Project): Observable<any> {
    return this.http.post<any>(this.endpoint + this.GetURLToCall(WebApiConstants.AddNewProject), JSON.stringify(objUser), this.httpOptions);
  }

  UpdateProject(objUser: Project): Observable<any> {
    return this.http.post<any>(this.endpoint + this.GetURLToCall(WebApiConstants.UpdateProject), JSON.stringify(objUser), this.httpOptions);
  }

  RemoveProject(objUser: Project): Observable<any> {
    return this.http.post<any>(this.endpoint + this.GetURLToCall(WebApiConstants.RemoveProject), JSON.stringify(objUser), this.httpOptions);
  }

  GetAllTasks(): Observable<any> {
    return this.http.get(this.endpoint + this.GetURLToCall(WebApiConstants.GetAllTasks));
  }

  GetAllPriorityTasks(): Observable<any> {
    return this.http.get(this.endpoint + this.GetURLToCall(WebApiConstants.GetAllPriorityTasks));
  }

  AddNewTask(objUser: Task): Observable<any> {
    return this.http.post<any>(this.endpoint + this.GetURLToCall(WebApiConstants.AddNewTask), JSON.stringify(objUser), this.httpOptions);
  }

  UpdateTask(objUser: Task): Observable<any> {
    return this.http.post<any>(this.endpoint + this.GetURLToCall(WebApiConstants.UpdateTask), JSON.stringify(objUser), this.httpOptions);
  }

  RemoveTask(objUser: Task): Observable<any> {
    return this.http.post<any>(this.endpoint + this.GetURLToCall(WebApiConstants.RemoveTask), JSON.stringify(objUser), this.httpOptions);
  }

  GetAllTaskForProject(projectId: number) : Observable<any> {
    let headers = new HttpHeaders();
        headers  = headers.append('Content-Type', 'application/json');
    let params = new HttpParams();
       params = params.append('projectId', projectId.toString());
    return this.http.get(this.endpoint + this.GetURLToCall(WebApiConstants.GetAlltaskForProject), {headers, params});
  }

  private extractData(res: Response) {
    let body = res;
    return body || {};
  }

  private handleError<T>(operation = 'operation', result?: T) {
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
