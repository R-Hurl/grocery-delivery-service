import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroceryCheckoutComponent } from './components/grocery-checkout/grocery-checkout.component';
import { GroceryShopComponent } from './components/grocery-shop/grocery-shop.component';
import { OrderConfirmationComponent } from './components/order-confirmation/order-confirmation.component';
import { OrderDetailsComponent } from './components/order-details/order-details.component';
import { OrderHistoryComponent } from './components/order-history/order-history.component';

const routes: Routes = [
  { path: 'shop', component: GroceryShopComponent },
  { path: 'checkout', component: GroceryCheckoutComponent },
  { path: 'confirmation', component: OrderConfirmationComponent },
  { path: 'orders', component: OrderHistoryComponent },
  { path: 'orders:id', component: OrderDetailsComponent },
  { path: '**', component: GroceryShopComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
