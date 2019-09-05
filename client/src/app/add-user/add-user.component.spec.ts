import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import {ApiService} from '../services/api.service';
import { SearchPipe } from '../pipes/search.pipe';
import { SortByPipe } from '../pipes/sort-by.pipe';
import { ModalComponent } from '../modal/modal.component';
import { AddUserComponent } from './add-user.component';
import { User } from '../models/user.model';

describe('AddUserComponent', () => {
  let component: AddUserComponent;
  let fixture: ComponentFixture<AddUserComponent>;
  let testUser: User;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        FormsModule,
        NgbModule
      ],
      declarations: [ 
        AddUserComponent ,
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
    fixture = TestBed.createComponent(AddUserComponent);
    component = fixture.componentInstance;
    testUser = new User();
    testUser.EmployeeId = 1;
    testUser.FirstName = "Abc";
    testUser.LastName = "test";
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should get All user data', () => {
    component.GetAllUsersData();
    expect(component.listUsers).toBeTruthy();
  });

  it('should add user data', () => {
    component.AddUser(testUser);
    expect(component.listUsers).toBeTruthy();
  });

  it('should update user data', () => {
    component.UpdateUser(testUser);
    expect(component.listUsers).toBeTruthy();
  });

  it('should reset user data', () => {
    component.ResetUser();
    expect(component.listUsers).toBeTruthy();
  });

  it('should Edit user data', () => {
    component.EditUser(testUser);
    expect(component.listUsers).toBeTruthy();
  });

  it('should Delete user data', () => {
    component.DeleteUser(testUser);
    expect(component.listUsers).toBeTruthy();
  });

});
