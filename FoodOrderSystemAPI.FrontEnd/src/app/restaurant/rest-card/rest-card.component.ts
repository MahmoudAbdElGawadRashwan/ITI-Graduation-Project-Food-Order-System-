import { Component, Input } from '@angular/core';
import { FullProductCardDto } from 'src/app/_models/product/FullProductCardDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';

@Component({
  selector: 'app-rest-card',
  templateUrl: './rest-card.component.html',
  styleUrls: ['./rest-card.component.css']
})
export class RestCardComponent {
  @Input() product:FullProductCardDto = new FullProductCardDto();


  getRestaurantDetailsById(): void {
    
  }

    addToCart(){
      let cartListString = localStorage.getItem('cartList');

      if(cartListString === null){
        let cartList:FullProductCardDto[] = [];
        cartList.push(this.product)
        console.log(cartList);
        localStorage.setItem('cartList',JSON.stringify(cartList));
      }else{
        let cartList:FullProductCardDto[] = JSON.parse(cartListString);
        cartList.push(this.product)
        console.log(cartList);
        localStorage.setItem('cartList',JSON.stringify(cartList));
      }
    }
}