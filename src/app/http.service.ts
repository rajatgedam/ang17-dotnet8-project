import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { IEmployee } from './interfaces/employee';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  apiUrl = "https://localhost:7212";
  http=inject(HttpClient);
  constructor() { }

  getEmployeeList(){

    return this.http.get<IEmployee[]>(this.apiUrl+"/api/Employee")

  }

  createEmployee(employee:IEmployee){

    return this.http.post(this.apiUrl+"/api/Employee",employee)

  }
}
