import { Component, Input } from '@angular/core';
import { CartItem } from 'src/app/_models/cartItem/CartItem';
import { FullProductCardDto } from 'src/app/_models/product/FullProductCardDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';
import { CartService } from 'src/app/services/cart.service';
import { FullProduct } from 'src/app/types/Product/full-product-dto';
import { RestaurantDetailsDto } from 'src/app/types/Restaurant/Restaurants-Read-dto';

@Component({
  selector: 'app-home-card',
  templateUrl: './home-card.component.html',
  styleUrls: ['./home-card.component.css']
})
export class HomeCardComponent {
  @Input() product:FullProductCardDto = new FullProductCardDto(
    0,"",10,"","https://www.pngkey.com/png/detail/233-2332677_image-500580-placeholder-transparent.png",0,0,[],0,""
  );

  constructor(private cartService:CartService){}

  addToCart(): void {
    let newCartItem: CartItem;
    let fullProduct:FullProduct = new FullProduct (
      this.product.productID,
      this.product.productname,
      this.product.price,
      this.product.describtion,
      this.product.img,
      this.product.offer,
      this.product.rate,
      this.product.tags,
      this.product.tags[0],
      new RestaurantDetailsDto(this.product.restaurantID,this.product.restaurantName), 
      )
    newCartItem = new CartItem(fullProduct, 1);
    this.cartService.addToCart(newCartItem);
  }
}
