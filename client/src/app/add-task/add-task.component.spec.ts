import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { SearchPipe } from '../pipes/search.pipe';
import { SortByPipe } from '../pipes/sort-by.pipe';
import { ModalComponent } from '../modal/modal.component';
import { AddTaskComponent } from './add-task.component';
import { User } from '../models/user.model';
import { Project } from '../models/project.model';
import { Task } from '../models/task.model';

describe('AddTaskComponent', () => {
  let component: AddTaskComponent;
  let fixture: ComponentFixture<AddTaskComponent>;
  let testUser: User;
  let testProject: Project;
  let testTask: Task;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        FormsModule,
        NgbModule
      ],
      declarations:
        [
          ModalComponent,
          SearchPipe,
          SortByPipe,
          AddTaskComponent
        ],
      providers: [
        ApiService,
        NgbActiveModal
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTaskComponent);
    component = fixture.componentInstance;
    testProject = new Project();
    testProject.ProjectName = "Project1";
    testProject.ManagerName = "Manager1";
    testProject.Priority = 1;
    testUser = new User();
    testUser.EmployeeId = 1;
    testUser.FirstName = "Abc";
    testUser.LastName = "test";
    testTask = new Task();
    testTask.TaskName = "Task1";
    testTask.ProjectName = "Project1";
    testTask.Priority = 1;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should Get All Project', () => {
    component.GetAllProject();
    expect(component.listOfProjects).toBeTruthy();
  });

  it('should Get All Users', () => {
    component.GetAllUserData();
    expect(component.listOfUsers).toBeTruthy();
  });

  it('should Get All Parent Task', () => {
    component.GetAllParentTasks();
    expect(component.listOfParentTasks).toBeTruthy();
  });

  it('should Add Task', () => {
    component.AddTask(testTask);
    expect(component.listOfParentTasks).toBeTruthy();
  });

  it('should Update Task', () => {
    component.UpdateTask(testTask);
    expect(component.listOfParentTasks).toBeTruthy();
  });

  it('should Reset Task', () => {
    component.ResetTask();
    expect(component.listOfParentTasks).toBeTruthy();
  });

  it('should Search Project', () => {
    component.SearchProject();
    expect(component.listOfParentTasks).toBeTruthy();
  });

  it('should Select Project', () => {
    component.SelectedProjectClick(testProject);
    expect(component.objTaskToPost).toBeTruthy();
  });

  it('should Search User', () => {
    component.SearchUser();
    expect(component.listOfUsers).toBeTruthy();
  });

  it('should Select User', () => {
    component.SelectedUserClick(testUser);
    expect(component.objTaskToPost).toBeTruthy();
  });

  it('should Search Task', () => {
    component.SearchParentTask();
    expect(component.listOfParentTasks).toBeTruthy();
  });

  it('should Select Task', () => {
    component.SelectedParentTaskClick(testTask);
    expect(component.objTaskToPost).toBeTruthy();
  });


});
