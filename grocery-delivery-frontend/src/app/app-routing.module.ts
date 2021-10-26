import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroceryShopComponent } from './components/grocery-shop/grocery-shop.component';

const routes: Routes = [
  { path: 'shop', component: GroceryShopComponent },
  { path: '**', component: GroceryShopComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
