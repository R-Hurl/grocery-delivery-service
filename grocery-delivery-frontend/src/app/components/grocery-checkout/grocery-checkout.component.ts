import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import {
  AppState,
  selectCartEntities,
  selectCartTotal,
} from 'src/app/reducers';
import { CartEntity } from '../../reducers/cart.reducer';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { removeFromCart, updateCartItem } from 'src/app/actions/cart.actions';

@Component({
  selector: 'app-grocery-checkout',
  templateUrl: './grocery-checkout.component.html',
  styleUrls: ['./grocery-checkout.component.css'],
})
export class GroceryCheckoutComponent implements OnInit {
  cart$!: Observable<CartEntity[]>;
  total$!: Observable<number>;
  faTrashAlt = faTrashAlt;

  constructor(private store: Store<AppState>) {}

  ngOnInit(): void {
    this.cart$ = this.store.select(selectCartEntities);
    this.total$ = this.store.select(selectCartTotal);
  }

  removeFromCart(cartItem: CartEntity) {
    this.store.dispatch(removeFromCart({ payload: cartItem }));
  }

  updateItemInCart(item: CartEntity, quantity: string) {
    const payload = {
      cartItemBeforeUpdate: {
        ...item,
      },
      updatedCartItem: {
        id: item.id,
        item: {
          ...item.item,
          quantity: Number(quantity),
        },
      },
    };

    this.store.dispatch(updateCartItem({ payload }));
  }
}
