import { Component, OnInit } from '@angular/core';

import { FullProductCardDto } from 'src/app/_models/product/FullProductCardDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';

import { RestaurantService } from 'src/app/services/restaurant.service';
import { RestaurantDetailsByIdDto } from 'src/app/types/Restaurant/Restaurant-Details-By-Id-dto';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthentcationService } from 'src/app/services/authentcation.service';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent implements OnInit {
  restaurantDetails: RestaurantDetailsByIdDto | null = null;
  searchString:string = "";
  Logged:boolean=false;

  constructor(private restaurantService: RestaurantService,
    private activatedRoute: ActivatedRoute,
    private authentcationService:AuthentcationService
    ,private router: Router) {}

  ngOnInit(): void {
    this.getRestaurantDetailsById();
  }

  getRestaurantDetailsById(): void {
    let urlRestaurantId = this.activatedRoute.snapshot.paramMap.get('id');
    if (urlRestaurantId) {
      let restaurantId = parseInt(urlRestaurantId);
      // console.log(restaurantId);
      this.restaurantService.getRestaurantDetailsById(restaurantId)
      .subscribe((restaurantDetails: RestaurantDetailsByIdDto | null) => {
        if (restaurantDetails) {
          this.restaurantDetails = restaurantDetails;
          console.log(restaurantDetails);
      } else {
        console.log('Restaurant not found');
      }
    },
      (error) => {
        console.log('Error occurred while retrieving restaurant details:', error);
      }
    );
      
    }
  }
  productsList:FullProductCardDto[]|null = [];

  

  /*
  getRestaurantDetails(id: number): void {
  this.restaurantService.getRestaurantDetailsById(id)
    .subscribe(
      (restaurantDetails: RestaurantDetailsDto | null) => {
        if (restaurantDetails) {
          // Use the retrieved restaurant details
          console.log(restaurantDetails);
        } else {
          // Restaurant details not found
          console.log('Restaurant not found');
        }
      },
      (error) => {
        console.log('Error occurred while retrieving restaurant details:', error);
      }
    );
}
  */

checkUser(){
  let urlRestaurantId = this.activatedRoute.snapshot.paramMap.get('id');
  if (urlRestaurantId) {
    let restaurantId = parseInt(urlRestaurantId);
    this.Logged=(this.authentcationService.UserLogin?.id==restaurantId)&&(this.authentcationService.UserLogin?.Role=="Restaurant")
  }
  return this.Logged
}

redirectToEditPage(): void {
  this.router.navigate(['/other-page']); // Replace '/other-page' with the actual URL of the page you want to redirect to
}


}