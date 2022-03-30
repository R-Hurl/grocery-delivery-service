import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Action, createReducer, on } from '@ngrx/store';
import * as actions from '../actions/checkout.actions';
import * as orderActions from '../actions/orders.actions';
import { OrderItem } from '../services/orders.service';

export interface OrderEntity {
  orderId: string;
  orderStatus: string;
  total: number;
  orderItems: OrderItem[];
}

export interface OrdersState extends EntityState<OrderEntity> {
  orderNumber: string;
}

export const adapter = createEntityAdapter<OrderEntity>({
  selectId: (order) => order.orderId,
});

const initialState = adapter.getInitialState({
  orderNumber: '',
});

const reducerFunction = createReducer(
  initialState,
  on(actions.submitOrderSucceeded, (state, action) => {
    return { ...state, orderNumber: action.payload };
  }),
  on(orderActions.getOrderHistorySucceeded, (state, action) => {
    return adapter.setAll(action.payload, state);
  })
);

export const reducer = (
  state: OrdersState = initialState,
  action: Action
): OrdersState => reducerFunction(state, action);
