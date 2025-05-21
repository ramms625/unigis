import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Index from './components/index';
import Header from './components/header';
import Detalle from './components/detalle/detalle';
import NuevoPuntoVenta from './components/nuevo-punto-venta/nuevo-punto-venta';

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
                </Routes>
            </main>
        </BrowserRouter>
    );
}

export default App;