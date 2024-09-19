import {Injectable} from '@angular/core'
import {Observable} from 'rxjs'
import {EmployeeApi} from "../api/employee.api";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  constructor(private readonly api: EmployeeApi) {
  }

  getEmployees(): Observable<any> {
    return this.api.getEmployees()
  }
}
