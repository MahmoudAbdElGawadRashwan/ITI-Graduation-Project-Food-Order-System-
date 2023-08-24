import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { RegistrationService } from 'src/app/services/registration.service';
import { Router } from '@angular/router';
import { ResturantRegister } from 'src/app/types/resturant-register';
import { AuthentcationService } from 'src/app/services/authentcation.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ImageService } from 'src/app/services/image.service';
@Component({
  selector: 'app-register-as-resturant',
  templateUrl: './register-as-resturant.component.html',
  styleUrls: ['./register-as-resturant.component.css'],
})
export class RegisterAsResturantComponent implements OnInit {
  // Object That Hold The Form Date To Send to  Back end
  RegisterResturant: ResturantRegister = new ResturantRegister();
  //My Customer Form Hold all Elments
  ResturantForm: FormGroup = new FormGroup('');

  constructor(
    private fb: FormBuilder,
    public RegisterService: RegistrationService,
    private router: Router,
    private AuthentcationService: AuthentcationService,
    public imageservice: ImageService
  ) {}

  ngOnInit(): void {
    this.ResturantForm = this.fb.group(
      {
        Name: [
          '',
          [
            Validators.required,
           
          ],
        ],
       
        Email: [
          '',
          [
            Validators.required,
            Validators.email
           
          ],
        ],
        Address: [
          '',
          [
            Validators.required,
            
          ],
        ],
        // Logo: [
        //   '',
        //   [Validators.required,
        //   ]],
        Phone: [
          '',
          [Validators.required,
            Validators.pattern('^[0-9]{11}$')]],
        PaymentMethods: [
          '',
          [Validators.required,
           ]],
        Password: [
          '',
          [Validators.required,
          ]],
          ResturnatLogo : [ null,Validators.required],
      }
    ); // Add the confirmPasswordValidator
  }

  //  Get Properties To All Inputs Groups in Form
  get ResturantName() {
  return this.ResturantForm.get('Name')!!;
  }
  get EmailAddress() {
    return this.ResturantForm.get('Email')!!;
  }
  get ResturantAddress() {
    return this.ResturantForm.get('Address')!!;
  }
  // get ResturantLogo() {
  //   return this.ResturantForm.get('Logo')!!;
  // }
  get ResturantPhone() {
    return this.ResturantForm.get('Phone')!!;
  }
  get ResturantPaymentMehods() {
    return this.ResturantForm.get('PaymentMethods')!!;
  }
  get ResturantPassword() {
    return this.ResturantForm.get('Password')!!;
  }
  get ResturnatLogo() {
    return this.ResturantForm.get('ResturnatLogo')!!;
  }


  // When form Submit
  submitForm() {
    if (this.ResturantForm.valid) {
      // Form is valid, perform registration logic

      this.RegisterService.RegisterResturant.restaurantName =
        this.ResturantName.value;
      
      this.RegisterService.RegisterResturant.email =
        this.EmailAddress.value;
      
      this.RegisterService.RegisterResturant.userName =
        this.EmailAddress.value;
      
      this.RegisterService.RegisterResturant.address =
        this.ResturantAddress.value;
      
      
      this.RegisterService.RegisterResturant.phone =
        this.ResturantPhone.value;
      
      this.RegisterService.RegisterResturant.paymentMethods =
      Number.parseInt( this.ResturantPaymentMehods.value);
      
      this.RegisterService.RegisterResturant.password =
        this.ResturantPassword.value;
      
      console.log(this.RegisterService.RegisterResturant)
      this.RegisterService.RegisterAsResturant().subscribe( (RegisterResturantToken) => {
        console.log(RegisterResturantToken);
        this.AuthentcationService.SetUserDataAfterLogin(RegisterResturantToken);
        this.router.navigate([`restaurant/${this.AuthentcationService.UserLogin?.id}`]);
      },
      (error: HttpErrorResponse) => {
        console.log(error);
      })
    } else {
      // Form is invalid, handle validation errors
      this.markFormGroupTouched(this.ResturantForm); // Mark form controls as touched to display validation errors
     
      this.RegisterService.RegisterResturant.restaurantName =
        this.ResturantName.value;
      
      this.RegisterService.RegisterResturant.email =
        this.EmailAddress.value;
      
      this.RegisterService.RegisterResturant.userName =
        this.EmailAddress.value;
      
      this.RegisterService.RegisterResturant.address =
        this.ResturantAddress.value;
      
      
      this.RegisterService.RegisterResturant.phone =
        this.ResturantPhone.value;
      
      this.RegisterService.RegisterResturant.paymentMethods =
        Number.parseInt(this.ResturantPaymentMehods.value)
      
      this.RegisterService.RegisterResturant.password =
        this.ResturantPassword.value;
      console.log(' Not valid ');
      console.log(this.RegisterService.RegisterResturant);
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
 



