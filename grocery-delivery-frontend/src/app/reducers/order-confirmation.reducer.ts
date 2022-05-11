import { Action, createReducer, on } from '@ngrx/store';
import * as actions from '../actions/order-confirmation.actions';

export interface OrderConfirmationState {
  messages: string[];
}

const initialState: OrderConfirmationState = {
  messages: [],
};

const reducerFunction = createReducer(
  initialState,
  on(actions.addOrderConfirmationMessage, (state, action) => ({
    messages: [...state.messages, action.payload],
  }))
);

export const reducer = (
  state: OrderConfirmationState = initialState,
  action: Action
): OrderConfirmationState => reducerFunction(state, action);
