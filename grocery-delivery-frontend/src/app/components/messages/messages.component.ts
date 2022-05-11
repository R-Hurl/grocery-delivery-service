import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState, selectOrderConfirmationMessages } from 'src/app/reducers';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css'],
})
export class MessagesComponent implements OnInit {
  messages$!: Observable<string[]>;

  constructor(private store: Store<AppState>) {}

  ngOnInit(): void {
    this.messages$ = this.store.select(selectOrderConfirmationMessages);
  }
}
