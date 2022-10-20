//una fecha hacia tu back end
//yyyy-MM-ddTHH:mm:ss ==> back end
//BD ==> formato de fecha


export function date_to_hour(_date: Date) {
    let hour, minute, second;
    hour = _date.getHours();
    minute = _date.getMinutes();
    second = _date.getSeconds();
    return `${hour}:${minute}:${second}`;
}


export function date_to_hour_format(_date: Date) {
    try {
        let hour, minute, second;
        hour = _date.getHours().toString().padStart(2,'0');
        minute = _date.getMinutes().toString().padStart(2,'0');
        return `${hour}:${minute}:00`;
    } catch (error) {
        return "";
    }

}

export function date_string_to_hour_format(_date: string) {
    try {
        let mydate = new Date(_date);
        let hour, minute, second;
        hour = mydate.getHours();
        minute = mydate.getMinutes();
        hour = hour < 10 ? `0${hour}` : hour;
        minute = minute < 10 ? `0${minute}` : minute;
        return `${hour}:${minute}:00`;
    } catch (error) {
        return "";
    }

}



export function get_date_now() {
    let today: Date = new Date();
    let obj: any = {};
    obj.anio = today.getFullYear();
    obj.mes = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    obj.dia = String(today.getDate()).padStart(2, '0');
    return obj;
}

export function date_string_date(date: Date) {
    let obj: any = {};
    obj.anio = date.getFullYear();
    obj.mes = String(date.getMonth() + 1).padStart(2, '0'); //January is 0!
    obj.dia = String(date.getDate()).padStart(2, '0');
    return `${obj.dia}/${obj.mes}/${obj.anio}`;
}

export function date_to_string_complete(date: Date) {
    let fecha: string = "";
    let anio = date.getFullYear();
    let mes = String(date.getMonth() + 1).padStart(2, '0');
    let dia = String(date.getDate()).padStart(2, '0');
    let hora = String(date.getHours()).padStart(2, '0');
    let minuto = String(date.getMinutes()).padStart(2, '0');
    let second = "00";
    fecha = `${dia}/${mes}/${anio} ${hora}:${minuto}:${second}`
    return fecha;
}


export function date_to_string_19000101(date: Date) {
    let fecha: string = "";
    let anio = date.getFullYear();
    let mes = String(date.getMonth() + 1).padStart(2, '0');
    let dia = String(date.getDate()).padStart(2, '0');
    let hora = String(date.getHours()).padStart(2, '0');
    let minuto = String(date.getMinutes()).padStart(2, '0');
    let second = "00";
    fecha = `01/01/1900 ${hora}:${minuto}:${second}`
    return fecha;
}