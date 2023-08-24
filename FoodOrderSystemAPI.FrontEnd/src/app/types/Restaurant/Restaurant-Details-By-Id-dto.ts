export class RestaurantDetailsByIdDto {
  constructor(
    public restaurantId: number = -1,
    public restaurantName: string = '',
    public userName: string = '',
    public email: string = '',
    public normalizedUserName: string = '',
    public address: string = '',
    public logo: string = '',
    public phone: string = '',
    public paymentMethods: PaymentType = PaymentType.Cash
  ) {}
}

export enum PaymentType {
  Cash,
  Credit,
  Both,
}
