import {Injectable} from '@angular/core'
import {HttpClient} from '@angular/common/http'
import {Observable} from 'rxjs'
import {environment} from "../../../environments/environment";


const URL_BASE = environment.apiServerURL + '/employees'

@Injectable({
  providedIn: 'root'
})
export class EmployeeApi {
  constructor(private readonly http: HttpClient) {
  }

  public getEmployees(): Observable<any> {
    return this.http.get(`${URL_BASE}/get-employees`)
  }
}
