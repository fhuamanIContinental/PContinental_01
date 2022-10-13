import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRequestModel } from 'src/app/models/common/login-request.model';
import { LoginService } from 'src/app/service/login.service';
import { SessionService } from 'src/app/service/session.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginRequest: LoginRequestModel = new LoginRequestModel();
  message: string = "";
  constructor(
    private _loginService: LoginService,
    private _router: Router,
    private _SessionService:SessionService

  ) { }

  ngOnInit() {
  }

  login() {
    this.message = "";
    if(this.loginRequest.password && this.loginRequest.userName)
    {
      this.realizarLogin();    

      
    }
    else {
      this.message = "Usuario y password son requeridos";
    }

  }

  realizarLogin()
  {
    this._loginService.login(this.loginRequest).subscribe(
      (result: any) => {
        console.log("result ==> ", result);
        this._SessionService.setVarSession("token", result.token)
        this._router.navigate(["dashboard"]);
      },
      (err:any) => {
        console.log("error ==> ", err);
        this.message = err.error;
      }
    );
  }

}
