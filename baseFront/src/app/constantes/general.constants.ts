/*
    CONSTANTES QUE NOS A SERVIR PARA TODA NUESTRA APLICACIÓN
*/

export const meses_const = [
    { id: "01", name: "Enero" },
    { id: "02", name: "Febrero" },
    { id: "03", name: "Marzo" },
    { id: "04", name: "Abril" },
    { id: "05", name: "Mayo" },
    { id: "06", name: "Junio" },
    { id: "07", name: "Julio" },
    { id: "08", name: "Agosto" },
    { id: "09", name: "Setiembre" },
    { id: "10", name: "Octubre" },
    { id: "11", name: "Noviembre" },
    { id: "12", name: "Diciembre" }
]

export const accion_Const = {
    add: 1,
    edit: 2,
    config: 3,
    delete: 4
}

//<input class="form-control" patter="[0-9]{8}">
export const patterns = {
    username: "^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$",
    email: "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[a-z]{2,4}$",
    onlyLetter: "^[a-zA-Z]*$",
    onlyNumber: "^[0-9]",
    letterAndNumber:"[A-Za-z0-9]*$",
    password: "/^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,30}$/"
}


export const statesConstant =
{
    Activo: 1,
    Inactivo: 2,
    Elimininado: 3
}

export const statesConstant_ActiveInactive = [
    {
        id: 1,
        description: "Activo"
    },
    {
        id: 2,
        description: "Inactivo"
    },
    {
        id: 3,
        description: "suspendido"
    }

]

export const statesConstant_ActiveInactiveFilter = [
    {
        value: 1,
        label: "Activo"
    },
    {
        value: 2,
        label: "Inactivo"
    }
]