import {OrderItem} from "./OrderItem";

export class Order {
  orderId: number;
  orderDate: Date = new Date();
  orderNumber: string;
  items: Array<OrderItem> = [];
  
}