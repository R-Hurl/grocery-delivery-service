import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroceryCheckoutComponent } from './grocery-checkout.component';

describe('GroceryCheckoutComponent', () => {
  let component: GroceryCheckoutComponent;
  let fixture: ComponentFixture<GroceryCheckoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GroceryCheckoutComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GroceryCheckoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
