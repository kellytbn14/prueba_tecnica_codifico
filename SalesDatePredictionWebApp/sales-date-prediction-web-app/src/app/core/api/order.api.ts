import {Injectable} from '@angular/core'
import {HttpClient} from '@angular/common/http'
import {Observable} from 'rxjs'
import {environment} from "../../../environments/environment";
import {Pageable} from "../models/pageable";
import {buildHttpParamsPageable} from "../../shared/custom-utils";
import {headers} from "../../shared/constants";
import {CreateOrderRequest} from "../models/create-order-request";


const URL_BASE = environment.apiServerURL + '/orders'

@Injectable({
  providedIn: 'root'
})
export class OrderApi {
  constructor(private readonly http: HttpClient) {
  }

  public getCustomerOrders(customerId: number, pageable?: Pageable): Observable<any> {
    let params = buildHttpParamsPageable(pageable)
    return this.http.get(`${URL_BASE}/get-customer-orders/${customerId}`, {headers, params})
  }

  public createOrderWithDetails(createOrderRequest: CreateOrderRequest): Observable<any> {
    return this.http.post(`${URL_BASE}/create-order-with-details`, createOrderRequest)
  }
}
