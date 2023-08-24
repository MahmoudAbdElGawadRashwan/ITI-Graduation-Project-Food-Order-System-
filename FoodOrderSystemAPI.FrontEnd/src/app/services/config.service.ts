import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ConfigService {
  private config = {
    baseApiUrl: 'https://localhost:7020/api/',
  };
  constructor() {}
  getBaseApiUrl() {
    return this.config.baseApiUrl;
  }
}
