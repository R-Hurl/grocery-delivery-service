export interface CategoryModel {
  id: number;
  categoryName: string;
}

export interface ProductModel {
  id: number;
  categoryId: number;
  name: string;
  description: string;
}

export interface AddToCartModel {
  product: ProductModel;
  quantity: number;
}
