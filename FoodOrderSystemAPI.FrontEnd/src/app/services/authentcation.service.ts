import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginDto } from '../types/login-dto';
import { TokenDto } from '../types/token-dto';
import { UserTokenClaims } from '../types/user-token-claims';
import jwtDecode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthentcationService {
  // Attrebutes Of Authentication Service
  public IsLoggedIn$ = new BehaviorSubject(false);

  public UserLogin: null | UserTokenClaims;

  public UserToken: string | null = null;

  // Counstructor Of Authentcation Sevic
  constructor(private httpclient: HttpClient) {
    // Assign Customer Claims TO Registerd Cusotmer Property

    this.UserLogin = this.ExtractClamisOfToken();
  }

  // Function That Return Observable TO Subscibe On When Login
  Login(Credentials: LoginDto): Observable<TokenDto> {
    const ServerTokenResponse = this.httpclient.post<TokenDto>(
      'https://localhost:7020/api/Login', 
      Credentials
    );
    return ServerTokenResponse;
  }

  // Logout Function
  Logout = () => {
    // Remove The TOken Of User
    localStorage.removeItem('UserData');
    // Set The Value Of Login Attrebute TO Flase
    this.IsLoggedIn$.next(false);
  };

  // Function To Set User Data

  SetUserDataAfterLogin(RegisterUserToken: TokenDto) {
    this.IsLoggedIn$.next(true);
    localStorage.setItem('UserData', RegisterUserToken.token);
    this.UserLogin = this.ExtractClamisOfToken();
  }

  // Function to create Object hava User Data
  ExtractClamisOfToken = (): UserTokenClaims | null => {
    // Get the Decoded Token
    this.UserToken = localStorage.getItem('UserData');

    // Sitution TO Retrive Decoded If Exist Or Not
    const DecodedToken: any = this.UserToken ? jwtDecode(this.UserToken) : null;

    // Case 1 No Token in Local Storage
    if (!DecodedToken) return null;

    // Case 2 If The Token Is Exist

    // Assign The Claims  Of The Token
    const Role =
      DecodedToken[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ];
    const EmailAddress =
      DecodedToken[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'
      ];
    const UserName =
      DecodedToken[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
      ];
    const id =
      DecodedToken[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
      ];
    const { exp } = DecodedToken;
    const expiryDate = new Date(0); // Create a new Date object with a time of 0 (UNIX epoch)
    expiryDate.setUTCSeconds(exp); // Set the expiry time in seconds

    //  Set The Flag Of THe Customer Is Logged In To True
    this.IsLoggedIn$.next(true);

    return new UserTokenClaims(id, UserName, Role, EmailAddress, expiryDate);
  };

  
}
