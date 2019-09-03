import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Task } from '../models/task.model';
import { Project } from '../models/project.model';
import { User } from '../models/user.model';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {

  public objTaskToPost: Task = new Task;
  public isAdd: boolean = true;
  public listOfParentTasks: Array<Task>;
  public listOfProjects: Array<Project>;
  public listOfUsers: Array<User>;
  @ViewChild('searchProjectModal', { static: false }) searchProjectModal: TemplateRef<any>;
  @ViewChild('searchParentTaskModal', { static: false }) searchParentTaskModal: TemplateRef<any>;
  @ViewChild('searchUserModal', { static: false }) searchUserModal: TemplateRef<any>;

  constructor(private modalService: NgbModal) { }

  ngOnInit() {

    this.listOfParentTasks = new Array<Task>();
    this.listOfProjects = new Array<Project>();
    this.listOfUsers = new Array<User>();

    for(let i=0; i<=10; i++)
    {
      let objTask = new Task();
      let objUser = new User();
      let objProject = new Project();

      objTask.TaskId = i;
      objTask.TaskName = "Task Name"+i;
      objUser.UserId = i;
      objUser.FirstName = "First Name"+i;
      objUser.LastName = "Last Name"+i;
      objProject.ProjectId = i;
      objProject.ProjectName = "Project"+i;

      this.listOfParentTasks.push(objTask);
      this.listOfProjects.push(objProject);
      this.listOfUsers.push(objUser);

    }
  }


  AddProject(objTask: Task): void {
    console.log(objTask);
  }

  UpdateProject(objTask: Task): void {
    console.log(objTask);
    this.isAdd = true;
  }

  ResetProject(objTask: Task): void {
    this.objTaskToPost = new Task();
    this.isAdd = true;
  }

  SearchProject() {
    const modalRef = this.modalService.open(this.searchProjectModal);
    console.log(modalRef);
  }

  SelectedProjectClick(item: Project) {
    this.objTaskToPost.ProjectId = item.ProjectId;
    this.objTaskToPost.ProjectName = item.ProjectName;
  }

  SearchParentTask() {
    const modalRef = this.modalService.open(this.searchParentTaskModal);
    console.log(modalRef);
  }

  SelectedParentTaskClick(item: Task) {
    this.objTaskToPost.ParentTaskId = item.TaskId;
    this.objTaskToPost.ParentTaskName = item.TaskName;
  }

  SearchUser() {
    const modalRef = this.modalService.open(this.searchUserModal);
    console.log(modalRef);
  }

  SelectedUserClick(item: User) {
    this.objTaskToPost.ManagerId = item.UserId;
    this.objTaskToPost.ManagerName = item.FirstName + item.LastName;
  }

}
