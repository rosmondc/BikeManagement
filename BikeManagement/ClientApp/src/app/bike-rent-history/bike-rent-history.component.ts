import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { BikeRentHistoryDataService } from '../services/bike-rent-history-data.service';
import { TokenStorageService } from '../services/token-storage.service';
import { BikeRentHistory } from '../../view-models/BikeRentHistory';

@Component({
  selector: 'app-bike-rent-history',
  templateUrl: './bike-rent-history.component.html',
  styleUrls: ['./bike-rent-history.component.css']
})
export class BikeRentHistoryComponent implements OnInit {

  isLoggedIn = false;
  bikeHistories: BikeRentHistory[];

  bikeRent: BikeRentHistory = {
    id: 0,
    customerName: '',
    checkOutTime: null,
    checkInTime: null,
    timeSpent: null,
    bikeId: 0
  };


  constructor(private bikeRentService: BikeRentHistoryDataService,
    private router: Router,
    private tokenStorage: TokenStorageService) { }

  ngOnInit() {
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
    }

    if (this.isLoggedIn) {
      this.getBikeRentHistories();
    }
    else {
      this.router.navigate(['']);
    }
  }

  getBikeRentHistories() {
    this.bikeRentService.getBikeRentHistories().subscribe(results => {
      this.bikeHistories = results.sort((a, b) => (a.id > b.id) ? -1 : 1)
    });
  }

  onSavingBikeRent(bikeRent: BikeRentHistory) {
    this.bikeRentService.saveBikeRentHistory(bikeRent).subscribe(data => {
      console.log('Successfuly save');
      this.getBikeRentHistories();
      this.bikeRent = {} as any;
    }, () => alert('Error while saving data'));
  }

}
