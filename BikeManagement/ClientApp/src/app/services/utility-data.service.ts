import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilityDataService {

  constructor() { }

  public getApiBaseUrl(): string {
    return 'https://localhost:5001/api';
  }

}
