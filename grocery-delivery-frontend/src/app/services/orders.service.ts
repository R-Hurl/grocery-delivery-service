import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SubmitOrderModel } from '../models';

@Injectable({ providedIn: 'root' })
export class OrdersService {
  constructor(private httpClient: HttpClient) {}

  submitOrder(order: SubmitOrderModel): Observable<string> {
    return this.httpClient.post<string>(
      'http://localhost:5000/api/orders',
      order
    );
  }
}
