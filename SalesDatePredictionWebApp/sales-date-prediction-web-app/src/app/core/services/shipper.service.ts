import {Injectable} from '@angular/core'
import {Observable} from 'rxjs'
import {ShipperApi} from "../api/shipper.api";

@Injectable({
  providedIn: 'root'
})
export class ShipperService {
  constructor(private readonly api: ShipperApi) {
  }

  getShippers(): Observable<any> {
    return this.api.getShippers()
  }
}
