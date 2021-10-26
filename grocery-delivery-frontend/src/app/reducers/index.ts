import { ActionReducerMap } from '@ngrx/store';
import * as fromCategories from './categories.reducer';

export interface AppState {
  categories: fromCategories.CategoriesState;
}

export const reducers: ActionReducerMap<AppState> = {
  categories: fromCategories.reducer,
};
