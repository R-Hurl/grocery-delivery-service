import { ActionReducerMap, createSelector } from '@ngrx/store';
import { CategoryModel } from '../models';
import * as fromCategories from './categories.reducer';

export interface AppState {
  categories: fromCategories.CategoriesState;
}

export const reducers: ActionReducerMap<AppState> = {
  categories: fromCategories.reducer,
};

const selectCategoriesBranch = (state: AppState) => state.categories;

const { selectAll: selectCategoriesEntityArray } =
  fromCategories.adapter.getSelectors(selectCategoriesBranch);

// Selectors
export const selectCategories = createSelector(
  selectCategoriesEntityArray,
  (categories) =>
    categories.map((category) => {
      return {
        ...category,
      } as CategoryModel;
    })
);
