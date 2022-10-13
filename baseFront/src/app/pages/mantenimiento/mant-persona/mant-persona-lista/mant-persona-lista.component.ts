import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mant-persona-lista',
  templateUrl: './mant-persona-lista.component.html',
  styleUrls: ['./mant-persona-lista.component.scss']
})
export class MantPersonaListaComponent implements OnInit {


  tipoDocumento: string = "DNI";
  NroDocumento: string = "00000001";
  verSegmento: boolean = false;
  tiposDocumentos: any[] = [
    { codigo: 'DNI', descripcion: 'Documento Nacional de Identidad' },
    { codigo: 'CE', descripcion: 'Carné de extranjería' },
    { codigo: 'PAS', descripcion: 'Pasaporte' }
  ];

  constructor() { }

  ngOnInit(): void {

    setTimeout(() => {
      this.tipoDocumento = "CE";
      setTimeout(() => {
        this.tipoDocumento = "PAS";
      }, 3000);

    }, 3000);


  }


}
