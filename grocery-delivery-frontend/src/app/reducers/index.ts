import { ActionReducerMap, createSelector } from '@ngrx/store';
import { CategoryModel } from '../models';
import * as fromCategories from './categories.reducer';
import * as fromProducts from './products.reducer';

export interface AppState {
  categories: fromCategories.CategoriesState;
  products: fromProducts.ProductsState;
}

export const reducers: ActionReducerMap<AppState> = {
  categories: fromCategories.reducer,
  products: fromProducts.reducer,
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
