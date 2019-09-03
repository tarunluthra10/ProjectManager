import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddProjectComponent } from './add-project/add-project.component';
import { AddTaskComponent } from './add-task/add-task.component';
import { AddUserComponent } from './add-user/add-user.component';
import { ViewTaskComponent } from './view-task/view-task.component';


const routes: Routes = [
  {path: 'addproject', component: AddProjectComponent},
  {path: 'addtask', component: AddTaskComponent},
  {path: 'adduser', component: AddUserComponent},
  {path: 'viewtask', component: ViewTaskComponent},
  { path: '', redirectTo: 'addproject', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

}
