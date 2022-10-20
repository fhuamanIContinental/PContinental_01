import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { SessionService } from '../service/session.service';
import { alert_error } from '../funciones/alert.function';
import { sessionConstant } from '../constantes/session.constants';


@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService {

  constructor(
    private router: Router,
    private _sessionService: SessionService,
  ) { }

  
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let token = this._sessionService.getVarSession(sessionConstant.token);
    let request = req;
    if (token) {
      request = req.clone({
        setHeaders: {
          authorization: `Bearer ${token}`
        }
      });
    }

    return next.handle(request).pipe(
      catchError((err: HttpErrorResponse) => {
        
        let firstError:boolean = false;
        let title: string = "Error en el servidor | comuniquese con el área de T.I";
        switch (err.status) {
          case 401:
            //alert("realizar proceso de refresh token");
            this.router.navigate(['']);
            break;
          case 500:

            alert_error(title, err.message);
            break;
          case 404:
            alert_error(title, "404 not found");
            break;
          default:
            alert_error(title, err.message);
            break;
        }
        return throwError(err);
      })
    );
  }
}