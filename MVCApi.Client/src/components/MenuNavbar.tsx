import Navbar from 'react-bootstrap/Navbar';
import { Container, Nav } from 'react-bootstrap';
import { Link } from 'react-router-dom';

export function MenuNavbar() {
	return (
		<div>
			<Navbar bg="light" expand="lg">
				<Container>
					<Link className="navbar-brand" to="/">Shop</Link>
					<Navbar.Toggle aria-controls="basic-navbar-nav" />
					<Navbar.Collapse id="basic-navbar-nav">
						<Nav className="me-auto">
							<Link to='/' className="nav-link">Home page</Link>
							<Link to='/orders' className="nav-link">Orders</Link>
							<Link to='/products' className="nav-link">Products</Link>
							<Link to='/categories' className="nav-link">Categories</Link>
						</Nav>
					</Navbar.Collapse>
					<Navbar.Collapse className="justify-content-end">
						<Link to="/cart" className="nav-link"><i className="bi bi-cart4"></i></Link>
					</Navbar.Collapse>
				</Container>
			</Navbar>
		</div>
	);
}