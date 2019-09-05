import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import {ApiService} from '../services/api.service';
import { SearchPipe } from '../pipes/search.pipe';
import { SortByPipe } from '../pipes/sort-by.pipe';
import { ModalComponent } from '../modal/modal.component';
import { ViewTaskComponent } from './view-task.component';
import { Project } from '../models/project.model';
import { Task } from '../models/task.model';

describe('ViewTaskComponent', () => {
  let component: ViewTaskComponent;
  let fixture: ComponentFixture<ViewTaskComponent>;
  let testProject: Project;
  let testTask: Task;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        FormsModule,
        NgbModule
      ],
      declarations: [ 
        ViewTaskComponent,
        SearchPipe,
        SortByPipe,
        ModalComponent
      ],
      providers : [
        ApiService,
        NgbActiveModal
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewTaskComponent);
    component = fixture.componentInstance;
    testProject = new Project();
    testProject.ProjectId = 1;
    testProject.ProjectName = "Project1";
    testProject.ManagerName = "Manager1";
    testProject.Priority = 1;
    testTask = new Task();
    testTask.TaskName = "Task1";
    testTask.ProjectName = "Project1";
    testTask.Priority = 1;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should get all project', () => {
    component.GetAllProject();
    expect(component.listOfProjects).toBeTruthy();
  });

  it('should get all tasks for a project', () => {
    component.GetAllTaskForProject(1);
    expect(component.listOfTasks).toBeTruthy();
  });

  it('should Edit tasks for a project', () => {
    component.EditTask(testTask);
    expect(component.objTaskToPost).toBeTruthy();
  });

  it('should Delete tasks for a project', () => {
    component.DeleteTask(testTask);
    expect(component.objTaskToPost).toBeTruthy();
  });
  
  it('should select project', () => {
    component.SelectedProjectClick(testProject);
    expect(component.objTaskToPost).toBeTruthy();
  });

  it('should search project', () => {
    component.SearchProject();
    expect(component.objTaskToPost).toBeTruthy();
  });

});
