import { ProductCardDto } from "../Product/Product-Card-dto";

export class RestaurantProductsDto {
    constructor(
        public products: ProductCardDto[] = []
    ) {}
}