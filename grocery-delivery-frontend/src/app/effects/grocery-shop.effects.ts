import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { CategoriesService } from '../services/categories.service';
import { map, switchMap } from 'rxjs/operators';
import * as categoryActions from '../actions/categories.actions';
import * as productActions from '../actions/products.actions';
import { ProductsService } from '../services/products.services';

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

  loadProductsByCategoryId$ = createEffect(() =>
    this.actions$.pipe(
      ofType(productActions.loadProductsByCategory),
      switchMap((action) =>
        this.productsService
          .getProductsByCategoryId(action.payload)
          .pipe(
            map((payload) =>
              productActions.loadProductsByCategorySucceeded({ payload })
            )
          )
      )
    )
  );

  constructor(
    private categoriesService: CategoriesService,
    private productsService: ProductsService,
    private actions$: Actions
  ) {}
}
