import { createAction, props } from '@ngrx/store';

export const loadOrderConfirmationMessages = createAction(
  '[order confirmation] load order confirmation messages'
);

export const addOrderConfirmationMessage = createAction(
  '[order confirmation] message added',
  props<{ payload: string }>()
);
