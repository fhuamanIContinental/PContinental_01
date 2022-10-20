import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlBack } from '../constantes/url.constants';
import { LoginRequestModel } from '../models/common/login-request.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  url: string = urlBack.login;
  constructor(
    protected http: HttpClient,
  ) { }

  login(request:LoginRequestModel)
  {
    return this.http.post(this.url,request);
  }

}
