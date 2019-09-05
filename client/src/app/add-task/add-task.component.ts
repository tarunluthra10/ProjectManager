import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Task } from '../models/task.model';
import { Project } from '../models/project.model';
import { User } from '../models/user.model';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {

  public objTaskToPost: Task = new Task;
  public isAdd: boolean = true;
  public listOfParentTasks: Array<Task> = new Array<Task>();
  public listOfProjects: Array<Project> = new Array<Project>();
  public listOfUsers: Array<User> =  new Array<User>();
  public searchProjectName:string= '';
  public searchParentTaskName:string= '';
  public searchUserName:string= '';
  @ViewChild('searchProjectModal', { static: false }) searchProjectModal: TemplateRef<any>;
  @ViewChild('searchParentTaskModal', { static: false }) searchParentTaskModal: TemplateRef<any>;
  @ViewChild('searchUserModal', { static: false }) searchUserModal: TemplateRef<any>;

  constructor(private modalService: NgbModal,private refApiService: ApiService) { }

  ngOnInit() {
    this.GetAllProject();
    this.GetAllUserData();
    this.GetAllParentTasks();
  }

  private ValidateTask(objTask: Task): Boolean {
    let isValid = false;
    isValid = objTask.TaskName.trim() !== '' && objTask.Priority.toString().trim() !== '' && objTask.ProjectName.toString().trim() !== '';
    return isValid;

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

  GetAllUserData() {
    this.listOfUsers = new Array<User>();
    this.refApiService.GetAllUsers().subscribe(res => {
      for (let oneUser of res) {
        var objUserItem = new User();
        objUserItem.UserId = oneUser.UserId;
        objUserItem.EmployeeId = oneUser.EmployeeId;
        objUserItem.FirstName = oneUser.FirstName;
        objUserItem.LastName = oneUser.LastName;
        this.listOfUsers.push(objUserItem);
      }
    });
  }

  GetAllParentTasks() {
    this.listOfParentTasks = new Array<Task>();
    this.refApiService.GetAllUsers().subscribe(res => {
      for (let oneTask of res) {
        var objTask = new Task();
        objTask.ParentTaskId = oneTask.ParentTaskId;
        objTask.ParentTaskName = oneTask.ParentTaskName;
        objTask.TaskId = oneTask.TaskId;
        objTask.TaskName = oneTask.TaskName;
        this.listOfParentTasks.push(oneTask);
      }
    });
  }


  AddTask(objTask: Task): void {
    if (this.ValidateTask(objTask)) {
      this.refApiService.AddNewTask(objTask).subscribe(res => { if(res) {this.ResetTask();} });
    }
  }

  UpdateTask(objTask: Task): void {
    if (this.ValidateTask(objTask)) {
      this.refApiService.UpdateTask(objTask).subscribe(res => { if(res) {this.ResetTask();} });
    }
    this.isAdd = true;
  }

  ResetTask(): void {
    this.objTaskToPost = new Task();
    this.isAdd = true;
  }

  SearchProject() {
    const modalRef = this.modalService.open(this.searchProjectModal);
  }

  SelectedProjectClick(item: Project) {
    this.objTaskToPost.ProjectId = item.ProjectId;
    this.objTaskToPost.ProjectName = item.ProjectName;
  }

  SearchParentTask() {
    const modalRef = this.modalService.open(this.searchParentTaskModal);
  }

  SelectedParentTaskClick(item: Task) {
    this.objTaskToPost.ParentTaskId = item.TaskId;
    this.objTaskToPost.ParentTaskName = item.TaskName;
  }

  SearchUser() {
    const modalRef = this.modalService.open(this.searchUserModal);
  }

  SelectedUserClick(item: User) {
    this.objTaskToPost.ManagerId = item.UserId;
    this.objTaskToPost.ManagerName = item.FirstName + item.LastName;
  }

}
