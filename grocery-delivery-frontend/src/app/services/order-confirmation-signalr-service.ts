import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

@Injectable({ providedIn: 'root' })
export default class OrderConfirmationSignalRService {
  private hubConnection!: HubConnection;
  orderConfirmationReceived = new EventEmitter<string>();

  constructor() {
    this.buildConnection();
    this.startConnection();
  }

  private buildConnection = () => {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('http://localhost:5001/orderconfirmation')
      .build();
  };

  private startConnection = () => {
    this.hubConnection
      .start()
      .then(() => {
        console.log('SignalR Connected!');
        this.registerSignalREvents();
      })
      .catch((err) => {
        console.error(err);
      });
  };

  private registerSignalREvents() {
    this.hubConnection.on('OrderConfirmationMessage', (data: string) => {
      console.log('SignalR message received', data);
      this.orderConfirmationReceived.emit(data);
    });
  }
}
