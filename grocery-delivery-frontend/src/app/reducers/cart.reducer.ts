import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Action, createReducer, on } from '@ngrx/store';
import { AddToCartModel } from '../models';
import * as actions from '../actions/cart.actions';

export interface CartEntity {
  id: number;
  item: AddToCartModel;
}

export interface CartState extends EntityState<CartEntity> {
  total: number;
}

export const adapter = createEntityAdapter<CartEntity>();

const initialState = adapter.getInitialState({
  total: 0,
});

const reducerFunction = createReducer(
  initialState,
  on(actions.addToCart, (state, action) =>
    adapter.addOne(
      { id: state.ids.length + 1, item: action.payload },
      {
        ...state,
        total:
          state.total + action.payload.product.price * action.payload.quantity,
      }
    )
  ),
  on(actions.removeFromCart, (state, { payload }) =>
    adapter.removeOne(payload.id, {
      ...state,
      total: state.total - payload.item.product.price * payload.item.quantity,
    })
  )
);

export const reducer = (
  state: CartState = initialState,
  action: Action
): CartState => reducerFunction(state, action);
