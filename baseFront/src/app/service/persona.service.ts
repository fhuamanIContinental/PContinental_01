import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonaModel } from '../models/persona.model';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  private url: string = "https://localhost:7237/api/Persona/";
  constructor(
    private _http: HttpClient
  ) { }

  getAll(): Observable<PersonaModel[]> {
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
