import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { SessionService } from '../service/session.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {
  constructor(
    private _sessionService:SessionService,
    private _router:Router
  )
  {

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    //validar si el token existe en nuestra aplicación
    let token = this._sessionService.getVarSession("token");
    if(token != null && token != undefined && token != "")
    {
      console.log("retorna true");
      
      return true;
    }
    else {
      console.log("retorna false");
      this._router.navigate(['']);  
      return false;
    }
  }
  
}
