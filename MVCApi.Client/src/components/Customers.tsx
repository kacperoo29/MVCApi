import React, { useEffect, useState } from 'react'
import { CustomerDto, CustomerApi } from '../api/index'
import { Dropdown } from 'react-bootstrap'
import { useIntl } from 'react-intl'
import { Link } from 'react-router-dom'

export function Customers() {
	const [customers, setCustomers] = useState<CustomerDto[] | []>([])
	const intl = useIntl()

	useEffect((api = new CustomerApi()) => {
		api.apiCustomerGetAllCustomersGet().then(response => {
			setCustomers(response)
		})
	}, [])

	return (<>
		{customers.map((customer, id) => (
			<div key={customer.id} className="rounded border p-2">
				<div className="row">
					<p className="col-md-3">First name: {customer.firstName}</p>
					<p className="col-md-3">Last name: {customer.lastName}</p>
					<p className="col-md-3">Date of birth: {new Date(customer.dateOfBirth!).toLocaleDateString(intl.locale)}</p>
					<p className="col-md-3"><Link className='btn btn-primary ml-2' to={`/customer/${customer.id}/edit`}>Edit</Link></p>
				</div>
				<div className="row">					
					<Dropdown className="col-md-6">
						<Dropdown.Toggle id={'addresses_' + id}>
							Addresses
						</Dropdown.Toggle>
						<Dropdown.Menu>
							{customer.addresses && customer.addresses.map(address =>
								<Dropdown.Item key={address.id}>
									{'Country: ' + address.country + ', ' + 'Post code: ' + address.postCode + ', ' + 'City:' + address.city + ', ' + 'Street: ' + address.street + ' ' + 'Street number: ' + address.streetNumber + ' '}
									<Link className='btn btn-primary ml-2' to={`/address/${address.id}/edit`}>Edit</Link>
								</Dropdown.Item>
							)}
						</Dropdown.Menu>
					</Dropdown>
					<Dropdown className="col-md-6">
						<Dropdown.Toggle id={'contacts_' + id}>
							Contact information
						</Dropdown.Toggle>
						<Dropdown.Menu>
							{customer.contactInfos && customer.contactInfos.map(contact =>
								<Dropdown.Item key={contact.id}>{'Email: ' + contact.email + ', ' + ' Phone number: ' + contact.phoneNumber + ' '}
									<Link className='btn btn-primary ml-2' to={`/contactinfo/${contact.id}/edit`}>Edit</Link></Dropdown.Item>
							)}
						</Dropdown.Menu>
					</Dropdown>
				</div>
			</div>
		))}
		<Link className='btn btn-primary' to={`/customers/create`}>Add</Link>
	</>)
}
