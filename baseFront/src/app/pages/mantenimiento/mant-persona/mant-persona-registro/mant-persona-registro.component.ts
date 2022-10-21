import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonaModel } from 'src/app/models/persona.model';
import { PersonaService } from 'src/app/service/persona.service';

@Component({
  selector: 'app-mant-persona-registro',
  templateUrl: './mant-persona-registro.component.html',
  styleUrls: ['./mant-persona-registro.component.scss']
})
export class MantPersonaRegistroComponent implements OnInit {

  @Input() titulo: string = "";
  @Input() persona: PersonaModel = new PersonaModel();
  @Output() closeModalEmit = new EventEmitter<boolean>();

  //declaramos nuestro formulario
  formularioPersona: FormGroup;

  constructor(
    private fb: FormBuilder,
    private _personaService:PersonaService
  ) {
    //expresiones regulares
    this.formularioPersona = this.fb.group({
      id: [{ value: null, disabled: true }, [Validators.required]],
      tipoDocumento: [null, [Validators.required]],
      numeroDocumento: [null, [Validators.required,Validators.maxLength(15), Validators.minLength(8), Validators.email]],
      tipoPersona: [null, [Validators.required]],
      nombre: [null, [Validators.required]],
      apellidoPaterno: [null, [Validators.required]],
      apellidoMaterno: [null, [Validators.required]],
      fullName: [{ value: null, disabled: true }, []],
      genero: [null, [Validators.required]],
      fechaNacimiento: [null, [Validators.required]],
      fechaRegistro: [null, [Validators.required]]
    });
  }

  get f() { return this.formularioPersona.controls; }
  ngOnInit(): void {
    //ASIGNAR UN VALOR A UN CONTROL EN ESPECIFICO
    // this.formularioPersona.controls["full_name"]?.setValue("NOMBRE COMPLETO");

    //VAMOS A ASIGNAR LOS VALORES A TODO EL FORMULARIO solo cuando el formulario
    // tenga los mismos controles que nuestro modelo a asignar
    //this.formularioPersona.setValue(this.persona);


    this.formularioPersona.patchValue(this.persona);
    this.formularioPersona.get("fullName")?.setValue("NOMBRE COMPLETO");
    this.formularioPersona.controls["fechaNacimiento"].setValue(new Date());
    this.formularioPersona.controls["fechaRegistro"].setValue(new Date());
    console.log(this.persona);

  }

  //vamos a recibir una variable de tipo boolean ==> true/false
  cerrarModal(res: boolean) {
    this.closeModalEmit.emit(res);
  }

  guardarDatos() {

    this.formularioPersona.controls["fechaNacimiento"].setValue(new Date());
    this.formularioPersona.controls["fechaRegistro"].setValue(new Date());
    //esta es una forma de obtener los datos del formulario
    //pero no trae el valor de los con controles que esten inhabilitados
    // let formData = this.formularioPersona.value;
    let formData:PersonaModel = this.formularioPersona.getRawValue();
    console.log(formData);
    

    if(formData.id == 0)
    {
      //crear un registro
      this.crearRegistro(formData)
    }
    else {
      this.actualizarRegistro(formData)
      //actualizar un registro
    }
    // console.log("formulario no valido", this.formularioPersona.invalid);
    // console.log(this.formularioPersona?.errors);
    // console.log("id", this.formularioPersona.get("id")?.errors);
    // console.log("tipo_documento", this.formularioPersona.get("tipo_documento")?.errors);
    // console.log("numero_documento", this.formularioPersona.get("numero_documento")?.errors);
    // console.log("tipo_persona", this.formularioPersona.get("tipo_persona")?.errors);
    // console.log("nombre", this.formularioPersona.get("nombre")?.errors);
    // console.log("apellido_paterno", this.formularioPersona.get("apellido_paterno")?.errors);
    // console.log("apellido_materno", this.formularioPersona.get("apellido_materno")?.errors);
    // console.log("full_name", this.formularioPersona.get("full_name")?.errors);
    // console.log("genero", this.formularioPersona.get("genero")?.errors);
    // console.log("fecha_nacimiento", this.formularioPersona.get("fecha_nacimiento")?.errors);
    // console.log("fecha_registro", this.formularioPersona.get("fecha_registro")?.errors);
  }
  
  crearRegistro(item:PersonaModel)
  {
    this._personaService.create(item).subscribe(
      (data:PersonaModel)=> {
        alert("Registro Creado de forma satisfactoría")
        this.cerrarModal(true);
      }
    );
  }
  actualizarRegistro(item:PersonaModel)
  {
    this._personaService.update(item) .subscribe(
      (data:PersonaModel)=> {
        alert("Registro Actualizado de forma satisfactoría")
        this.cerrarModal(true);
      }
    );
  }

}
