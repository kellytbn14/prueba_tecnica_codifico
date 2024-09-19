import {Injectable} from '@angular/core'
import {HttpClient} from '@angular/common/http'
import {Observable} from 'rxjs'
import {environment} from "../../../environments/environment";


const URL_BASE = environment.apiServerURL + '/products'

@Injectable({
  providedIn: 'root'
})
export class ProductApi {
  constructor(private readonly http: HttpClient) {
  }

  public getProducts(): Observable<any> {
    return this.http.get(`${URL_BASE}/get-products`)
  }
}
