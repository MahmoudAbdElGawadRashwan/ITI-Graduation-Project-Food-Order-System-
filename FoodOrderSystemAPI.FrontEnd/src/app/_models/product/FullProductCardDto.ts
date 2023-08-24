import { RestaurantDto } from "../restaurant/RestaurantDto";

export class FullProductCardDto {
    constructor(
        public productID:number = 0,
        public productname:string = "",
        public price:number = 0,
        public describtion:string  = "",
        public img :string  = "",
        public offer:number = 0 ,
        public rate:number = 0 ,
        public tags:string[] = [],
        public restaurantID:number = 0,
        public restaurantName:string = "",
    ){

    }
}
