import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { deleteItem, getItems } from '../../services/api-service';
import { ShowConfirmationAlert, ShowNotification } from '../../services/notifications-service';
import { formatCurrency } from '../../helpers/format-currency';
import '../../styles/detalle.css';


const TableDetalle = () => {
    const [ventas, setVentas] = useState([]);


    const getVentas = async () => {
        const response = await getItems('puntoventas/getall');
        setVentas(response.data);
    }


    useEffect(() => {
        getVentas();
    }, []);




    const handleDelete = async (id) => {
        const resultConfirmation = await ShowConfirmationAlert('¿Deseas remover el punto de venta?');

        if (resultConfirmation.isConfirmed) {
            try {
                const response = await deleteItem(`puntoventas/delete/${id}`);
                ShowNotification({
                    message: response.message,
                    notificationType: 1
                });
                await getVentas();
            } catch (error) {
                ShowNotification({
                    message: 'Error al eliminar el registro, favor de contactar al adminstrador.',
                    notificationType: 3
                });
            }
        }
    }



    return (
        <table>
            <thead>
                <tr>
                    <th>Punto de venta</th>
                    <th>Ventas</th>
                    <th>Ubicación</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                {ventas && ventas.map((item) => {
                    return (
                        <tr key={`row-${item.id}`}>
                            <td>{ item.descripcion }</td>
                            <td>{ formatCurrency(item.ventas) }</td>
                            <td>{ item.zona.descripcion }</td>
                            <td>
                                <div className="flex">
                                    <Link className="lnkb-navigate" to={`/editarpuntoventa/${item.id}`}>Editar</Link>
                                    <button 
                                        className="btn btn-delete"
                                        onClick={() => handleDelete(item.id)}>
                                        Eliminar
                                    </button>
                                </div>
                            </td>
                        </tr>
                    )
                })}
            </tbody>
        </table>
    )
}

export default TableDetalle;