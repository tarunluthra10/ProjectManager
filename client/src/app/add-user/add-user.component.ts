import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { User } from '../models/user.model';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  public listUsers: Array<User>;
  public searchText: string;
  public objUserToPost: User = new User();
  public isAdd: boolean = true;
  public sortByColumn: string = '';

  constructor(private refApiService: ApiService) { }

  ngOnInit() {
    this.GetAllUsersData();
  }

  GetAllUsersData() {
    this.listUsers = new Array<User>();
    this.refApiService.GetAllUsers().subscribe(res => {
      for (let oneUser of res) {
        var objUserItem = new User();
        objUserItem.UserId = oneUser.UserId;
        objUserItem.EmployeeId = oneUser.EmployeeId;
        objUserItem.FirstName = oneUser.FirstName;
        objUserItem.LastName = oneUser.LastName;
        this.listUsers.push(objUserItem);
      }
    });
  }

  AddUser(objUser: User): void {
    if (this.ValidateUser(objUser)) {
      this.refApiService.AddNewUser(objUser).subscribe(res => { this.GetAllUsersData(); });
    }

  }

  UpdateUser(objUser: User): void {
    if (this.ValidateUser(objUser)) {
      this.refApiService.UpdateUser(objUser).subscribe(res => {
        if (res) {
          this.isAdd = true;
          this.GetAllUsersData();
          this.ResetUser();
        }
      });
    }

  }

  private ValidateUser(objUser: User): Boolean {
    let isValid = false;
    isValid = objUser.FirstName.trim() !== '' && objUser.LastName.trim() !== '' && objUser.EmployeeId.toString().trim() !== '';
    return isValid;

  }

  DeleteUser(objUser: User): void {
    this.refApiService.RemoveUser(objUser).subscribe(res => {
      this.GetAllUsersData();
    });
  }

  ResetUser(): void {
    this.objUserToPost = new User();
    this.isAdd = true;
  }

  EditUser(objUser: User) {
    this.isAdd = false;
    this.objUserToPost = new User();
    this.objUserToPost.UserId = objUser.UserId;
    this.objUserToPost.EmployeeId = objUser.EmployeeId;
    this.objUserToPost.FirstName = objUser.FirstName;
    this.objUserToPost.LastName = objUser.LastName;
  }

  
}
