import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Action, createReducer, on } from '@ngrx/store';
import * as actions from '../actions/categories.actions';

export interface CategoryEntity {
  id: number;
  categoryName: string;
}

export interface CategoriesState extends EntityState<CategoryEntity> {}

export const adapter = createEntityAdapter<CategoryEntity>();

const initialState = adapter.getInitialState();

const reducerFunction = createReducer(
  initialState,
  on(actions.loadCategoriesSucceeded, (state, action) =>
    adapter.setMany(action.payload, state)
  )
);

export const reducer = (
  state: CategoriesState = initialState,
  action: Action
): CategoriesState => reducerFunction(state, action);
