import { createAction, props } from '@ngrx/store';
import { OrderEntity } from '../reducers/orders.reducer';

export const getOrderHistory = createAction('[orders] get order history');

export const getOrderHistorySucceeded = createAction(
  '[orders] get order history succeeded',
  props<{ payload: OrderEntity[] }>()
);
