import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { FullProduct } from 'src/app/types/Product/full-product-dto';
import { productUpdateDto } from 'src/app/types/Product/product-update-dto';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.css'],
})
export class ProductUpdateComponent {
  // Object That Hold The Form Date To Send to  Back end
  NewProductUpdateDto: productUpdateDto = new productUpdateDto();
  CurrentProduct: FullProduct = new FullProduct();
  //My Customer Form Hold all Elments
  UpdateProductForm: FormGroup = new FormGroup('');

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private productService: ProductService,
    private activatedRoute: ActivatedRoute // public imageservice: ImageService, // public authenticationService: AuthentcationService
  ) {}

  ngOnInit(): void {
    this.UpdateProductForm = this.fb.group({
      Name: ['', [Validators.required]],
      Price: ['', [Validators.required]],
      Description: ['', [Validators.required]],
      Offer: ['', [Validators.required]],
    }); // Add the confirmPasswordValidator

    // FILLING DATA VALUES OF CURRENT PRODUCT
    let currentProductIdString =
      this.activatedRoute.snapshot.paramMap.get('Id');
    let currentProductId: number = 1;
    if (currentProductIdString != null) {
      currentProductId = parseInt(currentProductIdString);
    }
    this.productService.getProduct(currentProductId).subscribe(
      (data) => {
        if (data !== null) this.CurrentProduct = data;
        console.log('after getting data ------');
        console.log(this.CurrentProduct);
        //  FILLING FORM WITH CURRENT RESTAURANT DATA
        this.ProductName.setValue(this.CurrentProduct.productname);
        this.ProductPrice.setValue(this.CurrentProduct.price);
        this.ProductDescription.setValue(this.CurrentProduct.describtion);
        // this.ProductImage.setValue(this.CurrentProduct.img);
        this.ProductOffer.setValue(this.CurrentProduct.offer);
        // this.NewProductUpdateDto.logo = this.CurrentProduct.logo;
        // setting other data not to be changed
        this.NewProductUpdateDto.productID = this.CurrentProduct.productID;
        this.NewProductUpdateDto.img = this.CurrentProduct.img;
        this.NewProductUpdateDto.rate = this.CurrentProduct.rate;
        this.NewProductUpdateDto.tags = this.CurrentProduct.tags;
        this.NewProductUpdateDto.restaurantID =
          this.CurrentProduct.restaurantID;
        this.NewProductUpdateDto.restaurantName =
          this.CurrentProduct.restaurantName;
      },
      (error) => {
        console.log('errrrrrrrrrrrrrrrrrrrrrrr');
        console.error(error);
      }
      
    );


  }

  //#region   Get Properties To All Inputs Groups in Form
  get ProductName() {
    return this.UpdateProductForm.get('Name')!!;
  }
  get ProductPrice() {
    return this.UpdateProductForm.get('Price')!!;
  }
  get ProductDescription() {
    return this.UpdateProductForm.get('Description')!!;
  }
  get ProductImage() {
    return this.UpdateProductForm.get('Image')!!;
  }
  get ProductOffer() {
    return this.UpdateProductForm.get('Offer')!!;
  }

  //#endregion

  // When form Submit
  submitForm() {
    if (this.UpdateProductForm.valid) {
      // Form is valid, perform registration logic

      this.NewProductUpdateDto.productname = this.ProductName.value;
      this.NewProductUpdateDto.price = this.ProductPrice.value;
      this.NewProductUpdateDto.describtion = this.ProductDescription.value;
      this.NewProductUpdateDto.offer = this.ProductOffer.value;

      console.log(this.NewProductUpdateDto);

      this.productService.UpdateProduct(this.NewProductUpdateDto).subscribe(
        (data) => {
          console.log('response: --------');
          console.log(data);
          this.router.navigate([`/product/${this.CurrentProduct.productID}`]);
        },
        (error) => console.error(error)
      );
    } else {
      // Form is invalid, handle validation errors
      this.markFormGroupTouched(this.UpdateProductForm); // Mark form controls as touched to display validation errors

      console.log(' Not valid ');
    }
  }

  // Function to mark all From Controls As Touched

  private markFormGroupTouched(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach((control) => {
      control.markAsTouched();
      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control);
      }
    });
  }
}
