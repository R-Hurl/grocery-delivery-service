import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface Product {
  id: number;
  categoryId: number;
  name: string;
  description: string;
}

@Injectable({ providedIn: 'root' })
export class ProductsService {
  constructor(private httpClient: HttpClient) {}

  getProductsByCategoryId(categoryId: number) {
    return this.httpClient.get<Product[]>(
      `https://localhost:5001/api/products/category/${categoryId}`
    );
  }
}
