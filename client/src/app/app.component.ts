import { Component } from '@angular/core';
import {ApiService} from './services/api.service';
import { ActivatedRoute, Router, NavigationEnd  } from '@angular/router';
import {filter} from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'project-manager';
  public selectedRoute:string = '';

constructor( private router: Router,
  private route: ActivatedRoute,refApiService: ApiService) {
    this.router.events.pipe(
      filter((event: any) => event instanceof NavigationEnd))
      .subscribe(event => {
        this.selectedRoute = event.url != '/' ? event.url : '/addproject';
      });
}


}
