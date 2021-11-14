import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroceryCheckoutComponent } from './components/grocery-checkout/grocery-checkout.component';
import { GroceryShopComponent } from './components/grocery-shop/grocery-shop.component';

const routes: Routes = [
  { path: 'shop', component: GroceryShopComponent },
  { path: 'checkout', component: GroceryCheckoutComponent },
  { path: '**', component: GroceryShopComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
