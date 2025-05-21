import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import MapaForm from '../mapa-form';
import ComboBoxZonas from '../combobox-zonas';
import { ShowConfirmationAlert, ShowNotification} from '../../services/notifications-service';
import { ValidateForm } from '../../helpers/validate-form';
import { createItem } from '../../services/api-service';
import '../../styles/nuevo-punto-venta.css';



const NuevoPuntoVenta = () => {


    useEffect(() => {
        document.title = 'Gestión de puntos de venta - Nuevo';
    }, []);
    

    const [coords, setCoords] = useState(null);
    const [zonaSelected, setZonaSelected] = useState(-1);
    const [descripcion, setDescripcion] = useState('');
    const [ventas, setVentas] = useState('');
    const navigate = useNavigate();


    const recibirCoords = (value) => {
        setCoords(value);
    };
    

    const handleSubmit = async (e) => {
        e.preventDefault();

        const validationResult = ValidateForm(0, descripcion, ventas, zonaSelected, coords);
        
        if (!validationResult.isSuccedded) {
            ShowNotification({
                message: validationResult.message,
                notificationType: 3
            });
            return;
        }


        const resultConfirmation = await ShowConfirmationAlert('¿Deseas crear el siguiente punto de venta?');

        if (resultConfirmation.isConfirmed) {
            const data = validationResult.data;
            const response = await createItem('puntoventas/post', data);

            ShowNotification({
                message: response.message,
                notificationType: 1
            });

            setTimeout(() => {
                navigate('/');
            }, 3000);
        }
    }


    return (
        <div className="container">
            <div className="title-container flex">
                <h1>Nuevo punto de venta</h1>
            </div>
            <div className="bar"></div>
            <form onSubmit={handleSubmit}>
                <div className="form-container">
                    <div className="col">
                        <span>Ubicación</span>
                        <div className="mapa-container">
                            <MapaForm onCoordenadasSelected={recibirCoords} /*coordenadas={{lat: 19.3862, lng: -99.1355}}*/ />
                        </div>
                    </div>
                    <div className="col">
                        <div className="form-group">
                            <label htmlFor="descripcion">Descripción:</label>
                            <input 
                                type="text"
                                name="descripcion"
                                id="descripcion"
                                className="form-control"
                                placeholder="Descripción"
                                value={descripcion}
                                onChange={e => setDescripcion(e.target.value)} />
                        </div>
                        <div className="form-group">
                            <label htmlFor="ventas">Total de ventas:</label>
                            <input
                                type="number"
                                name="ventas"
                                id="ventas"
                                className="form-control"
                                placeholder="Total de ventas"
                                min={1}
                                step="any"
                                value={ventas}
                                onChange={e => setVentas(e.target.value)} />
                        </div>
                        <div className="form-group">
                            <label htmlFor="cmbZona">Zona:</label>
                            <ComboBoxZonas zonaSelected={zonaSelected} setZonaSelected={setZonaSelected} />
                        </div>
                        <div className="form-group">
                            <span>Coordenadas:</span>
                            <span>{coords ? `${coords.lat},   ${coords.lng}` : 'Selecciona un punto en el mapa'}</span>
                        </div>
                    </div>
                </div>
                <button type="submit" className="btn btn-primary btn-form">
                    Crear
                </button>
            </form>
        </div>
    )
}

export default NuevoPuntoVenta;