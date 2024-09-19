import {Injectable} from '@angular/core'
import {Observable} from 'rxjs'
import {Pageable} from '../models/pageable'
import {CustomerApi} from "../api/customer.api";

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  constructor(private readonly api: CustomerApi) {
  }

  getNextPredictedOrderDates(companyName: string, pageable?: Pageable): Observable<any> {
    return this.api.getNextPredictedOrderDates(companyName, pageable)
  }
}
