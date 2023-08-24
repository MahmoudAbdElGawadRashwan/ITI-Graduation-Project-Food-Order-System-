import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FullProductCardDto } from 'src/app/_models/product/FullProductCardDto';
import { RestaurantDto } from 'src/app/_models/restaurant/RestaurantDto';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { RestaurantProductsDto } from 'src/app/types/Restaurant/Restaurant-Products-dto';
import { ProductCardDto } from 'src/app/types/Product/Product-Card-dto';
import { EventData } from 'src/app/_models/eventData';
import { ProductService } from 'src/app/services/product.service';
import { RestaurantDetailsByIdDto } from 'src/app/types/Restaurant/Restaurant-Details-By-Id-dto';
import { AuthentcationService } from 'src/app/services/authentcation.service';

@Component({
  selector: 'app-restaurant-page',
  templateUrl: './restaurant-page.component.html',
  styleUrls: ['./restaurant-page.component.css']
})
export class RestaurantPageComponent implements OnInit {
  Logged:boolean=false;
  filterCategories:string[] = []
  restaurantName:string="";
  searchString:string = "";
  
  _products: RestaurantProductsDto = new RestaurantProductsDto();

  constructor(private restaurantService: RestaurantService,
    private activatedRoute: ActivatedRoute,
    private productService:ProductService,
    public authentcationService:AuthentcationService,
    private router: Router
    ) {}
  productsList:FullProductCardDto[]|null = [];

  ngOnInit(): void {
    this.getRestaurantDetailsById();
    this.getRestaurantProducts();
  }

  getRestaurantProducts(): void {
    let urlRestaurantId = this.activatedRoute.snapshot.paramMap.get('id');
    
    if (urlRestaurantId) {
      let restaurantId = parseInt(urlRestaurantId);
      // console.log(restaurantId);
      this.restaurantService.getRestaurantProducts(restaurantId)
        .subscribe(data => {this._products = data; console.log(this._products);
        }, error => {
          console.log(`error: ${error}`);
        });
    }
      console.log(this._products);

      //-------------
    this.productService.getAllTags().subscribe(
      (data) => {
      this.filterCategories = data.sort();
    },
    (error) => {
      console.log(`error: ${error}`);
    }
  );
  }

  getFilterdCards(obj:any|null){
    if(obj == null)
      obj=new EventData([],[],[]);
      
    this.productService.getAll(this.searchString,obj.Categories,[this.restaurantName],obj.range).subscribe(
      (data) => {
        // this._products.products=[];
        // data.forEach(product => {
        //   let toBeAdded = new 
        // });

        this._products.products = data;
        console.log(this._products);
      },
      (error) => {
        console.log(`error: ${error}`);
      }
    );
  }

  getRestaurantDetailsById(): void {
    let urlRestaurantId = this.activatedRoute.snapshot.paramMap.get('id');
    if (urlRestaurantId) {
      let restaurantId = parseInt(urlRestaurantId);
      // console.log(restaurantId);
      this.restaurantService.getRestaurantDetailsById(restaurantId)
      .subscribe((restaurantDetails: RestaurantDetailsByIdDto | null) => {
        if (restaurantDetails) {
          this.restaurantName = restaurantDetails.restaurantName;
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

  checkUser(){
    let urlRestaurantId = this.activatedRoute.snapshot.paramMap.get('id');
    if (urlRestaurantId) {
      let restaurantId = parseInt(urlRestaurantId);
      this.Logged=(this.authentcationService.UserLogin?.id==restaurantId)&&(this.authentcationService.UserLogin?.Role=="Restaurant")
    }
    return this.Logged
  }

  redirectToAddPage(): void {
    this.router.navigate(['/other-page']); // Replace '/other-page' with the actual URL of the page you want to redirect to
  }
}
