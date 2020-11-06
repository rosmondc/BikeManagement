import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BikeRentHistory } from '../../view-models/BikeRentHistory';
import { UtilityDataService } from './utility-data.service';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class BikeRentHistoryDataService {

  baseUrl: string;
  constructor(private http: HttpClient, private apiBaseUrl: UtilityDataService) {
    this.baseUrl = apiBaseUrl.getApiBaseUrl();
  }

  getBikeRentHistories(): Observable<BikeRentHistory[]> {
    return this.http.get<BikeRentHistory[]>(`${this.baseUrl}/BikeRentHistory`, httpOptions);
  }

  saveBikeRentHistory(bikeRentHistory: BikeRentHistory): Observable<BikeRentHistory> {
    //let body = { bikeRentHistory: bikeRentHistory };
    //return this.http.post<BikeRentHistory>(`${this.baseUrl}/BikeRentHistory/create`, body, httpOptions);
    let dateNow = new Date();

    //let checkOut = new Date(dateNow.getFullYear(), dateNow.getMonth(), dateNow.getDay(), bikeRentHistory.checkInTime, 30, 0, 0);


    const body = JSON.stringify(bikeRentHistory);
    const headerOptions = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<BikeRentHistory>(`${this.baseUrl}/BikeRentHistory/create`, body, { headers: headerOptions });

  }
}
