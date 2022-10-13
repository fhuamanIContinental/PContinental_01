import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MantPersonaListaComponent } from './mant-persona-lista/mant-persona-lista.component';

const routes: Routes = [
  {
    path: '',
    component: MantPersonaListaComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MantPersonaRoutingModule { }
