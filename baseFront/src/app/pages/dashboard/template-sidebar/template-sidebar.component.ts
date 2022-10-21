import { Component, OnInit } from '@angular/core';
import { sessionConstant } from 'src/app/constantes/session.constants';
import { MenuModel } from 'src/app/models/menu.model';
import { MenuService } from 'src/app/service/menu.service';
import { SessionService } from 'src/app/service/session.service';

@Component({
  selector: 'app-template-sidebar',
  templateUrl: './template-sidebar.component.html',
  styleUrls: ['./template-sidebar.component.scss']
})
export class TemplateSidebarComponent implements OnInit {
  //if rol == administrador
  lista_menu: any = [
    {
      name: 'Mantenimiento Persona',
      url: 'mantenimiento/persona'
    },
    {
      name: 'Mantenimiento Empleado',
      url: 'mantenimiento/emplado'
    },

  ]
  //if rol == rrhh
  menus: MenuModel[] = [];
  show_menus: MenuModel[] = [];
  constructor(
    private _menuService: MenuService,
    private _sessionService: SessionService
  ) { }

  //ngOnInit ==> es el primer evento o función que se ejecuta al iniciar el componente
  ngOnInit(): void {
    this.obtenerListaMenu();
  }

  obtenerListaMenu()
  {
    let id_rol = this._sessionService.getVarSession(sessionConstant.id_role);
    if(!id_rol) // != "" != null != undefined
    {
      return;
    }
    this._menuService.ObtenerPorRol(id_rol).subscribe(
      (data:MenuModel[])=> {
        this.menus = data;
        this.show_menus = data;
        console.log("this.show_menus",this.show_menus);
        
      }, 
      err => {
        console.log("ocurrio un error", err);
      }
    );

  }

}
