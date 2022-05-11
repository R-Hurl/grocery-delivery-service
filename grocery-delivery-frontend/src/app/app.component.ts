import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { addOrderConfirmationMessage } from './actions/order-confirmation.actions';
import { AppState } from './reducers';
import OrderConfirmationSignalRService from './services/order-confirmation-signalr-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(
    private orderConfirmationSignalRService: OrderConfirmationSignalRService,
    private store: Store<AppState>
  ) {}
  ngOnInit(): void {
    this.orderConfirmationSignalRService.orderConfirmationReceived.subscribe(
      (data: string) => {
        this.store.dispatch(addOrderConfirmationMessage({ payload: data }));
      }
    );
  }
  title = 'grocery-delivery-frontend';
}
