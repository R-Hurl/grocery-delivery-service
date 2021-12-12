import { createAction, props } from '@ngrx/store';
import { SubmitOrderModel } from '../models';

export const submitOrder = createAction(
  '[checkout] submitted order',
  props<{ payload: SubmitOrderModel }>()
);

export const submitOrderSucceeded = createAction(
  '[checkout] submit order succeeded',
  props<{ payload: string }>()
);

export const submitOrderFailed = createAction(
  '[checkout] submit order failed',
  props<{ payload: string }>()
);
