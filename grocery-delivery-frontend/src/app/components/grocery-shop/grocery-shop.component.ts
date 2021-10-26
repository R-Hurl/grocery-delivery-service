import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Store } from '@ngrx/store';
import { loadCategories } from 'src/app/actions/categories.actions';
import { AppState } from 'src/app/reducers';

@Component({
  selector: 'app-grocery-shop',
  templateUrl: './grocery-shop.component.html',
  styleUrls: ['./grocery-shop.component.css'],
})
export class GroceryShopComponent implements OnInit {
  form = this.formBuilder.group({
    category: [0],
    productSearch: [''],
  });
  constructor(
    private formBuilder: FormBuilder,
    private store: Store<AppState>
  ) {
    this.store.dispatch(loadCategories());
  }

  ngOnInit(): void {}

  submit() {}
}
