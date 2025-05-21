import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Index from './components/index';
import Header from './components/header';
import Detalle from './components/detalle/detalle';
import NuevoPuntoVenta from './components/nuevo-punto-venta/nuevo-punto-venta';
import EditarPuntoVenta from './components/editar-punto-venta/editar-punto-venta';
import NotFound from './components/not-found';

function App() {
    return (
        <BrowserRouter>
            <Header />
            <main>
                <Routes>
                    <Route path="/" element={<Index />} />
                    <Route path="/index" element={<Index />} />
                    <Route path="/home" element={<Index />} />
                    <Route path="/detalle" element={<Detalle />} />
                    <Route path="/nuevopuntoventa" element={<NuevoPuntoVenta />} />
                    <Route path="/editarpuntoventa/:id" element={<EditarPuntoVenta />} />
                    <Route path="/404" element={<NotFound/>} />
                </Routes>
            </main>
        </BrowserRouter>
    );
}

export default App;