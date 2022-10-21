export class PersonaModel {
    id: number;
    tipoDocumento: string;
    numeroDocumento: string;
    tipoPersona: string;
    nombre: string;
    apellidoPaterno: string;
    apellidoMaterno: string;
    fullName: string;
    genero: string;
    fechaNacimiento: Date;
    fechaRegistro: Date;
    //direcciones: PersonaDireccion[] | null;
    constructor() {
        this.id = 0;
        this.tipoDocumento = "";
        this.numeroDocumento = "";
        this.tipoPersona = "";
        this.nombre = "";
        this.apellidoPaterno = "";
        this.apellidoMaterno = "";
        this.fullName = "";
        this.genero = "";
        this.fechaNacimiento = new Date();
        this.fechaRegistro = new Date();
    }
}