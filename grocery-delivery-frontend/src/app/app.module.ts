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

@NgModule({
  declarations: [AppComponent, GroceryShopComponent, NavbarComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    StoreModule.forRoot(reducers),
    StoreDevtoolsModule.instrument(),
    HttpClientModule,
    EffectsModule.forRoot([GroceryShopEffects]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
