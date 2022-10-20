import Swal from 'sweetalert2';



export function alert_success(title: string, timer?: number) {
  Swal.fire({
    icon: 'success',
    title: title,
    position: 'top-end',
    showConfirmButton: false,
    timer: timer == null || timer == undefined ? 1500 : timer
  });
}


export function alert_warning(title: string) {
  Swal.fire({
    //position: 'top-end',
    icon: 'warning',
    title: title,
    showConfirmButton: false,
    timer: 3000
  });
}

export function alert_error(title: string, message: string) {
  Swal.fire({
    icon: 'error',
    title: title,
    text: message,
    showConfirmButton: false,
    timer: 3000
  });
}


export function alert_delete() {
  Swal.fire({
    title: "¿Está seguro?",
    text: "¡No podrás revertir esto!",
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Si, Eliminar'
  }).then((result) => {
    if (result.isConfirmed) {
      return true;
      // Swal.fire(
      //   'Eliminado!',
      //   'Registro eliminado de forma satisfactoría.',
      //   'success'
      // )
    }
    else {
      return false;
    }
  })
}

export async function alert_confirm(title: string, text: string) {
  let res: boolean = false;
  Swal.fire({
    title: title,
    text: text,
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Yes, delete it!'
  }).then((result) => {
    return result.isConfirmed;
  }
  ).catch((er) => {
    return false;
  });

}




