import { Link } from 'react-router-dom';
import '../styles/link-nuevo-punto-venta.css';

const LinkNuevoPuntoVenta = () => {
    return (
        <Link to="/nuevopuntoventa" className="lnkb-nuevo flex">
            <svg xmlns="http://www.w3.org/2000/svg" height="24px" viewBox="0 -960 960 960" width="24px" fill="#e8eaed"><path d="M440-440H200v-80h240v-240h80v240h240v80H520v240h-80v-240Z"/></svg>
            Nuevo punto de venta
        </Link>
    )
}

export default LinkNuevoPuntoVenta;