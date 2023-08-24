import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { RestaurantDetailsDto } from 'src/app/types/Restaurant/Restaurants-Read-dto'

@Component({
  selector: 'app-home-restaurants',
  templateUrl: './home-restaurants.component.html',
  styleUrls: ['./home-restaurants.component.css']
})
export class HomeRestaurantsComponent implements OnInit {

  restaurants: RestaurantDetailsDto[] = [];

  constructor(private restaurantService: RestaurantService) {
  }

  ngOnInit(): void {
    this.getAllRestaurants();
  }

  getAllRestaurants(): void {
    this.restaurantService.getAllRestaurants()
      .subscribe(restaurants => this.restaurants = restaurants);
  }

  responsiveOptions: any[] = [
    {
      breakpoint: '1024px',
      numVisible: 3,
      numScroll: 3
    },
    {
      breakpoint: '768px',
      numVisible: 2,
      numScroll: 2
    },
    {
      breakpoint: '560px',
      numVisible: 1,
      numScroll: 1
    }
  ];
}
