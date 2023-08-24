import { Component, DoCheck, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CartItem } from 'src/app/_models/cartItem/CartItem';
import { AuthentcationService } from 'src/app/services/authentcation.service';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';
import { FullProduct } from 'src/app/types/Product/full-product-dto';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent implements OnInit, DoCheck {
  Logged:boolean=false;
  product: FullProduct = new FullProduct();
  productRating: number = 0;
  productCategory: string = '';
  sizesOptions: any[] = [
    { label: 'Small', value: 'small' },
    { label: 'Medium', value: 'medium' },
    { label: 'Large', value: 'large' },
  ];
  selectedSizeIndex: number = 0;
  uiSizeValue: string = 'small';
  productQuantity: number = 1;
  constructor(
    private activeRoute: ActivatedRoute,
    private productService: ProductService,
    public cartService: CartService,
    private activatedRoute: ActivatedRoute,
    private authentcationService:AuthentcationService
  ) {}
  ngOnInit(): void {
    this.getProduct();

    console.log(`rating: ${this.productRating}`);
  }
  ngDoCheck(): void {
    if (this.product != null) {
      this.productRating = this.product.rate;
      this.productCategory = this.product.type;
    }
  }

  getProduct() {
    let urlProductId = this.activeRoute.snapshot.paramMap.get('id');
    console.log(urlProductId)
    if (urlProductId) {
      let productId = parseInt(urlProductId);
      this.productService.getProduct(productId).subscribe(
        (data) => {
          this.product = data;
        },
        (error) => {
          console.log(`error: ${error}`);
        }
      );
    }
  }

  addToCart(): void {
    let newCartItem: CartItem;
    newCartItem = new CartItem(this.product, this.productQuantity);
    this.cartService.addToCart(newCartItem);
  }

  checkUser(){
    let urlRestaurantId = this.activatedRoute.snapshot.paramMap.get('id');
    if (urlRestaurantId) {
      let restaurantId = parseInt(urlRestaurantId);
      this.Logged=(this.authentcationService.UserLogin?.id==restaurantId)&&(this.authentcationService.UserLogin?.Role=="Restaurant")
    }
    return this.Logged
  }
}
