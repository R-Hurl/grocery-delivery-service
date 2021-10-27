import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { CategoriesService } from '../services/categories.service';
import { map, switchMap } from 'rxjs/operators';
import * as categoryActions from '../actions/categories.actions';

@Injectable()
export class GroceryShopEffects {
  loadCategories$ = createEffect(() =>
    this.actions$.pipe(
      ofType(categoryActions.loadCategories),
      switchMap(() =>
        this.categoriesService
          .getCategories()
          .pipe(
            map((payload) =>
              categoryActions.loadCategoriesSucceeded({ payload })
            )
          )
      )
    )
  );

  constructor(
    private categoriesService: CategoriesService,
    private actions$: Actions
  ) {}
}
