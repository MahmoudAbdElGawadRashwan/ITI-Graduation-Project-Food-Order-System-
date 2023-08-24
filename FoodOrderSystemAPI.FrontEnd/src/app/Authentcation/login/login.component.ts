import { Component } from '@angular/core';
import { AuthentcationService } from 'src/app/services/authentcation.service';
import { FormControl, FormGroup } from '@angular/forms';
import { LoginDto } from 'src/app/types/login-dto';
import { HttpErrorResponse } from '@angular/common/http';

import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  WrongDataFlag = false;

  constructor(private AuthentcatoinService: AuthentcationService  , private  router : Router) {} // Inject AthentcationService !!

  form = new FormGroup({
    // Form Grout in Html file 2 way binding form data !!
    UserName: new FormControl<string>('string'),
    Password: new FormControl<string>('string'),
  });

  handleSubmit(e: Event) {
    // Handle Event when Click submit on The html Btn
    e.preventDefault();

    var Credentials = new LoginDto(); // Class that hold user Name And Password

    Credentials.userName = this.form.controls.UserName.value ?? '';
    Credentials.password = this.form.controls.Password.value ?? '';

    this.AuthentcatoinService.Login(Credentials).subscribe((TokenDto) => { // subscribe On Event Loging On AthentcationService To Take An Action !!
      // set the value of IsLoggedIn to true 
      this.AuthentcatoinService.SetUserDataAfterLogin(TokenDto);
      if(this.AuthentcatoinService.UserLogin?.Role == "Resturant")
      this.router.navigate([`/restaurant/${this.AuthentcatoinService.UserLogin?.id}`])
      else if (this.AuthentcatoinService.UserLogin?.Role == "Customer") {
        this.router.navigate([`/home`])
 
      }
    },
      (error: HttpErrorResponse) => {
      // When User Enter Wrong Data Change the WrongDataFlag property to true to Show    Span Elment in Component
      this.WrongDataFlag = true;
      // Handle the HTTP error
    }
    )
  }

}
