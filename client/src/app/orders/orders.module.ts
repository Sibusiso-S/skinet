import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponentComponent } from './orders-component.component';
import { OrderDetailedComponentComponent } from './order-detailed-component/order-detailed-component.component';



@NgModule({
  declarations: [
    OrdersComponentComponent,
    OrderDetailedComponentComponent
  ],
  imports: [
    CommonModule
  ]
})
export class OrdersModule { }
