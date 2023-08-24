export class AddOrderDTO {
  constructor(
    public customerId: number = 0,
    public totalPrice: number = 0,
    public orderDate: string = new Date().toISOString(),
    public orderProducts: OrderProduct[] = []
  ) {}
}

export class OrderProduct {
  constructor(public productId: number = 0, public quantity: number = 0) {}
}
