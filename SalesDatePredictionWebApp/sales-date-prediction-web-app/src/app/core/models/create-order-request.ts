export class CreateOrderRequest {
  custumerId?: number;
  employeeId?: number;
  shipperId?: number;
  productId?: number;
  shipName?: string;
  shipAddress?: string;
  shipCity?: string;
  shipCountry?: string;
  orderDate?: Date;
  requiredDate?: Date;
  shippedDate?: Date;
  freight?: number;
  unitPrice?: number;
  quantity?: number;
  discount?: number;
}
