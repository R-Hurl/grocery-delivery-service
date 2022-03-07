import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import * as orderActions from '../actions/checkout.actions';
import { OrdersService } from '../services/orders.service';

@Injectable()
export class GroceryCheckoutEffects {
  submitOrder$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(orderActions.submitOrder),
      switchMap(({ payload }) => {
        return this.ordersService
          .submitOrder(payload)
          .pipe(
            map((orderNumber) =>
              orderActions.submitOrderSucceeded({ payload: orderNumber })
            )
          );
      }),
      catchError((err) => {
        console.log('Exception occured submitting order', err);
        return EMPTY;
      })
    );
  });

  constructor(
    private actions$: Actions,
    private ordersService: OrdersService
  ) {}
}
