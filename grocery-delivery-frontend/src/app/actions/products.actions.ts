import { createAction, props } from '@ngrx/store';
import { ProductEntity } from '../reducers/products.reducer';

export const loadProductsByCategory = createAction(
  '[products] load products by category',
  props<{ payload: number }>()
);

export const loadProductsByCategorySucceeded = createAction(
  '[products] load products by category succeeded',
  props<{ payload: ProductEntity[] }>()
);
