import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MantEmpleadoListaComponent } from './mant-empleado-lista/mant-empleado-lista.component';

const routes: Routes = [
  {
    path: '',
    component: MantEmpleadoListaComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MantEmpleadoRoutingModule { }
