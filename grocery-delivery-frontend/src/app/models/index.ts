export interface CategoryModel {
  id: number;
  categoryName: string;
}

export interface ProductModel {
  id: number;
  categoryId: number;
  name: string;
  description: string;
  price: number;
}

export interface AddToCartModel {
  product: ProductModel;
  quantity: number;
}

export interface AddressModel {
  street: string,
  city: string,
  state: string,
  zip: string
}

export interface SubmitOrderModel {
  firstName: string,
  lastName: string,
  address: AddressModel,
  cart: AddToCartModel[],
  total: number
}
