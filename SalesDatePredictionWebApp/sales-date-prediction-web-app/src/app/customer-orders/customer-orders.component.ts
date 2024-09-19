import {Component, Input} from '@angular/core';
import {HeaderComponent} from "../common/header/header.component";
import {MenubarModule} from "primeng/menubar";
import {NextPredictedOrderDate} from "../core/models/next-predicted-order-date";
import {Pageable} from "../core/models/pageable";
import {CustomerOrderResponse} from "../core/models/customer-order-response";
import {CustomerService} from "../core/services/customer.service";
import {Router} from "@angular/router";
import {isNullOrUndefined} from "../shared/custom-utils";
import {TableLazyLoadEvent, TableModule} from "primeng/table";
import {OrderService} from "../core/services/order.service";
import {CardModule} from "primeng/card";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-customer-orders',
  standalone: true,
  imports: [
    HeaderComponent,
    MenubarModule,
    CardModule,
    TableModule,
    NgForOf
  ],
  templateUrl: './customer-orders.component.html',
  styleUrl: './customer-orders.component.css'
})
export class CustomerOrdersComponent {
  orders: CustomerOrderResponse[] = []
  totalElements = 0
  loading = false
  public cols: any[] = []
  pageable: Pageable = new Pageable(0, 10, '')
  @Input() customerId: any

  constructor(private readonly orderService: OrderService, private readonly router: Router) {

  }

  ngOnInit(): void {
    this.buildColumns()
  }

  private buildColumns(): void {
    this.cols = [
      {field: 'orderId', header: 'Order Id', width: '100px', sort: false},
      {field: 'requiredDate', header: 'Required date', width: '100px', sort: false},
      {field: 'shippedDate', header: 'Shipped date', width: '10px', sort: false},
      {field: 'shipName', header: 'Ship name', width: '100px', sort: false},
      {field: 'shipAddress', header: 'Ship address', width: '100px', sort: false},
      {field: 'shipCity', header: 'Ship city', width: '100px', sort: false}
    ]
  }

  getNextPredictedOrderDates(): void {
    this.loading = true
    this.orderService.getCustomerOrders(this.customerId, this.pageable).subscribe(data => {
      if (!isNullOrUndefined(data) || !isNullOrUndefined(data.content)) {
        this.orders = data.content
        this.totalElements = data.totalElements
      }
      this.loading = false
    }, error => {
      console.error('Error: ' + error)
      this.loading = false
    }, () => {
      this.loading = false
    })
  }

  loadRecordsLazy($event: TableLazyLoadEvent): void {
    if ($event.sortField != null && $event.sortField === 'actions') {
      return
    }

    const size = Number($event.rows)
    const page = !isNullOrUndefined($event.first) ? Math.floor(Number($event.first) / size) : 0
    let sortField = $event.sortField ?? 'OrderId'
    let sortOrder = $event.sortOrder === 1 ? 'asc' : 'desc'
    if (isNullOrUndefined($event.sortField)) {
      sortOrder = 'desc'
    }
    const sort = `${sortField} ${sortOrder}`

    this.pageable = new Pageable(page, size, sort)
    this.getNextPredictedOrderDates()
  }
}
