import { createAction, props } from '@ngrx/store';
import { AddToCartModel, ProductModel } from '../models';

export const addToCart = createAction(
  '[cart] added item(s) to cart',
  props<{ payload: AddToCartModel }>()
);
