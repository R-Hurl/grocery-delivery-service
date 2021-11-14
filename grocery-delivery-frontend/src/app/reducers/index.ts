import { ActionReducerMap, createSelector } from '@ngrx/store';
import { CategoryModel, ProductModel } from '../models';
import * as fromCategories from './categories.reducer';
import * as fromProducts from './products.reducer';
import * as fromCart from './cart.reducer';

export interface AppState {
  categories: fromCategories.CategoriesState;
  products: fromProducts.ProductsState;
  cart: fromCart.CartState;
}

export const reducers: ActionReducerMap<AppState> = {
  categories: fromCategories.reducer,
  products: fromProducts.reducer,
  cart: fromCart.reducer,
};

// Categories
const selectCategoriesBranch = (state: AppState) => state.categories;

const { selectAll: selectCategoriesEntityArray } =
  fromCategories.adapter.getSelectors(selectCategoriesBranch);

export const selectCategories = createSelector(
  selectCategoriesEntityArray,
  (categories) =>
    categories.map((category) => {
      return {
        ...category,
      } as CategoryModel;
    })
);

// Products
const selectProductsBranch = (state: AppState) => state.products;

const { selectAll: selectAllProductsEntityArray } =
  fromProducts.adapter.getSelectors(selectProductsBranch);

export const selectProducts = createSelector(
  selectAllProductsEntityArray,
  (products) =>
    products.map((product) => {
      return {
        ...product,
      } as ProductModel;
    })
);

export const selectIsProductsLoading = createSelector(
  selectProductsBranch,
  (productsBranch) => productsBranch.isProductsLoading
);

export const selectProductsBySearchTerm = (props: { searchTerm: string }) =>
  createSelector(selectAllProductsEntityArray, (products) =>
    products.filter(
      (product) =>
        product.name.toLowerCase().indexOf(props.searchTerm.toLowerCase()) !==
        -1
    )
  );

// Cart
const selectCartBranch = (state: AppState) => state.cart;

const {
  selectAll: selectAllCartEntityArray,
  selectTotal: selectTotalItemsInCart,
} = fromCart.adapter.getSelectors(selectCartBranch);

export const selectNumberOfItemsInCart = createSelector(
  selectTotalItemsInCart,
  (numberOfItems) => numberOfItems
);

export const selectItemsInCart = createSelector(
  selectAllCartEntityArray,
  (cart) => cart.map((cartItem) => cartItem.item)
);
