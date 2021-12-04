import './App.css'

import Customers from './components/Customers';
import Orders from './components/Orders';
import Products from './components/Products';
import MenuNavbar from './components/MenuNavbar';
import Cart from './components/Cart'
import Categories from './components/Categories'
import { BrowserRouter, Switch, Route } from 'react-router-dom'
import { IntlProvider } from 'react-intl';

export default function App() {
    return (
        <div>
            <IntlProvider locale={navigator.language}>                
                    <BrowserRouter>
                    <MenuNavbar />
                    <div className='container'>
                        <Switch>
                            <Route exact path="/" component={Customers} />
                            <Route path="/orders" component={Orders} />
                            <Route path="/products" component={Products} />
                            <Route path="/cart" component={Cart} />
                            <Route path="/categories" component={Categories} />
                        </Switch>
                        </div>
                    </BrowserRouter>                
            </IntlProvider>
        </div>
    );
}
