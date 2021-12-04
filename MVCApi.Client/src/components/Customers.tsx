import React, { useEffect, useState } from 'react'
import { CustomerDto, CustomerApi } from '../api/index'
import { Dropdown } from 'react-bootstrap'
import { useIntl } from 'react-intl'

export default function Customers(props: any) {
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
					<p className="col-md-4">First name: {customer.firstName}</p>
					<p className="col-md-4">Last name: {customer.lastName}</p>
					<p className="col-md-4">Date of birth: {new Date(customer.dateOfBirth!).toLocaleDateString(intl.locale)}</p>
				</div>
				<div className="row">					
					<Dropdown className="col-md-6">
						<Dropdown.Toggle id={'addresses_' + id}>
							Addresses
						</Dropdown.Toggle>
						<Dropdown.Menu>
							{customer.addresses && customer.addresses.map(address =>
								<Dropdown.Item key={address.id}>{address.country + ', ' + address.postCode + ' ' + address.city + ', ' + address.street + ' ' + address.streetNumber}</Dropdown.Item>
							)}
						</Dropdown.Menu>
					</Dropdown>
					<Dropdown className="col-md-6">
						<Dropdown.Toggle id={'contacts_' + id}>
							Contact information
						</Dropdown.Toggle>
						<Dropdown.Menu>
							{customer.contactInfos && customer.contactInfos.map(contact =>
								<Dropdown.Item key={contact.id}>{contact.email + ', ' + contact.phoneNumber}</Dropdown.Item>
							)}
						</Dropdown.Menu>
					</Dropdown>
				</div>
			</div>
		))}
	</>)
}
