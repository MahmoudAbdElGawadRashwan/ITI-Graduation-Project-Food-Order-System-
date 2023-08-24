export class RestaurantUpdateDto {
  constructor(
    public id: number = 0,
    public restaurantName: string = '',
    public address: string = '',
    public logo: string = '',
    public phone: string = '',
    public paymentMethods: number = 0
  ) {}
}
