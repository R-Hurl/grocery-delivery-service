import { createAction, props } from '@ngrx/store';
import { CategoryEntity } from '../reducers/categories.reducer';

export const loadCategories = createAction('[categories] load categories');

export const loadCategoriesSucceeded = createAction(
  '[categories] load categories succeeded',
  props<{ payload: CategoryEntity[] }>()
);

export const loadCategoriesFailed = createAction(
  '[categories] load categories failed',
  props<{ payload: string }>()
);
