import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-grocery-shop',
  templateUrl: './grocery-shop.component.html',
  styleUrls: ['./grocery-shop.component.css'],
})
export class GroceryShopComponent implements OnInit {
  form = this.formBuilder.group({
    category: [0],
    productSearch: [''],
  });
  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {}

  submit() {}
}
