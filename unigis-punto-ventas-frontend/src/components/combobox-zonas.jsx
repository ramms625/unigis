import { useEffect, useState } from 'react';
import { getItems } from "../services/api-service";

const ComboBoxZonas = ({ zonaSelected, setZonaSelected }) => {

    const [zonas, setZonas] = useState([]);


    const getZonas = async () => {
        const response = await getItems('zonas/getall');
        setZonas(response.data);
    }


    useEffect(() => {
        getZonas();
    }, []);


    return (
        <select 
            value={zonaSelected ?? -1}
            onChange={e => setZonaSelected(Number(e.target.value))} 
            name="cmbZona"
            id="cmbZona"
            className="form-control"
            >
            <option value="-1">Seleccione una zona</option>
            {zonas && zonas.map(item => {
                return (
                    <option key={item.id} value={item.id}>
                            {item.descripcion}
                    </option>
                )
            })}
        </select>
    )
}

export default ComboBoxZonas;