export class RestaurantDetailsDto {
    constructor(
        public restaurantId: number,
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
    Both
}