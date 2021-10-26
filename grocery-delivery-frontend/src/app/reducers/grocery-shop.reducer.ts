import { EntityState } from '@ngrx/entity';

export interface CategoryEntity {
  id: number;
  categoryName: string;
}

export interface GroceryShopState extends EntityState<CategoryEntity> {}
