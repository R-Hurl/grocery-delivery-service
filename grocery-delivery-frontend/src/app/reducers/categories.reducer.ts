import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Action, createReducer } from '@ngrx/store';

export interface CategoryEntity {
  id: number;
  categoryName: string;
}

export interface CategoriesState extends EntityState<CategoryEntity> {}

export const adapter = createEntityAdapter<CategoryEntity>();

const initialState = adapter.getInitialState();

const reducerFunction = createReducer(initialState);

export const reducer = (
  state: CategoriesState = initialState,
  action: Action
): CategoriesState => reducerFunction(state, action);
