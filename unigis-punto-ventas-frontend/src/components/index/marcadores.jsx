import { Marker, Popup } from 'react-leaflet';
import markerIconPng from "leaflet/dist/images/marker-icon.png";
import { Icon } from 'leaflet';
import { formatCurrency } from '../../helpers/format-currency';
import 'leaflet/dist/leaflet.css';

const Marcadores = ({ ventas }) => {
    const marcadores = ventas.map((item) => {
        return (
            <Marker
                key={`marker-${item.id}`}
                position={[item.latitud, item.longitud]}
                icon={new Icon({ iconUrl: markerIconPng, iconSize: [25, 41], iconAnchor: [12, 41] })}>
                <Popup>
                    <h3>{item.descripcion}</h3>
                    <h4>{item.zona.descripcion}</h4>
                    <h4>Ventas: {formatCurrency(item.ventas)}</h4>
                </Popup>
            </Marker>
        )
    });


    return (marcadores)
}

export default Marcadores;