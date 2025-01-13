import {Component, inject, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {OrdersService} from '../../../data/services/orders.service';
import {Order} from '../../../data/interfaces/cart/order.interface';
import {NgIf} from '@angular/common';
import {OrderInfoTemplateComponent} from './components/order-info-template/order-info-template.component';

@Component({
  selector: 'app-order-info',
  imports: [
    NgIf,
    OrderInfoTemplateComponent
  ],
  templateUrl: './order-info.component.html',
  styleUrl: './order-info.component.css'
})
export class OrderInfoComponent implements OnInit {
  route = inject(ActivatedRoute);
  orderService = inject(OrdersService);
  order: Order | null = null;
  errorMessage: string | null = null;

  ngOnInit() {
    this.route.params.subscribe(params => {
      const orderId = params['id'];
      this.orderService.getOrderById(orderId)
        .subscribe({
        next: order => {
          this.order = order;
          this.errorMessage = null;
        },
        error: () => {
          this.order = null;
          this.errorMessage = 'Order not found. Please check the order ID and try again. If the problem persists, contact support.';
        }});
    })
  }
}
