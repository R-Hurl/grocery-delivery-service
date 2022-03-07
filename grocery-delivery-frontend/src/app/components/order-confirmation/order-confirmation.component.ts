import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState, selectOrderNumber } from 'src/app/reducers';

@Component({
  selector: 'app-order-confirmation',
  templateUrl: './order-confirmation.component.html',
  styleUrls: ['./order-confirmation.component.css'],
})
export class OrderConfirmationComponent implements OnInit {
  orderNumber$!: Observable<string>;

  constructor(private store: Store<AppState>) {}

  ngOnInit(): void {
    this.orderNumber$ = this.store.select(selectOrderNumber);
  }
}
