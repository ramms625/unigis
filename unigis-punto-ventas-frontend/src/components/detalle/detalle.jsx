import { useEffect } from 'react';
import LinkNuevoPuntoVenta from '../link-nuevo-punto-venta';
import TableDetalle from './table-detalle';
import '../../styles/detalle.css';

const Detalle = () => {

    useEffect(() => {
        document.title = 'Gestión de puntos de venta - Detalle';
    }, []);

    return (
        <div className="container">
            <div className="title-container flex">
                <h1>Detalle de puntos de venta</h1>
                <LinkNuevoPuntoVenta />
            </div>
            <div className="bar"></div>
            <div className="detalle-container">
                <div className="table-container">
                    <TableDetalle />
                </div>
            </div>
        </div>
    )
}

export default Detalle;