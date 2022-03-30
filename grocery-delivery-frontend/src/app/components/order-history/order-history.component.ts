import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { getOrderHistory } from 'src/app/actions/orders.actions';
import { AppState, selectOrderEntites } from 'src/app/reducers';
import { OrderEntity } from 'src/app/reducers/orders.reducer';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css'],
})
export class OrderHistoryComponent implements OnInit {
  orders$!: Observable<OrderEntity[]>;

  constructor(private store: Store<AppState>) {
    this.store.dispatch(getOrderHistory());
  }

  ngOnInit(): void {
    this.orders$ = this.store.select(selectOrderEntites);
  }
}
