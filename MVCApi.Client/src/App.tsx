import './App.css'

//import axios from 'axios'
import React, { useState } from 'react'
import { CustomerDto, CustomerApi } from './api/index'

export default function App() {
  const [customers, setCustomers] = useState<CustomerDto[] | []>([])
  const api = new CustomerApi();

  api.apiCustomerGetAllCustomersGet().then(response => setCustomers(response))

  return (
    <ul>
      {customers.map(customer => <li>{customer.id}</li>)}
    </ul>
  )
}
