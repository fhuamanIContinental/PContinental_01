import { Component, OnInit, TemplateRef } from '@angular/core';
import { PersonaModel } from 'src/app/models/persona.model';
import { PersonaService } from 'src/app/service/persona.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { bsConfigModal } from 'src/app/constantes/modal.constants';
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
  personaSeleccionada: PersonaModel = new PersonaModel();
  //cuando la variable tenga un signo de interrogación "?", indica que puede tener un valor NULL
  // ==> modalRef?: BsModalRef;
  modalRef: BsModalRef = new BsModalRef();

  tituloModal: string = "";

  constructor(
    private _personaService: PersonaService,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {

    console.log("primer metodo a ejecutarse");
    this.getAllPersonas();
  }

  getAllPersonas() {
    this.personas = [];
    setTimeout(() => {
      this._personaService.getAll().subscribe(
        (data: PersonaModel[]) => {
          this.personas = data;
          console.log(data);
        },
        err => {
          console.log("ocurrio un error", err);
        }
      );
    }, 200);

  }


  NuevaPersona(template: TemplateRef<any>) {
    this.tituloModal = "Nueva Persona";
    this.personaSeleccionada = new PersonaModel();
    this.openModal(template);
  }
  editarPersona(item: PersonaModel, template: TemplateRef<any>) {
    this.tituloModal = "Editar Persona";
    this.personaSeleccionada = item;
    this.openModal(template);
  }

  openModal(template: TemplateRef<any>) {
    //this.modalRef = this.modalService.show(template);
    this.modalRef =
      this.modalService.show(
        template,
        Object.assign({}, { class: "gray modal-xl" },
          bsConfigModal));

  }

  recibeFuncionCerrarModal(res: boolean) {
    this.modalService.hide();
    if (res) {
      this.getAllPersonas();
    }

  }

  deletePersona(id: number) {
    let res = confirm("¿Está de seguro de eliminar este registro?");
    if (res) {
      this._personaService.delete(id).subscribe(
        (data: any) => {
          alert("registro eliminado de forma correcta");
          this.getAllPersonas();
        },
        err => {
          alert("Ocurrio un error");
        }
      );
    }
  }
}