import { Component } from '@angular/core';
import { OrderHistoryComponentStore } from './order-history-component-store.service';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css'],
})
export class OrderHistoryComponent {
  orders$ = this.componentStore.selectOrders$;

  constructor(private componentStore: OrderHistoryComponentStore) {
    this.componentStore.loadOrders();
  }
}
