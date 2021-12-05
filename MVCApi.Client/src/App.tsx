import './App.css'

import Customers from './components/Customers';
import Orders from './components/Orders';
import Products from './components/Products';
import MenuNavbar from './components/MenuNavbar';
import CustomerEdit from './components/CustomerEdit';
import ContactInfoEdit from './components/ContactInfoEdit';
import AddressEdit from './components/AddressEdit';
import Cart from './components/Cart'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { IntlProvider } from 'react-intl';

export default function App() {
  return (
    <div>
      <IntlProvider locale={navigator.language}>
      <MenuNavbar />
      <div className='container'>
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<Customers />} />
            <Route path="/orders" element={<Orders />} />
            <Route path="/products" element={<Products />} />
            <Route path="/cart" element={<Cart />} />
            <Route path="/customer/:id/edit" element={<CustomerEdit/>}/>
            <Route path="/contactInfo/:id/edit" element={<ContactInfoEdit/>}/>
            <Route path="/address/:id/edit" element={<AddressEdit/>}/>
            
          </Routes>
        </BrowserRouter>
        </div>
        </IntlProvider>
    </div>
  );
}
