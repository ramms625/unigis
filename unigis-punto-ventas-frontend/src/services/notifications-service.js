import Swal from "sweetalert2";

export const NotificationType = {
    Success: 'success',
    Error: 'error',
    Info: 'info'
}

const ShowNotification = ({ message, notificationType: NotificationType = NotificationType.Info }) => {
    Swal.fire({
        title: notificationType == NotificationType.Success ? 'Éxito' : notificationType == NotificationType.Error ? 'Error' : 'Atención',
        text: message,
        icon: notificationType,
        timer: 3000,
        position: 'top-end',
        toast: true,
        showConfirmButton: false,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer);
            toast.addEventListener('mouseleave', Swal.resumeTimer);
        }
    });
}

export default ShowNotification;