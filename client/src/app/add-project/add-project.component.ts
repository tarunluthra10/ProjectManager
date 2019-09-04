import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Project } from '../models/project.model';
import { User } from '../models/user.model';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';
import { ApiService } from '../services/api.service';

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

  constructor(private modalService: NgbModal, private refApiService: ApiService) { }

  ngOnInit() {
    this.GetAllProject();
    this.GetAllManagerData();
  }

  private ValidateProject(objProject: Project): Boolean {
    let isValid = false;
    isValid = objProject.ProjectName.trim() !== '' && objProject.Priority.toString().trim() !== '' && objProject.ManagerName.toString().trim() !== '';
    return isValid;

  }

  GetAllProject() {
    this.listOfProjects = new Array<Project>();
    this.refApiService.GetAllProjects().subscribe(res => {
      console.log(res);
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

  GetAllManagerData() {
    this.listOfManagers = new Array<User>();
    this.refApiService.GetAllUsers().subscribe(res => {
      for (let oneUser of res) {
        var objUserItem = new User();
        objUserItem.UserId = oneUser.UserId;
        objUserItem.EmployeeId = oneUser.EmployeeId;
        objUserItem.FirstName = oneUser.FirstName;
        objUserItem.LastName = oneUser.LastName;
        this.listOfManagers.push(objUserItem);
      }
    });
  }


  AddProject(objProject: Project): void {
    console.log(objProject);
    if (this.ValidateProject(objProject)) {
      this.refApiService.AddNewProject(objProject).subscribe(res => { this.GetAllProject(); });
    }
  }

  UpdateProject(objProject: Project): void {
    console.log(objProject);
    if (this.ValidateProject(objProject)) {
      this.refApiService.UpdateProject(objProject).subscribe(res => { 
        if(res)
        {
          this.GetAllProject(); this.isAdd = true; 
        }
      });
    }
    
  }

  ResetProject(objProject: Project): void {
    this.objProjectToPost = new Project();
    this.isAdd = true;
  }

  EditProject(objProject: Project): void {
    this.objProjectToPost = objProject;
    this.isAdd = false;
  }

  DeleteProject(objProject: Project): void {
    if (this.ValidateProject(objProject)) {
      this.refApiService.RemoveProject(objProject).subscribe(res => { 
        if(res)
        {
          this.GetAllProject(); 
          this.isAdd = true; 
        }
      });
    }
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
