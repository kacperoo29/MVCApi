import './App.css'

import { Customers, Orders, Products, MenuNavbar, Cart, Categories, CustomerEdit, ContactInfoEdit, AddressEdit, ProductForm, ProductEdit } from './components'
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
							<Route exact path="/products" component={Products} />
							<Route path="/cart" component={Cart} />
							<Route path="/categories" component={Categories} />
							<Route path="/customer/:id/edit" component={CustomerEdit} />
							<Route path="/products/create" component={ProductForm} />
							<Route path="/customer/:id/edit" component={CustomerEdit} />
                            <Route path="/contactinfo/:id/edit" component={ContactInfoEdit} />
                            <Route path="/address/:id/edit" component={AddressEdit} />
						</Switch>
					</div>
				</BrowserRouter>
			</IntlProvider>
		</div>
	);
}