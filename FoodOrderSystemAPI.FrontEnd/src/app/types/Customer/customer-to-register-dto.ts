export class CustomerToRegisterDto {


  firstName: string = '';
  lastName: string = '';
  email: string ='';
  password: string = '';
  customerAddress: string = '';
  cardNumber?: string = '';
  expirationDate: Date = new Date(Date.now());
  cvvNumber: string = ''
  phone: string = ''
  customerBirth: Date|null = null;



}






