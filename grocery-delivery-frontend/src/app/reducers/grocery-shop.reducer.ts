import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Action, createReducer } from '@ngrx/store';

export interface CategoryEntity {
  id: number;
  categoryName: string;
}

export interface GroceryShopState extends EntityState<CategoryEntity> {}

export const adapter = createEntityAdapter<CategoryEntity>();

const initialState = adapter.getInitialState();

const reducerFunction = createReducer(initialState);

export const reducer = (
  state: GroceryShopState = initialState,
  action: Action
): GroceryShopState => reducerFunction(state, action);
