import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TemplateComponent } from './template/template.component';

const routes: Routes = [
  {
    path: '',
    component: TemplateComponent,
    //CONFIGURANDO RUTAS HIJAS
    children:[
      {
        path: 'mantenimiento',
        loadChildren: () => import('./../mantenimiento/mantenimiento.module').then(x => x.MantenimientoModule)
      },
      // {
      //   path: 'ventas',
      //   loadChildren: () => import('./../mantenimiento/mantenimiento.module').then(x => x.MantenimientoModule)
      // },
      // {
      //   path: 'contabilidad',
      //   loadChildren: () => import('./../mantenimiento/mantenimiento.module').then(x => x.MantenimientoModule)
      // },
      // {
      //   path: 'recursos-humanos',
      //   loadChildren: () => import('./../mantenimiento/mantenimiento.module').then(x => x.MantenimientoModule)
      // },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
