import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';


function cardNumberValidator(control: AbstractControl): ValidationErrors | null {
  const cardNumber = control.value;

  if (cardNumber && cardNumber.length !== 16) {
    return { invalidCardNumber: true };
  }
  return null;
}

function cardNameValidator(control: AbstractControl): ValidationErrors | null {
  const cardName = control.value;
  if (cardName && (cardName.length < 4 || !/^[a-zA-Z]+$/.test(cardName))) {
    return { invalidCardName: true };
  }
  return null;
}


@Component({
  selector: 'app-add-card',
  templateUrl: './add-card.component.html',
  styleUrls: ['./add-card.component.css']
})
export class AddCardComponent implements OnInit {
  @Output() cardSaved: EventEmitter<any> = new EventEmitter<any>();

  cardForm!: FormGroup;

  constructor(public formBuilder: FormBuilder, public activeModal: NgbActiveModal) {
    this.cardForm = this.formBuilder.group({
      cardNumber: ['', [Validators.required, cardNumberValidator]],
      cardName: ['', [Validators.required, cardNameValidator]],
      expiryMonth: ['', Validators.required],
      expiryYear: ['', Validators.required],
      cvv: ['', Validators.required]
    });
  }

  
  get formControls() {
    return this.cardForm.controls;
  }

  onCardNumberInput(event: Event): void {
    const input = event.target as HTMLInputElement;
    let value = input.value.replace(/\D/g, ''); // Remove non-numeric characters
    value = value.slice(0, 16); // Limit to 16 digits
    this.cardForm.get('cardNumber')?.setValue(value);
  }

  ngOnInit(): void {
    this.cardForm = this.formBuilder.group({
      cardNumber: ['', Validators.required],
      cardName: ['', Validators.required],
      expiryMonth: ['', Validators.required],
      expiryYear: ['', Validators.required],
      cvv: ['', Validators.required]
    });
  }
  



  saveCard(): void {
    if (this.cardForm.valid && this.validateCardNumber()) {
      const newCard = {
        cardNumber: this.cardForm.value.cardNumber,
        cardName: this.cardForm.value.cardName,
        expiryMonth: this.cardForm.value.expiryMonth,
        expiryYear: this.cardForm.value.expiryYear,
        cvv: this.cardForm.value.cvv
      };
      this.cardSaved.emit(newCard);
      this.activeModal.close();
    } else {
      // Display an error message or handle invalid card input
    }
  }



  validateCardNumber(): boolean {
    const cardNumber = this.cardForm.value.cardNumber;
    // Perform validation checks here
    // Example: Check if the card number has 16 digits and starts with 4 or 5
    const regex = /^(4|5)\d{15}$/;
    return regex.test(cardNumber);
  }
  
  




  onSubmit(): void {
    if (this.cardForm.valid) {
      const cardData = this.cardForm.value;
      this.cardSaved.emit(cardData);
      this.activeModal.close();
    }
  }
}
