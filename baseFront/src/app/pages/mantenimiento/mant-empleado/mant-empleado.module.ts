import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MantEmpleadoRoutingModule } from './mant-empleado-routing.module';
import { MantEmpleadoListaComponent } from './mant-empleado-lista/mant-empleado-lista.component';
import { MantEmpleadoRegistroComponent } from './mant-empleado-registro/mant-empleado-registro.component';


@NgModule({
  declarations: [
    MantEmpleadoListaComponent,
    MantEmpleadoRegistroComponent
  ],
  imports: [
    CommonModule,
    MantEmpleadoRoutingModule
  ],
  exports:[
    // MantEmpleadoListaComponent
  ]
})
export class MantEmpleadoModule { }
