import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AddToCartModel } from 'src/app/models';
import {
  AppState,
  selectItemsInCart,
  selectNumberOfItemsInCart,
} from 'src/app/reducers';

@Component({
  selector: 'app-cart-dropdown',
  templateUrl: './cart-dropdown.component.html',
  styleUrls: ['./cart-dropdown.component.css'],
})
export class CartDropdownComponent implements OnInit {
  numberOfCartItems$!: Observable<number>;
  cart$!: Observable<AddToCartModel[]>;

  constructor(private store: Store<AppState>) {}

  ngOnInit(): void {
    this.numberOfCartItems$ = this.store.select(selectNumberOfItemsInCart);
    this.cart$ = this.store.select(selectItemsInCart);
  }
}
