import { Component,OnDestroy,OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { EventData } from 'src/app/_models/eventData';
import { FullProductCardDto } from 'src/app/_models/product/FullProductCardDto';
import { ProductService } from 'src/app/services/product.service';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit ,OnDestroy{

  productsSub:Subscription|null = null;
  categoriesSub:Subscription|null = null;
  restaurantSub:Subscription|null = null;

  filterCategories:string[] = []
  filterRestaurants:string[] = []
  searchString:string = "";

  constructor(private productService:ProductService,private restaurantService:RestaurantService){}

  productsList:FullProductCardDto[] = [];

  ngOnInit(): void {
    this.productsSub=this.productService.getAll("",[],[],[]).subscribe(
      (data) => {
        this.productsList = data;
      },
      (error) => {
        console.log(`error: ${error}`);
      }
    );
      //-------------
    this.categoriesSub=this.productService.getAllTags().subscribe(
      (data) => {
      this.filterCategories = data.sort();
    },
    (error) => {
      console.log(`error: ${error}`);
    }
  );
    //------------
  this.restaurantSub=this.restaurantService.getAllRestaurants().subscribe(
    (data) => {
      data.forEach(Restaurant => {
        this.filterRestaurants.push(Restaurant.restaurantName)
      });
      this.filterRestaurants.sort();
  },
  (error) => {
    console.log(`error: ${error}`);
  });
  }


  ngOnDestroy(): void {
    this.productsSub?.unsubscribe();
    this.categoriesSub?.unsubscribe();
    this.restaurantSub?.unsubscribe();
  }

  getFilterdCards(obj:any|null){
    if(obj == null)
      obj=new EventData([],[],[]);
      
    this.productsSub=this.productService.getAll(this.searchString,obj.Categories,obj.restaurants,obj.range).subscribe(
      (data) => {
        this.productsList = data;
        console.log(this.productsList);
      },
      (error) => {
        console.log(`error: ${error}`);
      }
    );
  }
}
