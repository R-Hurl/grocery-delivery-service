import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SubmitOrderModel } from '../models';

export interface Order {
  orderId: string;
  orderStatus: string;
  total: number;
}

export interface ProductDTO {
  name: string;
  price: number;
}

export interface OrderItem {
  product: ProductDTO;
  quantity: number;
}

@Injectable({ providedIn: 'root' })
export class OrdersService {
  constructor(private httpClient: HttpClient) {}

  submitOrder(order: SubmitOrderModel): Observable<string> {
    return this.httpClient.post<string>(
      'http://localhost:5000/api/orders',
      order
    );
  }

  getOrders(): Observable<Order[]> {
    return this.httpClient.get<Order[]>('http://localhost:5000/api/orders');
  }

  getOrderItems(orderId: string): Observable<OrderItem[]> {
    return this.httpClient.get<OrderItem[]>(
      `http://localhost:5000/api/orders/${orderId}`
    );
  }
}
