import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { loadCategories } from 'src/app/actions/categories.actions';
import { loadProductsByCategory } from 'src/app/actions/products.actions';
import { CategoryModel, ProductModel } from 'src/app/models';
import { AppState, selectCategories, selectProducts } from 'src/app/reducers';

@Component({
  selector: 'app-grocery-shop',
  templateUrl: './grocery-shop.component.html',
  styleUrls: ['./grocery-shop.component.css'],
})
export class GroceryShopComponent implements OnInit {
  categories$!: Observable<CategoryModel[]>;
  products$!: Observable<ProductModel[]>;
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
  }

  submit() {
    const category: number = this?.category?.value;
    this.store.dispatch(loadProductsByCategory({ payload: category }));
    this.products$ = this.store.select(selectProducts);
  }
}
