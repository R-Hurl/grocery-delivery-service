import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Action, createReducer, on } from '@ngrx/store';
import * as actions from '../actions/products.actions';

export interface ProductEntity {
  id: number;
  categoryId: number;
  name: string;
  description: string;
}

export interface ProductsState extends EntityState<ProductEntity> {}

export const adapter = createEntityAdapter<ProductEntity>();

const initialState = adapter.getInitialState();

const reducerFunction = createReducer(
  initialState,
  on(actions.loadProductsByCategorySucceeded, (state, action) =>
    adapter.setAll(action.payload, state)
  )
);

export const reducer = (
  state: ProductsState = initialState,
  action: Action
): ProductsState => reducerFunction(state, action);
