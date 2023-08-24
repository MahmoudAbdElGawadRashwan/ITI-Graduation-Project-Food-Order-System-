import { Component, OnInit } from '@angular/core';
import { AddCardComponent } from '../AddCard/add-card.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
  ValidationErrors,
} from '@angular/forms';
import { Router } from '@angular/router';
import { CartService } from '../services/cart.service';
import { AuthentcationService } from '../services/authentcation.service';
import { FullProduct } from 'src/app/types/Product/full-product-dto';
import { FormControl, ValidatorFn } from '@angular/forms';
import { AddOrderDTO, OrderProduct } from '../types/Order/add-order-dto';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../services/config.service';

function nameValidator(control: AbstractControl): ValidationErrors | null {
  const name = control.value;

  if (name && (name.length < 3 || /\d/.test(name))) {
    return { invalidName: true };
  }

  return null;
}

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent implements OnInit {
  checkoutForm: FormGroup;
  errorMessage: string = '';

  selectedPaymentMethod: string = 'creditDebitCard';
  selectedCard: any = null;
  cards: any[] = []; // Array to store the added cards
  maxCards: number = 2;
  isProceedEnabled: boolean = false;

  email: string = '';
  shippingAddress: string = '';
  firstName: string = '';
  lastName: string = '';
  address: string = '';
  phone: string = '';

  constructor(
    private modalService: NgbModal,
    private formBuilder: FormBuilder,
    private router: Router,
    public cartService: CartService,
    private authService: AuthentcationService,
    private http: HttpClient,
    private configService: ConfigService
  ) {
    this.checkoutForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      sendUpdates: [false],
      shippingAddress: ['', Validators.required],
      firstName: ['', [Validators.required, nameValidator]],
      lastName: ['', [Validators.required, nameValidator]],
      address: ['', Validators.required],
      phone: ['', [Validators.required, Validators.pattern(/^01[0-9]{9}$/)]],
    });
  }

  PostOrder(): void {
    this.checkoutForm.markAllAsTouched();
    if (this.selectedCard) {
      // Proceed with the checkout using the selectedCard
    }
    // Disable the "Proceed" button only for the "cashOnDelivery" payment method
    this.isProceedEnabled = this.selectedPaymentMethod !== 'cashOnDelivery';

    // Get the user ID from the authentication service
    const CustomerClaims: number | undefined = this.authService.UserLogin?.id;

    const cartItems = this.cartService.CartItems;
    const totalPrice = this.cartService.TotalPrice;

    let PostOrderProdcuts: OrderProduct[] = [];

    for (const cartItem of cartItems) {
      let NewItem = new OrderProduct(
        cartItem.product.productID,
        cartItem.quantity
      );
      console.log(`NewItem: ------------------------------`);
      console.log(NewItem);
      PostOrderProdcuts.push(NewItem);
    }

    const currentDateTime: string = new Date().toISOString();

    // Create the order object
    let order = new AddOrderDTO(
      CustomerClaims,
      totalPrice,
      currentDateTime,
      PostOrderProdcuts
    );

    this.http
      .post(this.configService.getBaseApiUrl() + 'orders', order)
      .subscribe(
        (response) => {
          this.cartService.emptyCart();
          console.log(response);
        },
        (error) => {
          console.error(error);
        }
      );

      this.router.navigate(['/orderconfirmation']);
  }

  ngOnInit(): void {
    let cartItems = this.cartService.CartItems;
    cartItems.forEach((element) => {
      this.productsList?.push(element.product);
    });
  }

  productsList: FullProduct[] | null = [];

  calculateTotal(): number {
    let total = 0;

    if (this.productsList) {
      for (const product of this.productsList) {
        total += product.price;
      }
    }

    return total;
  }

  returnToCart(): void {
    // Use the router to navigate to the cart page
    this.router.navigate(['/cart']); // Replace '/cart' with the actual URL of your cart page
  }

  // Accessor for easy access to form controls
  get formControls() {
    return this.checkoutForm.controls;
  }

  toggleCardSelection(card: any): void {
    if (this.selectedCard === card) {
      this.selectedCard = null;
      this.isProceedEnabled = false;
    } else {
      this.selectedCard = card;
      this.isProceedEnabled = true;
    }
  }

  openAddCardModal() {
    const modalRef = this.modalService.open(AddCardComponent);
    modalRef.componentInstance.cardSaved.subscribe((newCard: any) => {
      this.cards.push(newCard);
    });
    modalRef.componentInstance.cardDeleted.subscribe((deletedCard: any) => {
      this.cards = this.cards.filter((card) => card !== deletedCard);
    });
    modalRef.componentInstance.cardEdited.subscribe((editedCard: any) => {
      // Handle card editing logic
    });
  }

  deleteCard(card: any) {
    const index = this.cards.indexOf(card);
    if (index !== -1) {
      this.cards.splice(index, 1);
      if (this.selectedCard === card) {
        this.selectedCard = null;
      }
    }
  }

  editCard(card: any) {
    // Open the edit card modal
    const modalRef = this.modalService.open(AddCardComponent);
    modalRef.componentInstance.card = card; // Pass the card to the modal

    // Subscribe to the cardSaved event emitted by the modal
    modalRef.componentInstance.cardSaved.subscribe((updatedCard: any) => {
      // Update the card in the cards array
      const index = this.cards.indexOf(card);
      if (index !== -1) {
        this.cards[index] = updatedCard;
      }
    });
  }

  formatExpiryDate(month: string, year: string): string {
    if (month && year) {
      return `Exp: ${month}/${year.substring(2, 4)}`;
    }
    return '';
  }

  isVisaCard(cardNumber: string): boolean {
    // Check if the card number starts with 4 (Visa)
    return cardNumber.startsWith('4');
  }

  isMasterCard(cardNumber: string): boolean {
    // Check if the card number starts with 5 (MasterCard)
    return cardNumber.startsWith('5');
  }

  getCardLastFourDigits(cardNumber: string): string {
    // Get the last four digits of the card number
    return cardNumber.substr(cardNumber.length - 4);
  }

  resetForm(): void {
    this.checkoutForm.reset();
    this.checkoutForm.markAsUntouched();
    this.checkoutForm.clearValidators();
    this.checkoutForm.updateValueAndValidity();
  }

  // proceedToCheckout(): void {
  //   this.checkoutForm.markAllAsTouched();
  //   if (this.selectedCard) {
  //     // Proceed with the checkout using the selectedCard
  //   }
  //   // Disable the "Proceed" button only for the "cashOnDelivery" payment method
  //   this.isProceedEnabled = this.selectedPaymentMethod !== 'cashOnDelivery';
  // }

  handlePaymentMethodChange(event: any) {
    this.selectedPaymentMethod = event.target.value;
    this.isProceedEnabled = this.selectedPaymentMethod === 'cashOnDelivery';
    // Reset the form when the payment method changes
    this.resetForm();
  }

  onSubmit() {
    // const formData = {
    //   firstName: this.firstName,
    //   lastName: this.lastName,
    //   // Add other form fields here
    // };
    // // Call the submitForm method from the CheckoutService
    // this.checkoutService.submitForm(formData)
    //   .subscribe(
    //     response => {
    //       console.log('Form submitted successfully!', response);
    //       // Optionally, perform any additional actions after successful submission
    //     },
    //     error => {
    //       console.error('Error submitting form:', error);
    //       // Handle any errors that occur during submission
    //     }
    //   );
  }
}
