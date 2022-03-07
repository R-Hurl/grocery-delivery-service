import { Action, createReducer, on } from '@ngrx/store';
import * as actions from '../actions/checkout.actions';

export interface OrderState {
  orderNumber: string;
}

const initialState: OrderState = {
  orderNumber: '',
};

const reducerFunction = createReducer(
  initialState,
  on(actions.submitOrderSucceeded, (state, action) => {
    return { ...state, orderNumber: action.payload };
  })
);

export const reducer = (
  state: OrderState = initialState,
  action: Action
): OrderState => reducerFunction(state, action);
