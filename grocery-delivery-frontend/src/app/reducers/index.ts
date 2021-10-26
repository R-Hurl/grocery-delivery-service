import { ActionReducerMap } from '@ngrx/store';
import * as fromGroceryShop from './grocery-shop.reducer';

export interface AppState {
  shop: fromGroceryShop.GroceryShopState;
}

export const reducers: ActionReducerMap<AppState> = {
  shop: fromGroceryShop.reducer,
};
