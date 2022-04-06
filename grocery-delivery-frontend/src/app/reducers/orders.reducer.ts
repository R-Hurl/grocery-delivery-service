import { Action, createReducer, on } from '@ngrx/store';
import * as actions from '../actions/checkout.actions';

export interface OrdersState {
  orderNumber: string;
}

const initialState: OrdersState = {
  orderNumber: '',
};

const reducerFunction = createReducer(
  initialState,
  on(actions.submitOrderSucceeded, (state, action) => {
    return { ...state, orderNumber: action.payload };
  })
);

export const reducer = (
  state: OrdersState = initialState,
  action: Action
): OrdersState => reducerFunction(state, action);
