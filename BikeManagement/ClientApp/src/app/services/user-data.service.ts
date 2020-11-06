import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../view-models/user';
import { Observable } from 'rxjs';
import { UserToken } from '../../view-models/UserToken';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  userApiUrl = 'https://localhost:5001/api/User';

  constructor(private http: HttpClient) { }

  authenticateUser(user: User): Observable<UserToken> {
    const url = `${this.userApiUrl}/login/${user.userName}/${user.password}`;
    return this.http.post<UserToken>(url, httpOptions);
  }
}
