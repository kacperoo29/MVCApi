import './App.css'

import Customers from './components/Customers';
import Orders from './components/Orders';
import MenuNavbar from './components/MenuNavbar';
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import { Menu } from 'react-bootstrap/lib/Dropdown';

export default function App() {
  return (
    <div>
    <MenuNavbar/>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Customers/>}/>
        <Route path="/orders" element={<Orders/>}/>
      </Routes>
    </BrowserRouter>
    </div>
  );
}
