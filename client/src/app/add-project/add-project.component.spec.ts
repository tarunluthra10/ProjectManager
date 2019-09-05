import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { SearchPipe } from '../pipes/search.pipe';
import { SortByPipe } from '../pipes/sort-by.pipe';
import { ModalComponent } from '../modal/modal.component';
import { AddProjectComponent } from './add-project.component';
import { Project } from '../models/project.model';
import { User } from '../models/user.model';

describe('AddProjectComponent', () => {
  let component: AddProjectComponent;
  let fixture: ComponentFixture<AddProjectComponent>;
  let testProject: Project;
  let testUser: User;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        FormsModule,
        NgbModule
      ],
      declarations: [
        AddProjectComponent,
        SearchPipe,
        SortByPipe,
        ModalComponent
      ],
      providers: [
        ApiService,
        NgbActiveModal
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddProjectComponent);
    component = fixture.componentInstance;
    testProject = new Project();
    testProject.ProjectName = "Project1";
    testProject.ManagerName = "Manager1";
    testProject.Priority = 1;
    testUser = new User();
    testUser.EmployeeId = 1;
    testUser.FirstName = "Abc";
    testUser.LastName = "test";
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should Get All Project', () => {
    component.GetAllProject();
    expect(component.listOfProjects).toBeTruthy();
  });

  it('should Add Project', () => {
    component.AddProject(testProject);
    expect(component.listOfProjects).toBeTruthy();
  });

  it('should Update Project', () => {
    component.UpdateProject(testProject);
    expect(component.listOfProjects).toBeTruthy();
  });

  it('should Edit Project', () => {
    component.EditProject(testProject);
    expect(component.listOfProjects).toBeTruthy();
  });

  it('should Reset Project', () => {
    component.ResetProject(testProject);
    expect(component.listOfProjects).toBeTruthy();
  });

  it('should Delete Project', () => {
    component.DeleteProject(testProject);
    expect(component.listOfProjects).toBeTruthy();
  });

  it('should Select Manager', () => {
    component.SelectedManagerClick(testUser);
    expect(component.selectedManager).toBeTruthy();
  });

});
