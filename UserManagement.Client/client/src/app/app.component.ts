import { Component, OnInit } from '@angular/core';
import { UsersService } from './users.service';
import { DeleteUser, User } from './user.model';
import * as moment from 'moment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'User Management';
  users: User[] = [];
  userToDelete: DeleteUser = {
    userId: 0
  };
  user: User = { // Initialize with a default or empty user object
    userId: 0,
    firstName: '',
    lastName: '',
    email: '',
    mobileNumber: '',
    dateOfBirth: ''
  };

  constructor(private userService: UsersService) { }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.GetUsers()
      .subscribe(response => {
        this.users = response.payload;
      });
  }

  addUser() {
    this.userService.AddUser(this.user)
      .subscribe(response => {
        this.loadUsers(); // Optionally refresh the list after adding
      });
  }

  updateUser() {
    this.userService.UpdateUser(this.user)
      .subscribe(response => {
        this.loadUsers(); // Optionally refresh the list after updating
      });
  }

  deleteUser(userId: number) {
    this.userToDelete.userId = userId;
    this.userService.DeleteUser(this.userToDelete)
      .subscribe(response => {
        this.loadUsers(); // Refresh the list after deleting
      });
  }

  editUser(user: User) {
    user.dateOfBirth = moment(user.dateOfBirth).format('YYYY-MM-DD');
    this.user = { ...user };
  }
}