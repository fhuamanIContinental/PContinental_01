import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { urlBack } from '../constantes/url.constants';
import { MenuModel } from '../models/menu.model';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  private url: string = urlBack.menu;
  constructor(
    private _http: HttpClient,
  ) { }

  ObtenerPorRol(id_rol:string): Observable<MenuModel[]> {
    //`${this.url}role/${id_rol}` ==> https://localhost:7237/api/menu/role/4
    return this._http.get<MenuModel[]>(`${this.url}role/${id_rol}`);
  }
}
