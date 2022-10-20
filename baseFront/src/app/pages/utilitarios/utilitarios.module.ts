import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomDatePickerComponent } from './custom-date-picker/custom-date-picker.component';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

@NgModule({
  declarations: [
    CustomDatePickerComponent
  ],
  imports: [
    CommonModule,
    ModalModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    BsDatepickerModule.forRoot(),
  ],
  exports: [
    ModalModule,
    ReactiveFormsModule,
    FormsModule,
    
    BsDatepickerModule,
    //exportando componentes
    CustomDatePickerComponent,
  ]
})
export class UtilitariosModule { }
