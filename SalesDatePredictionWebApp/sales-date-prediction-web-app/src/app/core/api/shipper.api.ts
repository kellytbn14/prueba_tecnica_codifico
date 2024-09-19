import {Injectable} from '@angular/core'
import {HttpClient} from '@angular/common/http'
import {Observable} from 'rxjs'
import {environment} from "../../../environments/environment";


const URL_BASE = environment.apiServerURL + '/shippers'

@Injectable({
  providedIn: 'root'
})
export class ShipperApi {
  constructor(private readonly http: HttpClient) {
  }

  public getShippers(): Observable<any> {
    return this.http.get(`${URL_BASE}/get-shippers`)
  }
}
