import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor() { }


  setVarSession(item:string, value:string)
  {
    sessionStorage.setItem(item,value);
  }

  getVarSession(item:string)
  {
    return sessionStorage.getItem(item);
  }

}
