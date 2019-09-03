import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Task } from '../models/task.model';
import { Project } from '../models/project.model';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrls: ['./view-task.component.css']
})
export class ViewTaskComponent implements OnInit {

  public objTaskToPost:Task = new Task;
  public sortByColumn: string = '';
  public listOfTasks: Array<Task>;
  public listOfProjects: Array<Project>;
  @ViewChild('searchProjectModal', { static: false }) searchProjectModal: TemplateRef<any>;

  constructor(private modalService: NgbModal) { }

  ngOnInit() {
    this.listOfTasks = new Array<Task>();
    for(var i=1; i <= 10; i++)
    {
      var abc = new Task();
      abc.ProjectId = i;
      abc.ProjectName = "Project"+i;
      abc.Priority = 10;
      abc.Completed = "2";
      abc.StartDate = new Date(2019, 9, 1);
      abc.EndDate = new Date(2019, 9, 1);
      abc.TaskId = i;
      abc.TaskName = "Task Name"+i;
      abc.ParentTaskId = i*i + 10;
      abc.ParentTaskName = "Parent Task "+i;
      this.listOfTasks.push(abc);

    }

    this.listOfProjects = new Array<Project>();

    for(var i=1; i <= 10; i++)
    {
      var objProject = new Project();
      objProject.ProjectId = i;
      objProject.ProjectName = "Project Name"+i;
      this.listOfProjects.push(objProject);
    }
  }


  EditProject(objTask:Task) : void
  {
    this.objTaskToPost = objTask;
  }

  DeleteProject(objUser:Task) : void
  {
    // call service to delete user

    // Load all users
  }

  SearchProject() {
    const modalRef = this.modalService.open(this.searchProjectModal);
    console.log(modalRef);
  }

  SelectedProjectClick(item: Project) {
    this.objTaskToPost.ProjectId = item.ProjectId;
    this.objTaskToPost.ProjectName = item.ProjectName;

    // Call service to refresh data
  }

}
