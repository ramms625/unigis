import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { getItems } from '../../services/api-service';
import { formatCurrency } from '../../helpers/format-currency';
import '../../styles/detalle.css';


const TableDetalle = () => {
    const [ventas, setVentas] = useState([]);


    const getVentas = async () => {
        const response = await getItems('puntoventas/getall');
        setVentas(response.data);
        console.log(response.data)
    }


    useEffect(() => {
        getVentas();
    }, []);



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
                                    <Link className="lnkb-navigate" to="/editarpuntoventa">Editar</Link>
                                    <button className="btn btn-delete">
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