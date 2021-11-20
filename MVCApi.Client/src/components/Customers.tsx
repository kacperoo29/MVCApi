import React, { useEffect, useState } from 'react'
import { CustomerDto, CustomerApi } from '../api/index'
import { Table } from 'react-bootstrap'

export default function Customers (props: any) {
  const [customers, setCustomers] = useState<CustomerDto[] | []>([])
  
  useEffect((api = new CustomerApi()) => {
    api.apiCustomerGetAllCustomersGet().then(response => setCustomers(response))
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
          <td>{customer.dateOfBirth?.toDateString()}</td>
        </tr>
      ))}
    </tbody>
  </Table>)
}
