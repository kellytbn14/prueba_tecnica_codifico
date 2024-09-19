import {Injectable} from '@angular/core'
import {Observable} from 'rxjs'
import {ProductApi} from "../api/product.api";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(private readonly api: ProductApi) {
  }

  getProducts(): Observable<any> {
    return this.api.getProducts()
  }
}
