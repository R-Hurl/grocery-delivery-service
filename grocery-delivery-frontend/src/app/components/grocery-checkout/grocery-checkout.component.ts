import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import {
  AppState,
  selectCartEntities,
  selectCartTotal,
  selectItemsInCart,
} from 'src/app/reducers';
import { CartEntity } from '../../reducers/cart.reducer';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { removeFromCart, updateCartItem } from 'src/app/actions/cart.actions';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-grocery-checkout',
  templateUrl: './grocery-checkout.component.html',
  styleUrls: ['./grocery-checkout.component.css'],
})
export class GroceryCheckoutComponent implements OnInit {
  cart$!: Observable<CartEntity[]>;
  total$!: Observable<number>;
  faTrashAlt = faTrashAlt;
  checkoutForm = this.formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    address: this.formBuilder.group({
      street: ['', [Validators.required]],
      city: ['', [Validators.required]],
      state: ['', [Validators.required, Validators.maxLength(2)]],
      zip: ['', [Validators.required, Validators.maxLength(5)]],
    }),
  });
  checkoutFormError!: string | null;

  get firstName() {
    return this.checkoutForm.get('firstName');
  }
  get lastName() {
    return this.checkoutForm.get('lastName');
  }
  get street() {
    return this.checkoutForm.get(['address', 'street']);
  }
  get city() {
    return this.checkoutForm.get(['address', 'city']);
  }
  get state() {
    return this.checkoutForm.get(['address', 'state']);
  }
  get zip() {
    return this.checkoutForm.get(['address', 'zip']);
  }

  constructor(
    private store: Store<AppState>,
    private formBuilder: FormBuilder
  ) {}

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

  submit() {
    if (!this.checkoutForm.valid) {
      this.checkoutFormError = "Cannot submit order, please check all fields are supplied.";
    }
  }
}
