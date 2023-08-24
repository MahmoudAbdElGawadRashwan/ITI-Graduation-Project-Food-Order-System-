import { Component, OnInit } from '@angular/core';
import { CustomerToRegisterDto } from 'src/app/types/Customer/customer-to-register-dto';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { PasswordMatchedValidation } from 'src/app/types/CustomValidations/password-matched-validation';
import { DateInPastValidator } from 'src/app/types/CustomValidations/date-in-past-validator';
import { ActivatedRoute } from '@angular/router';
import { RegistrationService } from 'src/app/services/registration.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register-as-cutomer',
  templateUrl: './register-as-cutomer.component.html',
  styleUrls: ['./register-as-cutomer.component.css']
})
export class RegisterAsCutomerComponent implements OnInit {
  // Object That Hold The Form Date To Send to  Back end 
  CustomerToRegister: CustomerToRegisterDto = new CustomerToRegisterDto();
  //My Customer Form Hold all Elments
  CustomerForm: FormGroup = new FormGroup("");

  // Array That hold Steps And it's Direction To Registraion Process 
  items = [
    {
      label: 'Personal Data',
      routerLink:['../registerascustomer']
    },
    {
      label: 'Paymentdata',
      routerLink:['../paymentregistraion']

    },
    {
      label: 'Confimation',
      path: './confirmation'

    }
  ];
 
  //Inject Service that Help In Validation 
  constructor(private fb: FormBuilder, private route :ActivatedRoute , private RegisterService: RegistrationService , private router :Router) {
    const activeComponent = this.route.snapshot.component;
    console.log('Active component:', activeComponent);

   }
 
  ngOnInit(): void {
    this.CustomerForm = this.fb.group({
      CustomerFirstName: ['', [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(30)
      ]],
      CustomerLastName: ['', [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(30)
      ]],
      CustomerBirthDate: ['', [
        Validators.required,
        DateInPastValidator
      ]],
      CustomerPhone: ['', [
        Validators.required,
        Validators.pattern('^[0-9]{11}$')
      ]],
      CustomerAddress: ['', [
        Validators.required,
      ]],
      CustomerEmail: ['', [
        Validators.required,
        Validators.email
      ]],
      CustomerPassword: ['', [
        Validators.required,
        Validators.pattern("^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
      ]],
      CustomerConfirmPassword: ['', [
        Validators.required,
        PasswordMatchedValidation
      ]],
     
     
    }, { validators: PasswordMatchedValidation }); // Add the confirmPasswordValidator
  }

  //  Get Properties To All Inputs Groups in Form 
  get CustomerFirstName() {
    return this.CustomerForm.get('CustomerFirstName')!!;
  }
  get CustomerLastName() {
    return this.CustomerForm.get('CustomerLastName')!!;
  }
  get CustomerBirthDate() {
    return this.CustomerForm.get('CustomerBirthDate')!!;
  }
  get CustomerPhone() {
    return this.CustomerForm.get('CustomerPhone')!!;
  }
  get CustomerAddress() {
    return this.CustomerForm.get('CustomerAddress')!!;
  }
  get CustomerEmail() {
    return this.CustomerForm.get('CustomerEmail')!!;
  }
  get CustomerPassword() {
    return this.CustomerForm.get('CustomerPassword')!!;
  }
  get CustomerConfirmPassword() {
    return this.CustomerForm.get('CustomerConfirmPassword')!!;
  }
  // The End of Proerty Group


  submitForm() {
    if (this.CustomerForm.valid) {
      // Form is valid, perform registration logic

      this.RegisterService.RegisterdCustomer.firstName = this.CustomerFirstName.value
       this.RegisterService.RegisterdCustomer.lastName = this.CustomerLastName.value
       this.RegisterService.RegisterdCustomer.phone = this.CustomerPhone.value
       this.RegisterService.RegisterdCustomer.customerAddress = this.CustomerAddress.value
       this.RegisterService.RegisterdCustomer.customerBirth = this.CustomerBirthDate.value
       this.RegisterService.RegisterdCustomer.email = this.CustomerEmail.value
       this.RegisterService.RegisterdCustomer.password = this.CustomerPassword.value

      this.router.navigate(['/registration/paymentregistraion']);
     
    } else {
      // Form is invalid, handle validation errors
      this.markFormGroupTouched(this.CustomerForm); // Mark form controls as touched to display validation errors
    }
  }

  // Function to mark all From Controls As Touched

  markFormGroupTouched(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach(control => {
      control.markAsTouched();
      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control);
      }
    });
  }

}









