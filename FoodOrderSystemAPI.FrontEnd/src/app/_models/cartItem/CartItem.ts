import { FullProduct } from 'src/app/types/Product/full-product-dto';

export class CartItem {
  constructor(
    public product: FullProduct = new FullProduct(),
    public quantity: number = 0
  ) {}
}
