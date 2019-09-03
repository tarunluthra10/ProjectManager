import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Project } from '../models/project.model';
import { User } from '../models/user.model';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {

  public objProjectToPost: Project = new Project;
  public listOfProjects: Array<Project>;
  public setDate: boolean = false;
  public isAdd: boolean = true;
  public sortByColumn: string = '';
  public listOfManagers: Array<User>;
  public selectedManager: User = new User();

  @ViewChild('searchMgrModal', { static: false }) searchMgrModal: TemplateRef<any>;

  constructor(private modalService: NgbModal) { }

  ngOnInit() {
    this.listOfProjects = new Array<Project>();
    for (var i = 1; i <= 10; i++) {
      var abc = new Project();
      abc.ProjectId = i;
      abc.ProjectName = "Project" + i;
      abc.Priority = 10;
      abc.Completed = "2";
      abc.StartDate = new Date(2019, 9, 1);
      abc.EndDate = new Date(2019, 9, 1);
      abc.NumberOfTasks = i;
      this.listOfProjects.push(abc);

    }

    this.listOfManagers = new Array<User>();
    for (var i = 1; i <= 10; i++) {
      var objUser = new User();
      objUser.EmployeeId = i;
      objUser.UserId = i;
      objUser.FirstName = "FirstName" + i;
      objUser.LastName = "LastName" + i;
      this.listOfManagers.push(objUser);

    }

  }

  AddProject(objProject: Project): void {
    console.log(objProject);
  }

  UpdateProject(objProject: Project): void {
    console.log(objProject);
    this.isAdd = true;
  }

  ResetProject(objProject: Project): void {
    this.objProjectToPost = new Project();
    this.isAdd = true;
  }

  EditProject(objProject: Project): void {
    this.objProjectToPost = objProject;
    this.isAdd = false;
  }

  DeleteProject(objUser: Project): void {
    // call service to delete user

    // Load all users
  }

  SearchManager() {
    const modalRef = this.modalService.open(this.searchMgrModal);
    console.log(modalRef);
  }

  SelectedManagerClick(item: User) {
    this.selectedManager = item;
    this.objProjectToPost.ManagerId = item.UserId;
    this.objProjectToPost.ManagerName = item.FirstName + item.LastName;
  }


}
