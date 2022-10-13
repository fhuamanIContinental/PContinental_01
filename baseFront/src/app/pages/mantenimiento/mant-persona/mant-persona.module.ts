import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MantPersonaRoutingModule } from './mant-persona-routing.module';
import { MantPersonaListaComponent } from './mant-persona-lista/mant-persona-lista.component';
import { MantPersonaRegistroComponent } from './mant-persona-registro/mant-persona-registro.component';


@NgModule({
  declarations: [
    MantPersonaListaComponent,
    MantPersonaRegistroComponent
  ],
  imports: [
    CommonModule,
    MantPersonaRoutingModule
  ]
})
export class MantPersonaModule { }
