import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { sessionConstant } from '../constantes/session.constants';
import { urlBack } from '../constantes/url.constants';
import { PersonaModel } from '../models/persona.model';
import { SessionService } from './session.service';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  private url: string = urlBack.persona;
  constructor(
    private _http: HttpClient,
    private _sessionService: SessionService
  ) { }

  getAll(): Observable<PersonaModel[]> {
    // let token = this._sessionService.getVarSession(sessionConstant.token);
    // const reqHeader = new HttpHeaders({
    //   'Content-Type': 'application/json',
    //   'Authorization': `Bearer ${token}`
    // });
    // return this._http.get<PersonaModel[]>(this.url, { headers: reqHeader });
    return this._http.get<PersonaModel[]>(this.url);
  }
  create(request: PersonaModel): Observable<PersonaModel> {
    return this._http.post<PersonaModel>(this.url, request);
  }
  update(request: PersonaModel): Observable<PersonaModel> {
    return this._http.put<PersonaModel>(this.url, request);
  }
  delete(id: number) {
    return this._http.delete(`${this.url}${id}`)
  }
  getById(id: number) {
    return this._http.get(`${this.url}${id}`)
  }
}
