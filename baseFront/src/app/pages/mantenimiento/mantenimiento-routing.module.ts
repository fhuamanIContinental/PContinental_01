import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'persona',
    loadChildren: () => import('./mant-persona/mant-persona.module').then(x => x.MantPersonaModule)
  },
  {
    path: 'empleado',
    loadChildren: () => import('./mant-empleado/mant-empleado.module').then(x => x.MantEmpleadoModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MantenimientoRoutingModule { }
