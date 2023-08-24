import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UploadFileDto } from '../types/image/upload-file-dto';
import { ProductService } from './product.service';
import { RegistrationService } from './registration.service';

@Injectable({
  providedIn: 'root',
})
export class ImageService {
  constructor(
    private client: HttpClient,
    private productservice: ProductService,
    private RegistrationService: RegistrationService
  ) {}

  public upload(file: File): Observable<UploadFileDto> {
    var form = new FormData();
    form.append('file', file);

    return this.client.post<UploadFileDto>(
      'https://localhost:7020/api/Image',
      form
    );
  }

  uploadProductPhoto(e: Event) {
    const input = e.target as HTMLInputElement;
    const file = input.files?.[0];
    if (!file) return;

    this.upload(file).subscribe((response) => {
      this.productservice.productToAdd.img = response.url;
    });
  }

  uploadResturantPhoto(e: Event) {
    const input = e.target as HTMLInputElement;
    const file = input.files?.[0];
    if (!file) return;

    this.upload(file).subscribe((response) => {
      this.RegistrationService.RegisterResturant.logo = response.url;
    });
  }
  updateRestaurantPhoto(e: Event): string {
    const input = e.target as HTMLInputElement;
    const file = input.files?.[0];
    if (!file) return '';

    let responseImageUrl: string = '';
    this.upload(file).subscribe(
      (response) => {
        responseImageUrl = response.url;
      },
      (error) => console.error(error)
    );
    return responseImageUrl;
  }
}
