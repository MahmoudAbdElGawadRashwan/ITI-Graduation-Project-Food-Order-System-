import { Component, OnInit } from '@angular/core';
import { AuthentcationService } from 'src/app/services/authentcation.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{

  // Initailize User Info Elements 



  // Elaments in Template Page To Perform Toggle The Menus iN Page 
  UsermenuButton: HTMLButtonElement | null = null;
  UserdropdownMenu: HTMLElement | null = null;
  menuButton: HTMLButtonElement | null = null;
  mobileMenu: HTMLElement | null = null;

  


   // show the target element
// Property TO Maintain observable Value
  UserIsLoggedIn: boolean = false;
  constructor(public authService : AuthentcationService){}// Inject Service TO Subscipe On Behavior Subject is Logged In To An Action When It's Value CHange

  ngOnInit(): void { // Hook Method TO Perform Any logic Related TO Observable subscribe intial values intead of ctor

    // Catch Element Related to Mobile menu Show & Hide 
    this.menuButton = document.querySelector('[aria-controls="mobile-menu"]') as HTMLButtonElement;
    this.mobileMenu  = document.getElementById('mobile-menu') as HTMLElement;

    
    // Catch Element Related to User  menu Show & Hide 
   this.UserdropdownMenu = document.querySelector('[aria-labelledby="user-menu-button"]') as HTMLElement;

    // Subscribe On IsLoggedIn Observable To Change The Compoenent Property  UserIsLoggedIn based on CHange the value 
    this.authService.IsLoggedIn$.subscribe((isLoggedIn) => {
      // Assign the Observable Value WHen Change to The  Coponent Property => this.UserIsLoggedIn
      this.UserIsLoggedIn = isLoggedIn;

    })
    

  }


  // Add a click fun to the User menu button Logic show and hide user list 

  ToggleUserMenu = () => {
      // Toggle the "hidden" class on the dropdown menu to show or hide it
    if (this.UserdropdownMenu) {
      this.UserdropdownMenu!!.classList.toggle('hidden')
    }
    else {
      // console.log(` UserIsLoggedIn = ${this.UserIsLoggedIn} ///////// islogged for service = ${this.authService.IsLoggedIn$.value}`)

     this.UserdropdownMenu!!.classList.toggle('hidden')

      
    }
    }
  
  // Add a click fun to the User menu button Logic show and hide Mobile Menu 

  ToggleMobileMenu = () => {

    this.mobileMenu!!.classList.toggle('hidden');
    
    // Update the "aria-expanded" attribute on the menu button to reflect the menu's state
    const expanded = this.mobileMenu!!.classList.contains('hidden') ? 'false' : 'true';
    this.menuButton!!.setAttribute('aria-expanded', expanded);
  }

  HandleUserLogoutClick = () => {

    // Logout Logic 
    this.authService.Logout();

    // Hide The menu Of user Data 
    this.UserdropdownMenu!!.classList.toggle('hidden');

  }

}


