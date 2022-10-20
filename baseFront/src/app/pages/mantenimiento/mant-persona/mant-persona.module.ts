import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MantPersonaRoutingModule } from './mant-persona-routing.module';
import { MantPersonaListaComponent } from './mant-persona-lista/mant-persona-lista.component';
import { MantPersonaRegistroComponent } from './mant-persona-registro/mant-persona-registro.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MantEmpleadoModule } from '../mant-empleado/mant-empleado.module';
import { UtilitariosModule } from '../../utilitarios/utilitarios.module';

@NgModule({
  declarations: [
    MantPersonaListaComponent,
    MantPersonaRegistroComponent
  ],
  imports: [
    CommonModule,
    MantPersonaRoutingModule,
    UtilitariosModule
    /* 
    ==> ESTAS TRES LIBRERÍAS VIENEN DESDE UTILITARIOS MODULE
    ModalModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    */
    // MantEmpleadoModule
  ]
})
export class MantPersonaModule { }
