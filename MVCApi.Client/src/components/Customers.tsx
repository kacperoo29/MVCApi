import React, { useEffect, useState } from 'react'
import { CustomerDto, CustomerApi } from '../api/index'
import { Table } from 'react-bootstrap'
import { useIntl } from 'react-intl'

export default function Customers (props: any) {
  const [customers, setCustomers] = useState<CustomerDto[] | []>([])
  const intl = useIntl()
  
  useEffect((api = new CustomerApi()) => {
    api.apiCustomerGetAllCustomersGet().then(response => {
      setCustomers(response)
    })
  }, [])

  return (<Table striped bordered hover>
    <thead>
      <tr>
        <th>First name</th>
        <th>Last name</th>
        <th>Date of birth</th>
      </tr>
    </thead>
    <tbody>
      {customers.map(customer => (
        <tr key={customer.id}>
          <td>{customer.firstName}</td>
          <td>{customer.lastName}</td>
          <td>{new Date(customer.dateOfBirth!).toLocaleDateString(intl.locale)}</td>
        </tr>
      ))}
    </tbody>
  </Table>)
}
