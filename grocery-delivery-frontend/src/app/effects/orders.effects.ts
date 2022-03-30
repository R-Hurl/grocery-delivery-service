import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { OrdersService } from '../services/orders.service';
import * as orderActions from '../actions/orders.actions';
import { map, switchMap } from 'rxjs/operators';
import { OrderEntity } from '../reducers/orders.reducer';

@Injectable()
export class OrderEffects {
  getOrderHistory$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(orderActions.getOrderHistory),
      switchMap(() => {
        return this.ordersService.getOrders().pipe(
          map((response) => {
            const orderEntities: OrderEntity[] = response as OrderEntity[];
            return orderActions.getOrderHistorySucceeded({
              payload: orderEntities,
            });
          })
        );
      })
    );
  });

  constructor(
    private actions$: Actions,
    private ordersService: OrdersService
  ) {}
}
