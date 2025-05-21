import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getItem, updateItem } from '../../services/api-service';
import MapaForm from '../mapa-form';
import ComboBoxZonas from '../combobox-zonas';
import { ShowConfirmationAlert, ShowNotification } from '../../services/notifications-service';
import { ValidateForm } from '../../helpers/validate-form';
import '../../styles/nuevo-punto-venta.css';



const EditarPuntoVenta = () => {

    const { id } = useParams();
    const navigate = useNavigate();
    const [puntoVenta, setPuntoVenta] = useState(null);


    const [coords, setCoords] = useState(null);
    const [zonaSelected, setZonaSelected] = useState(-1);
    const [descripcion, setDescripcion] = useState('');
    const [ventas, setVentas] = useState('');


    const getPuntoVenta = async () => {
        try {
            const response = await getItem(`puntoventas/get/${id}`);
            setPuntoVenta(response.data);
        } catch (error) {
            navigate('/404');
        }
    };


    // Inicializa los estados locales cuando se carga puntoVenta
    useEffect(() => {
        if (puntoVenta) {

            setDescripcion(puntoVenta.descripcion ?? '');
            setVentas(puntoVenta.ventas ?? '');
            setZonaSelected(puntoVenta.zona?.id ?? -1);
            setCoords({
                lat: puntoVenta.latitud,
                lng: puntoVenta.longitud
            });

        }
    }, [puntoVenta]);


    useEffect(() => {
        getPuntoVenta();
    }, [id, navigate]);



    const recibirCoords = (value) => {
        setCoords(value);
    };


    const handleSubmit = async (e) => {
        e.preventDefault();

        const validationResult = ValidateForm(
            puntoVenta.id,
            descripcion,
            ventas,
            zonaSelected,
            coords
        );

        if (!validationResult.isSuccedded) {
            ShowNotification({
                message: validationResult.message,
                notificationType: 3
            });
            return;
        }


        const resultConfirmation = await ShowConfirmationAlert('¿Deseas actualizar el punto de venta?');


        if (resultConfirmation.isConfirmed) {
            const data = validationResult.data;

            try {
                const response = await updateItem(`puntoventas/update/${data.id}`, data);
                ShowNotification({
                    message: response.message,
                    notificationType: 1
                });

                setTimeout(() => {
                    navigate('/');
                }, 3000);

            } catch (error) {
                ShowNotification({
                    message: 'Error al actualizar el punto de venta',
                    notificationType: 3
                });
            }
        }
    };


    if (!puntoVenta) return null;


    return (
        <div className="container">
            <div className="title-container flex">
                <h1>Editar punto de venta</h1>
            </div>
            <div className="bar"></div>
            <form onSubmit={handleSubmit}>
                <div className="form-container">
                    <div className="col">
                        <span>Ubicación</span>
                        <div className="mapa-container">
                            <MapaForm
                                onCoordenadasSelected={recibirCoords}
                                coordenadas={coords}/>
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
                                onChange={e => setDescripcion(e.target.value)}
                            />
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
                                onChange={e => setVentas(e.target.value)}
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="cmbZona">Zona:</label>
                            <ComboBoxZonas zonaSelected={zonaSelected} setZonaSelected={setZonaSelected} />
                        </div>
                        <div className="form-group">
                            <span>Coordenadas:</span>
                            <span>{coords ? `${coords.lat}, ${coords.lng}` : 'Selecciona un punto en el mapa'}</span>
                        </div>
                    </div>
                </div>
                <button type="submit" className="btn btn-primary btn-form">
                    Actualizar
                </button>
            </form>
        </div>
    );
};

export default EditarPuntoVenta;