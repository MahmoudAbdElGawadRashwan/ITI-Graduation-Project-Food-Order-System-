//#region imports
import { Injectable, OnInit } from '@angular/core';
import { CartItem } from '../_models/cartItem/CartItem';

//#endregion

@Injectable({
  providedIn: 'root',
})
export class CartService {
  //#region  feilds
  private _localStorageCartName: string = 'Cart';

  public CartItems: CartItem[] = [];
  public TotalNumberOfItems: number = 0;
  public TotalPrice: number = 0;
  //#endregion

  constructor() {
    //#region filling CartItems
    this.CartItems = [];
    let cartItemsString = localStorage.getItem(this._localStorageCartName);
    if (cartItemsString !== null) {
      this.CartItems = JSON.parse(cartItemsString);
    }
    console.log(`added from localStorage: ${this.CartItems}`);
    //#endregion

    //#region filling NumberOfItems
    this.TotalNumberOfItems = this.calculateTotalNumberOfItems();
    //#endregion
    console.log(`calculated #items: ${this.TotalNumberOfItems}`);

    //#region filling TotalPrice
    this.TotalPrice = this.calculateTotalPrice();
    console.log(`calculated totalprice: ${this.TotalPrice}`);

    //#endregion
  }

  //#region private methods
  private calculateTotalNumberOfItems(): number {
    let count = 0;
    this.CartItems.forEach((item) => {
      count += item.quantity;
    });
    return count;
  }

  private calculateTotalPrice(): number {
    let totalPrice = 0;
    for (let index = 0; index < this.CartItems.length; index++) {
      totalPrice +=
        this.CartItems[index].product.price * this.CartItems[index].quantity;
    }
    return totalPrice;
  }
  //#endregion

  //#region  public methods
  addToCart(newCartItem: CartItem) {
    let cartItems: CartItem[] = [];
    let cartItemsString = localStorage.getItem(this._localStorageCartName);
    if (cartItemsString !== null) {
      cartItems = JSON.parse(cartItemsString);
    }
    cartItems.push(newCartItem);
    localStorage.setItem(this._localStorageCartName, JSON.stringify(cartItems));
    this.CartItems = cartItems;
    this.TotalNumberOfItems += newCartItem.quantity;
    this.TotalPrice += newCartItem.product.price * newCartItem.quantity;
  }

  removeFromCart(cartItemToRemove: CartItem) {
    let cartItems: CartItem[] = [];
    let cartItemsString = localStorage.getItem(this._localStorageCartName);
    if (cartItemsString !== null) {
      cartItems = JSON.parse(cartItemsString);
    }
    for (let index = 0; index < cartItems.length; index++) {
      if (
        cartItems[index].product.productID == cartItemToRemove.product.productID
      ) {
        cartItems.splice(index, 1);
        break;
      }
    }
    localStorage.setItem(this._localStorageCartName, JSON.stringify(cartItems));
    this.CartItems = cartItems;
    this.TotalNumberOfItems -= cartItemToRemove.quantity;
    this.TotalPrice -=
      cartItemToRemove.product.price * cartItemToRemove.quantity;
  }

  emptyCart(): void {
    localStorage.removeItem(this._localStorageCartName);
    this.CartItems = [];
    this.TotalNumberOfItems = 0;
    this.TotalPrice = 0;
  }
  //#endregion
}
