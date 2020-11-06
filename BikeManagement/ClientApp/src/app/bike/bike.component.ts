import { Component, OnInit } from '@angular/core';
import { Bike } from '../../view-models/Bike';
import { BikeDataService } from '../services/bike-data.service';
import { Router } from '@angular/router';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-bike',
  templateUrl: './bike.component.html',
  styleUrls: ['./bike.component.css']
})
export class BikeComponent implements OnInit {

  bikes: Bike[] = [];
  isLoggedIn = false;

  constructor(private bikeService: BikeDataService,
    private router: Router,
    private tokenStorage: TokenStorageService) { }

  ngOnInit() {
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
    }

    if (this.isLoggedIn) {
      this.bikeService.getBikes().subscribe(results => {
        this.bikes = results;
      });
    }
    else {
      this.router.navigate(['']);
    }
  }

}
