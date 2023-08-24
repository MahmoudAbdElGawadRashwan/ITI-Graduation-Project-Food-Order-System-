export class CustomerProfileDetails {
  fullName: string;
  role: string;
  email: string;
  customerAddress: string;
  cardNumber: string;
  expirationDate: string;
  cvvNumber: string;
  phone: string;
  customerBirth: string;

  constructor() {
    this.fullName = '';
    this.role = '';
    this.email = '';
    this.customerAddress = '';
    this.cardNumber = '';
    this.expirationDate = '';
    this.cvvNumber = '';
    this.phone = '';
    this.customerBirth = '';
  }
}
