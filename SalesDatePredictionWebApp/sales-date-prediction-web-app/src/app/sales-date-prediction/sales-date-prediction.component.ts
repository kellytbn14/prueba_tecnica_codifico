import {Component} from '@angular/core';
import {CardModule} from "primeng/card";
import {TableLazyLoadEvent, TableModule} from "primeng/table";
import {NextPredictedOrderDate} from "../core/models/next-predicted-order-date";
import {Pageable} from "../core/models/pageable";
import {CustomerService} from "../core/services/customer.service";
import {Router} from "@angular/router";
import {isNullOrUndefined} from "../shared/custom-utils";
import {NgForOf, NgIf} from "@angular/common";
import {IconFieldModule} from 'primeng/iconfield';
import {InputIconModule} from 'primeng/inputicon';
import {InputTextModule} from 'primeng/inputtext';
import {Button} from "primeng/button";
import {DialogModule} from "primeng/dialog";
import {CustomerOrdersComponent} from "../customer-orders/customer-orders.component";
import {CreateOrderComponent} from "../create-order/create-order.component";

@Component({
  selector: 'app-sales-date-prediction',
  standalone: true,
  imports: [
    CardModule,
    TableModule,
    NgForOf,
    NgIf,
    IconFieldModule,
    InputIconModule, InputTextModule, Button, DialogModule, CustomerOrdersComponent, CreateOrderComponent
  ],
  templateUrl: './sales-date-prediction.component.html',
  styleUrl: './sales-date-prediction.component.css'
})
export class SalesDatePredictionComponent {

  customers: NextPredictedOrderDate[] = []
  totalElements = 0
  loading = false
  public cols: any[] = []
  public companyName = ""
  pageable: Pageable = new Pageable(0, 10, '')
  dialogCustomerOrdersVisible: boolean = false;
  customerSelected = new NextPredictedOrderDate()
  dialogCustomerNewOrderVisible: boolean = false;

  constructor(private readonly customerService: CustomerService, private readonly router: Router) {

  }

  ngOnInit(): void {
    this.buildColumns()
  }

  private buildColumns(): void {
    this.cols = [
      {field: 'customerName', header: 'Customer Name', width: '100px', sort: true},
      {field: 'lastOrderDate', header: 'Last order date', width: '100px', sort: false},
      {field: 'nextPredictedOrder', header: 'Next predicted order', width: '10px', sort: false},
      {field: 'actions', header: 'Acciones', width: '100px', sort: false}
    ]
  }

  getNextPredictedOrderDates(): void {
    this.loading = true
    this.customerService.getNextPredictedOrderDates(this.companyName, this.pageable).subscribe(data => {
      if (!isNullOrUndefined(data) || !isNullOrUndefined(data.content)) {
        this.customers = data.content
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
    if ($event.sortField != null && (
      $event.sortField === 'actions' ||
      $event.sortField === 'lastOrderDate' ||
      $event.sortField === 'nextPredictedOrder')) {
      return
    }

    const size = Number($event.rows)
    const page = !isNullOrUndefined($event.first) ? Math.floor(Number($event.first) / size) : 0
    let sortField = $event.sortField ?? 'CustomerId'
    let sortOrder = $event.sortOrder === 1 ? 'asc' : 'desc'
    if (isNullOrUndefined($event.sortField)) {
      sortOrder = 'desc'
    }
    if (sortField === 'customerName') {
      sortField = "CompanyName"
    }
    const sort = `${sortField} ${sortOrder}`

    this.pageable = new Pageable(page, size, sort)
    this.getNextPredictedOrderDates()
  }

  applyFilter($event: KeyboardEvent): void {
    const filterValue = ($event.target as HTMLInputElement).value
    this.companyName = filterValue.trim().toLowerCase()
    this.getNextPredictedOrderDates()
  }

  showDialogCustomerOrdersVisible(rowData: NextPredictedOrderDate) {
    this.customerSelected = rowData
    this.dialogCustomerOrdersVisible = true;
  }

  showDialogCustomerNewOrderVisible(rowData: NextPredictedOrderDate) {
    this.customerSelected = rowData
    this.dialogCustomerNewOrderVisible = true;
  }

  closeDialog() {
    this.dialogCustomerNewOrderVisible = false;
    this.getNextPredictedOrderDates()
  }
}
