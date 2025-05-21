import LinkNuevoPuntoVenta from '../link-nuevo-punto-venta';
import MapaContainer from './mapa-container';
import ChartContainer from './chart-container';
import '../../styles/index.css';

const Index = () => {
    return (
        <div className="container">
            <div className="title-container flex">
                <h1>Puntos de venta</h1>
                <LinkNuevoPuntoVenta />
            </div>
            <div className="bar"></div>
            <div className="map-container">
                <MapaContainer />
            </div>
            <div className="title-container flex">
                <h2>Ventas</h2>
            </div>
            <div className="bar"></div>
            <div className="chart-container">
                <ChartContainer />
            </div>
        </div>
    )
}

export default Index;