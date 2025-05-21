import Swal from "sweetalert2";

/** 
* Muestra una notificación tipo toast en pantalla.
 * 
 * @param {string} params.message - Mensaje a mostrar en la notificación.
 * @param {1|2|3} [params.notificationType=1] - Tipo de notificación: 1 = 'success', 2 = 'info', 3 = 'error'.
 * 
 * @example
 * ShowNotification({ message: 'Guardado correctamente', notificationType: 1 });
*/

const ShowNotification = ({ message, notificationType = 1 }) => {
    Swal.fire({
        title: notificationType === 1 ? 'Éxito' : notificationType === 2 ? 'Atención' : 'Error',
        text: message,
        icon: notificationType === 1 ? 'success' : notificationType === 2 ? 'info' : 'error',
        timer: 3000,
        position: 'top-end',
        toast: true,
        showConfirmButton: false,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer);
            toast.addEventListener('mouseleave', Swal.resumeTimer);
        }
    });
};



const ShowConfirmationAlert = async (title) => {
    return await Swal.fire({
        title: '',
        text: title,
        icon: 'info',
        showConfirmButton: true,
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar',
        customClass: {
            confirmButton: 'btn btn-confirm-swal',
            denyButton: 'btn btn-deny-swal',
            cancelButton: 'btn btn-cancel-swal'
        }
    });
}

export { ShowNotification, ShowConfirmationAlert };