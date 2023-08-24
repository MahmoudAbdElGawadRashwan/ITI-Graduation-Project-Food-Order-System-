export class productUpdateDto {
  constructor(
    public productID: number = -1, //not in form
    public productname: string = '',
    public price: number = 0,
    public describtion: string = '',
    public img: string = '', // not in form
    public offer: number = 0,
    public rate: number = 0, // not in form
    public tags: string[] = [], // not in form
    public restaurantID: number = 0, // not in form
    public restaurantName: string = '' // not in form
  ) {}
}

// this.UpdateProductForm = this.fb.group({
//     Name: ['', [Validators.required]],
//     Price: ['', [Validators.required]],
//     Description: ['', [Validators.required]],
//     Image: ['', [Validators.required]],
//     Offer: ['', [Validators.required]],
//     // ResturnatLogo: [null, Validators.required],
//   }); // Add the confirmPasswordValidator
