import {Injectable} from '@angular/core'
import {HttpClient} from '@angular/common/http'
import {Observable} from 'rxjs'
import {environment} from "../../../environments/environment";
import {Pageable} from "../models/pageable";
import {buildHttpParamsPageable} from "../../shared/custom-utils";
import {headers} from "../../shared/constants";


const URL_BASE = environment.apiServerURL + '/customers'

@Injectable({
  providedIn: 'root'
})
export class CustomerApi {
  constructor(private readonly http: HttpClient) {
  }

  public getNextPredictedOrderDates(companyName: string, pageable?: Pageable): Observable<any> {
    let params = buildHttpParamsPageable(pageable)
    params = params.set('companyName', companyName ?? '')
    return this.http.get(`${URL_BASE}/get-next-predicted-order-dates`, {headers, params})
  }
}
