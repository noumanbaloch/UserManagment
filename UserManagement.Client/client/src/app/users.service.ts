import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DeleteUser, User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  private baseURL = `https://localhost:44374/api`;

  GetUsers(): Observable<any> {
    return this.http.get(`${this.baseURL}/UserManagement/GetUsers`)
  }
  
  AddUser(data: User): Observable<any> {
    return this.http.post(`${this.baseURL}/UserManagement/AddUser`, data)
  }

  UpdateUser(data: User): Observable<any> {
    return this.http.post(`${this.baseURL}/UserManagement/UpdateUser`, data)
  }

  DeleteUser(data: DeleteUser): Observable<any> {
    return this.http.post(`${this.baseURL}/UserManagement/DeleteUser`, data)
  }
}
