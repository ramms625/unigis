import { useEffect, useState } from 'react';
import { MapContainer, Marker, TileLayer, useMapEvents, useMap } from 'react-leaflet';
import markerIconPng from "leaflet/dist/images/marker-icon.png";
import { Icon } from 'leaflet';
import 'leaflet/dist/leaflet.css';




const ClickHandler = ({ onMapClick }) => {
    useMapEvents({
        click(e) {
            onMapClick(e.latlng);
        },
    });
    return null;
};

const SetViewOnChange = ({ coords }) => {
    const map = useMap();
    useEffect(() => {
        if (coords) {
            map.setView([coords.lat, coords.lng]);
        }
    }, [coords, map])
    return null;
}




const MapaForm = ({ onCoordenadasSelected, coordenadas }) => {
    const [coords, setCoords] = useState(coordenadas || null);


    // Si las coordenadas iniciales cambian, actualiza el marker
    useEffect(() => {
        if (coordenadas) {
            setCoords(coordenadas);
        }
    }, [coordenadas]);


    const handleMapClick = (latlng) => {
        setCoords(latlng);
        onCoordenadasSelected(latlng);
    };



    return (
        <MapContainer
            center={coords ? [coords.lat, coords.lng] : [19.432777, -99.133217]}
            zoom={13}
            style={{ height: "300px", width: "100%" }}
            >
            <TileLayer
                attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
            />
            <ClickHandler onMapClick={handleMapClick} />
            <SetViewOnChange coords={coords} />
            {coords && (
                <Marker
                    position={[coords.lat, coords.lng]}
                    icon={new Icon({ iconUrl: markerIconPng, iconSize: [25, 41], iconAnchor: [12, 41] })} />
            )}
        </MapContainer>
    )
}

export default MapaForm;