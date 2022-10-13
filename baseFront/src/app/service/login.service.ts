import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequestModel } from '../models/common/login-request.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  url: string = "https://localhost:7237/api/Auth";
  constructor(
    protected http: HttpClient,
  ) { }

  login(request:LoginRequestModel)
  {
    return this.http.post(this.url,request);
  }

}
