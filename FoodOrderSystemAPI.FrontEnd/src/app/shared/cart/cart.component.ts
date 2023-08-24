import { Component } from '@angular/core';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  visible: boolean = false;
  position: string = 'center';

  constructor(public cartService: CartService) {}

  showDialog(position: string) {
    this.position = position;
    this.visible = true;
  }

  isCartEmpty(): boolean {
    return this.cartService.CartItems.length === 0;
  }
  
}
