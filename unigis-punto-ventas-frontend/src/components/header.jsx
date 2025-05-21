import { useState } from 'react';
import '../styles/header.css';
import { Link } from 'react-router-dom';

const Header = () => {

    const [menuVisible, setMenuVisible] = useState(false);
    const toggleMenu = () => setMenuVisible(!menuVisible);

    return (
        <header>
            <nav className="container flex">
                <Link className="nav-brand" to="/">UNIGIS</Link>
                <div className="menu-icons">
                    <span id="bars" className="flex" onClick={toggleMenu}>
                        <svg xmlns="http://www.w3.org/2000/svg" height="24px" viewBox="0 -960 960 960" width="24px" fill="#e8eaed"><path d="M120-240v-80h720v80H120Zm0-200v-80h720v80H120Zm0-200v-80h720v80H120Z"/></svg>
                    </span>
                </div>
                <ul className={`menu flex${menuVisible ? ' show' : ''}`}>
                    <li><Link to="/detalle">Detalle</Link></li>
                    <li><Link to="/nuevopuntoventa">Nuevo punto de venta</Link></li>
                </ul>
            </nav>
        </header>
    )
};

export default Header;