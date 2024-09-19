import {Component, EventEmitter, Input, Output} from '@angular/core';
import {CardModule} from "primeng/card";
import {DropdownModule} from "primeng/dropdown";
import {EmployeeService} from "../core/services/employee.service";
import {EmployeeResponse} from "../core/models/employee-response";
import {isNullOrUndefined} from "../shared/custom-utils";
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {ShipperService} from "../core/services/shipper.service";
import {ProductService} from "../core/services/product.service";
import {ShipperResponse} from "../core/models/shipper-response";
import {ProductResponse} from "../core/models/product-response";
import {FloatLabelModule} from "primeng/floatlabel";
import {InputTextModule} from "primeng/inputtext";
import {CalendarModule} from "primeng/calendar";
import {InputNumberModule} from "primeng/inputnumber";
import {CreateOrderRequest} from "../core/models/create-order-request";
import {OrderService} from "../core/services/order.service";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-create-order',
  standalone: true,
  imports: [
    CardModule,
    DropdownModule, FormsModule, FloatLabelModule, InputTextModule, CalendarModule, InputNumberModule, ReactiveFormsModule, NgIf
  ],
  templateUrl: './create-order.component.html',
  styleUrl: './create-order.component.css'
})
export class CreateOrderComponent {
  @Input() customerId: number | undefined
  @Output() orderCreated = new EventEmitter<void>();
  employees: EmployeeResponse[] = []
  employeeSelected = new EmployeeResponse()
  shippers: ShipperResponse[] = []
  shipperSelected = new ShipperResponse()
  products: ProductResponse[] = []
  productSelected = new ProductResponse()
  createOrderRequest = new CreateOrderRequest()
  orderForm: FormGroup;

  constructor(private readonly employeeService: EmployeeService,
              private readonly shipperService: ShipperService,
              private readonly productService: ProductService,
              private readonly orderService: OrderService,
              private fb: FormBuilder,) {
    this.orderForm = fb.group({})
  }

  ngOnInit(): void {
    this.getEmployees()
    this.getShippers()
    this.getProducts()
    this.initializeOrderForm()
  }

  initializeOrderForm(): void {
    this.orderForm = this.fb.group({
      employeeSelected: [null, Validators.required],
      shipperSelected: [null, Validators.required],
      shipName: ['', Validators.required],
      shipAddress: ['', Validators.required],
      shipCity: ['', Validators.required],
      shipCountry: ['', Validators.required],
      orderDate: [null, Validators.required],
      requiredDate: [null, Validators.required],
      shippedDate: [null, Validators.required],
      freight: [null, Validators.required],
      productSelected: [null, Validators.required],
      unitPrice: [null, Validators.required],
      quantity: [null, Validators.required],
      discount: [null, Validators.required]
    })
  }

  buildFormControls(controls: any): CreateOrderRequest {
    const obj: any = {}
    for (const pro in controls) {
      if (controls[pro]?.value !== undefined) {
        obj[pro] = controls[pro].value
      }
    }
    const custumerId = this.customerId ?? null
    const employeeId = this.employeeSelected?.employeeId ?? null
    const shipperId = this.shipperSelected?.shipperId ?? null
    const productId = this.productSelected?.productId ?? null
    return {
      ...obj,
      custumerId,
      employeeId,
      shipperId,
      productId
    } satisfies CreateOrderRequest
  }

  getEmployees(): void {
    this.employeeService.getEmployees().subscribe(data => {
      if (!isNullOrUndefined(data)) {
        this.employees = data
      }
    }, error => {
      console.error('Error: ' + error)
    }, () => {
    })
  }

  getShippers(): void {
    this.shipperService.getShippers().subscribe(data => {
      if (!isNullOrUndefined(data)) {
        this.shippers = data
      }
    }, error => {
      console.error('Error: ' + error)
    }, () => {
    })
  }

  getProducts(): void {
    this.productService.getProducts().subscribe(data => {
      if (!isNullOrUndefined(data)) {
        this.products = data
      }
    }, error => {
      console.error('Error: ' + error)
    }, () => {
    })
  }

  createOrderWithDetails(): void {
    this.createOrderRequest = this.buildFormControls(this.orderForm.controls)
    if (this.orderForm.valid) {
      this.orderService.createOrderWithDetails(this.createOrderRequest).subscribe(data => {
        if (!isNullOrUndefined(data) && !isNullOrUndefined(data.orderId)) {
          this.closeDialog()
        }
      }, error => {
        console.error('Error: ' + error)
      }, () => {
      })
    }
  }

  closeDialog() {
    this.orderCreated.emit();
    this.createOrderRequest = new CreateOrderRequest()
    this.orderForm.reset()
  }
}
