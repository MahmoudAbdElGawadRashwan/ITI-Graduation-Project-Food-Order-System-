import { ProductOrder } from "../Product/product-order";

export interface ResturantOrderDto {
    orderId: number;
    customerName: string;
    customerPhone: string;
    customerAddress: string;
    orderDate: string;
    totalPrice: number;
    orderProducts: ProductOrder[] ;
}