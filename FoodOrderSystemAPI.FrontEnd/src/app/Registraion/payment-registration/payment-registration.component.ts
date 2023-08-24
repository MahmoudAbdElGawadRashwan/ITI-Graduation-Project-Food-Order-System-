import { Component, OnInit } from '@angular/core';
import { CustomerToRegisterDto } from 'src/app/types/Customer/customer-to-register-dto';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { RegistrationService } from 'src/app/services/registration.service';
import { Router } from '@angular/router';
import { DateInFutureValidator } from 'src/app/types/CustomValidations/Date-In-Future-Validator';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthentcationService } from 'src/app/services/authentcation.service';

@Component({
  selector: 'app-payment-registration',
  templateUrl: './payment-registration.component.html',
  styleUrls: ['./payment-registration.component.css'],
})
export class PaymentRegistrationComponent implements OnInit {
  // Object That Hold The Form Date To Send to  Back end
  CustomerToRegister: CustomerToRegisterDto = new CustomerToRegisterDto();
  //My Customer Form Hold all Elments
  CreditCardForm: FormGroup = new FormGroup('');

  // Array That hold Steps And it's Direction To Registraion Process
  items = [
    {
      label: 'Personal Data',
      routerLink: ['../registerascustomer'],
    },
    {
      label: 'Paymentdata',
      routerLink: ['./paymentregistraion'],
    },
    {
      label: 'Confimation',
      path: './confirmation',
    },
  ];

  //Inject Service that Help In Validation
  constructor(
    private fb: FormBuilder,
    private RegisterService: RegistrationService,
    private router: Router,
    private AuthentcationService : AuthentcationService
  ) {
  
  }

  ngOnInit(): void {
    this.CreditCardForm = this.fb.group({
      Cvv: [
        '',
        [Validators.required, Validators.maxLength(3), Validators.minLength(3)],
      ],
      ExpirationDate: ['', [Validators.required, DateInFutureValidator]],

      CardNumber: [
        '',
        [
          Validators.required,
          // Validators.pattern('^[0-9\s\u200B-\u200D\u202F\u205F\u3000\uFEFF]+$')
        ],
      ],
    });
  }

  //  Get Properties To All Inputs Groups in Form

  get CardNumber() {
    return this.CreditCardForm.get('CardNumber')!!;
  }
  set CardNumber(value) {
    this.CreditCardForm.setControl('CardNumber', value);
  }
  get ExpirationDate() {
    return this.CreditCardForm.get('ExpirationDate')!!;
  }

  get Cvv() {
    return this.CreditCardForm.get('Cvv')!!;
  }

  // Function For Handle the card Input Field

  formatCardNumber(): void {
    // Get the value of the CardNumber form control
    const cardNumberValue = this.CardNumber.value;

    // Manipulate the card number value
    const formattedCardNumber = cardNumberValue
      .replace(/\s/g, '')
      .replace(/(\d{4})(?=\d)/g, '$1 ');

    // Set the manipulated value back to the CardNumber form control
    this.CardNumber.setValue(formattedCardNumber);
  }

  // The End of Proerty Group

  submitForm() {
    if (this.CreditCardForm.valid) {
      // Form is valid, perform registration logic

      // 1-- Assign All Registration Data To CustomerDto in Registration Service
      this.RegisterService.RegisterdCustomer.cardNumber = this.CardNumber.value;

      this.RegisterService.RegisterdCustomer.expirationDate =     
        this.ExpirationDate.value;
      
      this.RegisterService.RegisterdCustomer.cvvNumber = this.Cvv.value;
      console.log('valid ');
      console.log(this.RegisterService.RegisterdCustomer);


      
      this.RegisterService.Register().subscribe(
        (RegisterdCustomerTokenDto) => {
          console.log(RegisterdCustomerTokenDto);
          this.AuthentcationService.SetUserDataAfterLogin(RegisterdCustomerTokenDto);
          this.router.navigate(['/home']);
        },
        (error: HttpErrorResponse) => {
          console.log(error);
        }
      );
    } else {
      // Form is invalid, handle validation errors
      this.markFormGroupTouched(this.CreditCardForm); // Mark form controls as touched to display validation errors
      this.RegisterService.RegisterdCustomer.cardNumber = this.CardNumber.value;
      this.RegisterService.RegisterdCustomer.expirationDate =
        this.ExpirationDate.value;
      this.RegisterService.RegisterdCustomer.cvvNumber = this.Cvv.value;
      console.log(' Not valid ');
      console.log(this.RegisterService.RegisterdCustomer);
      console.log(this.CardNumber.value);
    }
  }

  // Function to mark all From Controls As Touched

  markFormGroupTouched(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach((control) => {
      control.markAsTouched();
      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control);
      }
    });
  }
}
