import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Task } from '../models/task.model';
import { Project } from '../models/project.model';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrls: ['./view-task.component.css']
})
export class ViewTaskComponent implements OnInit {

  public objTaskToPost: Task = new Task;
  public sortByColumn: string = '';
  public listOfTasks: Array<Task> = new Array<Task>();
  public listOfProjects: Array<Project> = new Array<Project>();
  private selectedProjectId: number;
  public searchProjectName:string= '';
  public searchText:string= '';
  @ViewChild('searchProjectModal', { static: false }) searchProjectModal: TemplateRef<any>;

  constructor(private modalService: NgbModal, private refApiService: ApiService) { }

  ngOnInit() {
    this.GetAllProject();
  }

  GetAllProject() {
    this.listOfProjects = new Array<Project>();
    this.refApiService.GetAllProjects().subscribe(res => {
      for (let oneProject of res) {
        let abc = new Project();
        abc.ProjectId = oneProject.ProjectId;
        abc.ProjectName = oneProject.ProjectName;
        abc.Priority = oneProject.Priority;
        abc.Completed = oneProject.Completed;
        abc.StartDate = oneProject.StartDate;
        abc.EndDate = oneProject.EndDate;
        abc.NumberOfTasks = oneProject.NumberOfTasks;
        this.listOfProjects.push(abc);
      }
    });
  }

  GetAllTaskForProject(objProjectId: number) {
    this.listOfTasks = new Array<Task>();
    this.selectedProjectId = objProjectId;
    this.refApiService.GetAllTaskForProject(objProjectId).subscribe(res => {
      for (let oneTask of res) {
        var abc = new Task();
        abc.ProjectId = oneTask.ProjectId;
        abc.ProjectName = oneTask.ProjectName;
        abc.Priority = oneTask.Priority;
        abc.Completed = oneTask.Completed;
        abc.StartDate = oneTask.StartDate;
        abc.EndDate = oneTask.EndDate;
        abc.TaskId = oneTask.TaskId;
        abc.TaskName = oneTask.TaskName;
        abc.ParentTaskId = oneTask.ParentTaskId;
        abc.ParentTaskName = oneTask.ParentTaskName;
        this.listOfTasks.push(abc);
      }
    });

  }

  EditTask(objTask: Task): void {
    this.objTaskToPost = objTask;
  }

  DeleteTask(objTask: Task): void {
    this.refApiService.UpdateTask(objTask).subscribe(res => 
      { 
        if(res) {
          this.GetAllTaskForProject(this.selectedProjectId);
        } 
      });
  }

  SearchProject() {
    const modalRef = this.modalService.open(this.searchProjectModal);
  }

  SelectedProjectClick(item: Project) {
    this.objTaskToPost.ProjectId = item.ProjectId;
    this.objTaskToPost.ProjectName = item.ProjectName;
    this.GetAllTaskForProject(item.ProjectId);
    
  }

}
