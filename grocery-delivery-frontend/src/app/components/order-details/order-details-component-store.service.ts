import { Injectable } from '@angular/core';
import { ComponentStore } from '@ngrx/component-store';
import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { OrdersService } from 'src/app/services/orders.service';

export interface ProductDetails {
  name: string;
  price: number;
}

export interface OrderDetailsEntity {
  product: ProductDetails;
  quantity: number;
}

interface OrderDetailsState extends EntityState<OrderDetailsEntity> {}

const adapter = createEntityAdapter<OrderDetailsEntity>();

const initialState = adapter.getInitialState();

const { selectAll: selectAllOrderDetails } = adapter.getSelectors();

@Injectable()
export class OrderDetailsComponentStore extends ComponentStore<OrderDetailsState> {
  constructor(private ordersService: OrdersService) {
    super(initialState);
  }

  /**
   * Selectors
   */

  readonly selectOrderDetails$: Observable<OrderDetailsEntity[]> = this.select(
    selectAllOrderDetails
  );

  /**
   * Updaters (reducers equivalent)
   */

  readonly setOrderDetails = this.updater(
    (state: OrderDetailsState, orderDetails: OrderDetailsEntity[]) => {
      return adapter.setAll(orderDetails, state);
    }
  );

  /**
   * Effects
   */

  readonly fetchOrderDetails = this.effect((orderId$: Observable<string>) =>
    orderId$.pipe(
      switchMap((orderId) => {
        return this.ordersService.getOrderItems(orderId).pipe(
          map((response) => {
            const orderDetailsEntities: OrderDetailsEntity[] =
              response as OrderDetailsEntity[];
            this.setOrderDetails(orderDetailsEntities);
          })
        );
      })
    )
  );

  /**
   * Helpers
   */

  getOrderDetails(): Observable<OrderDetailsEntity[]> {
    return this.selectOrderDetails$;
  }
}
