import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import {
  AppState,
  selectCartEntities,
  selectCartTotal,
  selectNumberOfItemsInCart,
} from 'src/app/reducers';
import { CartEntity } from '../../reducers/cart.reducer';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import {
  removeFromCart,
  resetCart,
  updateCartItem,
} from 'src/app/actions/cart.actions';
import { FormBuilder, Validators } from '@angular/forms';
import { take } from 'rxjs/operators';
import { AddToCartModel, SubmitOrderModel } from 'src/app/models';
import { submitOrder } from 'src/app/actions/checkout.actions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-grocery-checkout',
  templateUrl: './grocery-checkout.component.html',
  styleUrls: ['./grocery-checkout.component.css'],
})
export class GroceryCheckoutComponent implements OnInit {
  cart$!: Observable<CartEntity[]>;
  total$!: Observable<number>;
  numberOfItemsInCart$!: Observable<number>;
  faTrashAlt = faTrashAlt;
  checkoutForm = this.formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    address: this.formBuilder.group({
      street: ['', [Validators.required]],
      city: ['', [Validators.required]],
      state: ['', [Validators.required, Validators.maxLength(2)]],
      zipCode: ['', [Validators.required, Validators.maxLength(5)]],
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
  get zipCode() {
    return this.checkoutForm.get(['address', 'zipCode']);
  }

  constructor(
    private store: Store<AppState>,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.cart$ = this.store.select(selectCartEntities);
    this.total$ = this.store.select(selectCartTotal);
    this.numberOfItemsInCart$ = this.store.select(selectNumberOfItemsInCart);
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
    let numberOfCartItems: number = 0;
    this.numberOfItemsInCart$
      .pipe(take(1))
      .subscribe((num) => (numberOfCartItems = num));

    if (!this.checkoutForm.valid) {
      this.checkoutFormError =
        'Cannot submit order, please check all fields are supplied.';
      return;
    }

    if (numberOfCartItems <= 0) {
      this.checkoutFormError =
        'Cannot submit order, no items have been added to the cart';
      return;
    }

    let cartItems: AddToCartModel[] = [];
    this.cart$.pipe().subscribe((cartEntity) => {
      let items = cartEntity.map((cartItem) => cartItem.item);
      cartItems = items;
    });

    let total: number = 0;
    this.total$.pipe().subscribe((cartTotal) => (total = cartTotal));

    const payload: SubmitOrderModel = {
      ...this.checkoutForm.value,
      cart: cartItems,
      total,
    };

    this.store.dispatch(submitOrder({ payload }));
    this.router.navigate(['/confirmation']);
    this.checkoutForm.reset();
    this.store.dispatch(resetCart());
  }
}
