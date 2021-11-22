import Navbar from 'react-bootstrap/Navbar';
import { Container, Nav } from 'react-bootstrap';

export default function MenuNavbar(){
    return(
        <div>
            <Navbar bg="light" expand="lg">
              <Container>
                <Navbar.Brand href="/">Shop</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                  <Nav className="me-auto">
                    <Nav.Link href="/">Home page</Nav.Link>
                    <Nav.Link href="/orders">Orders</Nav.Link>
                    <Nav.Link href="/products">Products</Nav.Link>
                    <Nav.Link href="/cart">Cart</Nav.Link>
                  </Nav>
                </Navbar.Collapse>
              </Container>
          </Navbar>
        </div>
    );
}