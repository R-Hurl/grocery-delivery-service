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

export const updateCartItem = createAction(
  '[cart] update item in cart',
  props<{
    payload: { cartItemBeforeUpdate: CartEntity; updatedCartItem: CartEntity };
  }>()
);

export const resetCart = createAction('[cart] reset cart');
