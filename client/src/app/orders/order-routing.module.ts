import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule, Routes } from '@angular/router';
import { OrdersComponentComponent } from './orders-component.component';
import { OrderDetailedComponentComponent } from './order-detailed-component/order-detailed-component.component';

const routes: Routes = [
  { path: '', component: OrdersComponentComponent },
  {
    path: ':id',
    component: OrderDetailedComponentComponent,
    data: { breadcrumb: { alias: 'OrdersDetailed' } },
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrderRoutingModule {}
