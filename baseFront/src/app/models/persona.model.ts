export class PersonaModel {
    id: number;
    tipo_documento: string;
    numero_documento: string;
    tipo_persona: string;
    nombre: string;
    apellido_paterno: string;
    apellido_materno: string;
    full_name: string;
    genero: string;
    fecha_nacimiento: Date;
    fecha_registro: Date;
    //direcciones: PersonaDireccion[] | null;
    constructor() {
        this.id = 0;
        this.tipo_documento = "";
        this.numero_documento = "";
        this.tipo_persona = "";
        this.nombre = "";
        this.apellido_paterno = "";
        this.apellido_materno = "";
        this.full_name = "";
        this.genero = "";
        this.fecha_nacimiento = new Date();
        this.fecha_registro = new Date();
    }
}