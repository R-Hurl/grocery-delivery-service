import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Category {
  id: number;
  categoryName: string;
}

@Injectable({ providedIn: 'root' })
export class CategoriesService {
  constructor(private httpClient: HttpClient) {}

  getCategories(): Observable<Category[]> {
    return this.httpClient.get<Category[]>(
      'http://localhost:5000/api/Categories'
    );
  }
}
