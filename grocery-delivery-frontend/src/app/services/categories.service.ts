import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface Category {
  id: number;
  categoryName: string;
}

@Injectable()
export class CategoriesService {
  constructor(private httpClient: HttpClient) {}

  getCategories() {
    this.httpClient.get<Category[]>('https://localhost:5001/api/Categories');
  }
}
