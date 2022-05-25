import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'orderStatus' })
export class OrderStatusPipe implements PipeTransform {
  private readonly ORDER_STATUS_PENDING: string = 'P';
  private readonly ORDER_STATUS_DELIVERED: string = 'D';

  transform(value: string | undefined): string {
    switch (value) {
      case this.ORDER_STATUS_PENDING:
        return 'Pending';
      case this.ORDER_STATUS_DELIVERED:
        return 'Delivered';
      default:
        return '';
    }
  }
}
