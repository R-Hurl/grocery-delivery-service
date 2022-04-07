import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import {
  OrderDetailsComponentStore,
  OrderDetailsEntity,
} from './order-details-component-store.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css'],
})
export class OrderDetailsComponent implements OnInit {
  orderDetails$: Observable<OrderDetailsEntity[]> =
    this.componentStore.getOrderDetails();

  constructor(
    private componentStore: OrderDetailsComponentStore,
    private route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    const orderId: string | null =
      this.route.snapshot.paramMap.get('orderId') ?? '';

    if (orderId !== '') {
      this.componentStore.fetchOrderDetails(orderId);
    }
  }
}
