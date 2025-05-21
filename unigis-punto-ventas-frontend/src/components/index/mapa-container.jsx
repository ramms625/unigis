import { useEffect, useState } from 'react';
import { MapContainer, TileLayer } from 'react-leaflet';
import { getItems } from '../../services/api-service';
import Marcadores from './marcadores';
import 'leaflet/dist/leaflet.css';


const MapaContainer = () => {

    const [ventas, setVentas] = useState([]);


    const getVentas = async () => {
        const response = await getItems('puntoventas/getall');
        setVentas(response.data);
    }


    useEffect(() => {
        getVentas();
    }, []);


    return (
        <MapContainer center={[19.3900, -99.1332]} zoom={11} style={{ height: "100%", width: "100%" }}>
            <TileLayer
                attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
            <Marcadores ventas={ventas} />
        </MapContainer>
    )
}

export default MapaContainer;