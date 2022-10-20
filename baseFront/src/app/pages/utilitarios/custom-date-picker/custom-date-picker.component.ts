import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BsDatepickerModule, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { esLocale } from 'ngx-bootstrap/locale';
defineLocale("es", esLocale);

@Component({
  selector: 'app-custom-date-picker',
  templateUrl: './custom-date-picker.component.html',
  styleUrls: ['./custom-date-picker.component.scss']
})
export class CustomDatePickerComponent implements OnInit {

  @Input() bsValue = new Date();
  @Input() colortheme: string = "theme-blue";
  @Output() changeDateEmmiter = new EventEmitter<Date>();

  constructor(
    private localeService: BsLocaleService
  ) { 
    this.localeService.use("es");
  }

  ngOnInit(): void {
  }

  changeDate() {
    this.changeDateEmmiter.emit(this.bsValue);
  }

  
}
