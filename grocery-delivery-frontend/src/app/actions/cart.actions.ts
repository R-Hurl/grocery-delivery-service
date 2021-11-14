import { createAction, props } from '@ngrx/store';
import { AddToCartModel, ProductModel } from '../models';
import { CartEntity } from '../reducers/cart.reducer';

export const addToCart = createAction(
  '[cart] added item(s) to cart',
  props<{ payload: AddToCartModel }>()
);

export const removeFromCart = createAction(
  '[cart] removed item from cart',
  props<{ payload: CartEntity }>()
);
