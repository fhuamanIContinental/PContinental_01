import { Component, OnInit } from '@angular/core';
import { PersonaModel } from 'src/app/models/persona.model';
import { PersonaService } from 'src/app/service/persona.service';

@Component({
  selector: 'app-mant-persona-lista',
  templateUrl: './mant-persona-lista.component.html',
  styleUrls: ['./mant-persona-lista.component.scss']
})
export class MantPersonaListaComponent implements OnInit {

  /*
    PERSONA
      TIPO DE DOCUMENTO
      NRO DE DOCUMENTO
      FULL NAME
      GENERO 
  */
  personas: PersonaModel[] = [];

  constructor(
    private _personaService: PersonaService
  ) { }

  ngOnInit(): void {

    console.log("primer metodo a ejecutarse");
    this.getAllPersonas();
  }

  getAllPersonas() {
    this._personaService.getAll().subscribe(
      (data: PersonaModel[]) => {
        this.personas = data;
        console.log(data);

      },
      err => {
        console.log("ocurrio un error", err);

      }
    );

  }


}
