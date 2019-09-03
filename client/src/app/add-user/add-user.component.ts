import { Component, OnInit,ChangeDetectionStrategy } from '@angular/core';
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
    // for(var i=1; i <= 10; i++)
    // {
    //   var abc = new User();
    //   abc.UserId = i;
    //   abc.EmployeeId = i;
    //   abc.FirstName = "FName"+i;
    //   abc.LastName = "LName"+i;
    //   this.listUsers.push(abc);

    // }


  }

  GetAllUsersData() {
    this.listUsers = new Array<User>();
    this.refApiService.GetAllUsers().subscribe(res => {
      console.log(res);
      for (let oneUser of res) {
        var objUserItem = new User();
        objUserItem.UserId = oneUser.UserId;
        objUserItem.EmployeeId = oneUser.EmployeeId;
        objUserItem.FirstName = oneUser.FirstName;
        objUserItem.LastName = oneUser.LastName;
        console.log('mapping list of users');
        this.listUsers.push(objUserItem);
     }
    });
  }

  AddUser(objUser: User): void {
    console.log(objUser);
    this.refApiService.AddNewUser(objUser).subscribe(res => { console.log(res); this.GetAllUsersData(); });

  }

  UpdateUser(objUser: User): void {
    console.log(objUser);
    this.isAdd = true;
  }

  ResetUser(objUser: User): void {
    this.objUserToPost = new User();
    this.isAdd = true;
  }

  EditUser(objUser: User): void {
    this.objUserToPost = objUser;
    this.isAdd = false;
  }

  DeleteUser(objUser: User): void {
    // call service to delete user

    // Load all users
  }


}
