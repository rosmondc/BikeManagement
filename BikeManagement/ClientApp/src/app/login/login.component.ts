import { Component, OnInit } from '@angular/core';
import { User } from '../../view-models/user';
import { Router } from '@angular/router';
import { TokenStorageService } from '../services/token-storage.service';
import { UserDataService } from '../services/user-data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isLoggedIn = false;

  user: User = {
    userName: '',
    password: ''
  };

  constructor(private userService: UserDataService, private router: Router, private tokenStorage: TokenStorageService) { }

  ngOnInit() {
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
    }
  }

  onAuthenticateUser(userName: string, password: string) {
    this.user.userName = userName;
    this.user.password = password;

    this.userService.authenticateUser(this.user).subscribe(data => {
      this.tokenStorage.saveToken(data.token);
      this.tokenStorage.saveUser(data);
      this.isLoggedIn = true;
      this.router.navigate(['bikeRent']);

    }, () => alert('Invalid username/password'));
  }
}
