import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { loadCategories } from 'src/app/actions/categories.actions';
import { CategoryModel } from 'src/app/models';
import { AppState, selectCategories } from 'src/app/reducers';

@Component({
  selector: 'app-grocery-shop',
  templateUrl: './grocery-shop.component.html',
  styleUrls: ['./grocery-shop.component.css'],
})
export class GroceryShopComponent implements OnInit {
  categories$!: Observable<CategoryModel[]>;
  form = this.formBuilder.group({
    category: [1],
    productSearch: [''],
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
    console.log(this?.category?.value);
  }
}
