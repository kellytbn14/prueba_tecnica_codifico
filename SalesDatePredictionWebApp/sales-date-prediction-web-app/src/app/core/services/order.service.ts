import {Injectable} from '@angular/core'
import {Observable} from 'rxjs'
import {Pageable} from '../models/pageable'
import {OrderApi} from "../api/order.api";
import {CreateOrderRequest} from "../models/create-order-request";

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  constructor(private readonly api: OrderApi) {
  }

  getCustomerOrders(customerId: number, pageable?: Pageable): Observable<any> {
    return this.api.getCustomerOrders(customerId, pageable)
  }

  createOrderWithDetails(createOrderRequest: CreateOrderRequest): Observable<any> {
    return this.api.createOrderWithDetails(createOrderRequest)
  }
}
