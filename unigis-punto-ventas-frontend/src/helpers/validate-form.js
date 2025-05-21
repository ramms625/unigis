export const ValidateForm = (id, descripcion, ventas, zonaSelected, coords) => {
    const result = {
        data: null,
        isSuccedded: false,
        message: ''
    }


    if (!descripcion.trim()) {
        result.message = 'La descripción es obligatoria.';
        return result;
    }

    if (!ventas.trim()) {
        result.message = 'El total de ventas es obligatorio.';
        return result;
    }
    else if (!((/^\d*\.?\d*$/.test(ventas) && Number(ventas) >= 0))) {
        result.message = 'El total de ventas debe ser un válor numérico mayor a 0.';
        return result;
    }

    if (zonaSelected === -1 || !coords) {
        result.message = 'Debes seleccionar una zona y una ubicación en el mapa.';
        return result;
    }


    const data = {
        id: id,
        descripcion: descripcion,
        latitud: coords.lat,
        longitud: coords.lng,
        ventas: Number(ventas),
        idZona: zonaSelected
    }

    result.data = data;
    result.isSuccedded = true;


    return result;
}