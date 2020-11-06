import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bike } from '../../view-models/Bike';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { UtilityDataService } from '../services/utility-data.service';



const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class BikeDataService {

  baseUrl: string;

  constructor(private http: HttpClient, private apiBaseUrl: UtilityDataService) {
    this.baseUrl = apiBaseUrl.getApiBaseUrl();
  }

  getBikes(): Observable<Bike[]> {
    return this.http.get<Bike[]>(`${this.baseUrl}/bike`, httpOptions);
  }

  getBikeById(id: number): Observable<Bike[]> {
    return this.http.get<Bike[]>(`${this.baseUrl}/bike/${id}`, httpOptions);
  }

}
