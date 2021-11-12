import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { addToCart } from 'src/app/actions/cart.actions';
import { loadCategories } from 'src/app/actions/categories.actions';
import { loadProductsByCategory } from 'src/app/actions/products.actions';
import { AddToCartModel, CategoryModel, ProductModel } from 'src/app/models';
import {
  AppState,
  selectCategories,
  selectIsProductsLoading,
  selectProducts,
  selectProductsBySearchTerm,
} from 'src/app/reducers';

@Component({
  selector: 'app-grocery-shop',
  templateUrl: './grocery-shop.component.html',
  styleUrls: ['./grocery-shop.component.css'],
})
export class GroceryShopComponent implements OnInit {
  categories$!: Observable<CategoryModel[]>;
  products$!: Observable<ProductModel[]>;
  isProductsLoading$!: Observable<boolean>;
  productSearchTerm!: string;
  form = this.formBuilder.group({
    category: ['1'],
  });

  constructor(
    private formBuilder: FormBuilder,
    private store: Store<AppState>
  ) {
    this.store.dispatch(loadCategories());
  }

  get category() {
    return this.form.get('category');
  }

  ngOnInit(): void {
    this.categories$ = this.store.select(selectCategories);
    this.products$ = this.store.select(selectProducts);
    this.isProductsLoading$ = this.store.select(selectIsProductsLoading);
  }

  submit() {
    const category: number = this?.category?.value;
    this.store.dispatch(loadProductsByCategory({ payload: category }));
  }

  searchForProduct() {
    this.products$ = this.store.select(
      selectProductsBySearchTerm({ searchTerm: this.productSearchTerm })
    );
  }

  addToCart(product: ProductModel, quantity: string) {
    const payload: AddToCartModel = { product, quantity: Number(quantity) };
    this.store.dispatch(addToCart({ payload }));
  }
}
