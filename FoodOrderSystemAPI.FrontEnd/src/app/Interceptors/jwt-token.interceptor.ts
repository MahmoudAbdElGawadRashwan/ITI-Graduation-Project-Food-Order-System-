import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthentcationService } from '../services/authentcation.service';

@Injectable()
export class JwtTokenInterceptor implements HttpInterceptor {

  constructor(public Authservice : AuthentcationService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this.Authservice.UserToken;
    const modifiedRequest = request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    return next.handle(modifiedRequest);
  }
}
