import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { GroceryShopComponent } from './components/grocery-shop/grocery-shop.component';
import { reducers } from './reducers';
import { EffectsModule } from '@ngrx/effects';
import { GroceryShopEffects } from './effects/grocery-shop.effects';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CartDropdownComponent } from './components/cart-dropdown/cart-dropdown.component';
import { GroceryCheckoutComponent } from './components/grocery-checkout/grocery-checkout.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { GroceryCheckoutEffects } from './effects/grocery-checkout.effects';

@NgModule({
  declarations: [
    AppComponent,
    GroceryShopComponent,
    NavbarComponent,
    CartDropdownComponent,
    GroceryCheckoutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    StoreModule.forRoot(reducers),
    StoreDevtoolsModule.instrument(),
    HttpClientModule,
    EffectsModule.forRoot([GroceryShopEffects, GroceryCheckoutEffects]),
    FontAwesomeModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
