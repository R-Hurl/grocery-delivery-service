import { Injectable } from '@angular/core';
import { ComponentStore } from '@ngrx/component-store';
import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { OrdersService } from '../../services/orders.service';

export interface OrderEntity {
  orderId: string;
  orderStatus: string;
  total: number;
}

export interface OrdersState extends EntityState<OrderEntity> {}

export const adapter = createEntityAdapter<OrderEntity>({
  selectId: (order) => order.orderId,
});

const initialState = adapter.getInitialState();

const { selectAll: selectAllOrdersArray } = adapter.getSelectors();

@Injectable()
export class OrderHistoryComponentStore extends ComponentStore<OrdersState> {
  constructor(private ordersService: OrdersService) {
    super(initialState);
  }

  /**
   * Selectors
   */

  readonly selectOrders$: Observable<OrderEntity[]> =
    this.select(selectAllOrdersArray);

  /**
   * Updaters
   */

  readonly setOrders = this.updater(
    (state: OrdersState, ordersToAdd: OrderEntity[]) => {
      return adapter.setAll(ordersToAdd, state);
    }
  );

  /**
   * Effects
   */

  readonly loadOrders = this.effect((origin$: Observable<void>) =>
    origin$.pipe(
      switchMap(() => {
        return this.ordersService.getOrders().pipe(
          map((response) => {
            const orderEntities: OrderEntity[] = response as OrderEntity[];
            this.setOrders(orderEntities);
          })
        );
      })
    )
  );
}
