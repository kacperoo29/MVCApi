import './App.css'

//import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { CustomerDto, CustomerApi } from './api/index'

export default function App() {
  const [customers, setCustomers] = useState<CustomerDto[] | []>([])
  const api = new CustomerApi();

  useEffect(() => {
    api.apiCustomerGetAllCustomersGet().then(response => setCustomers(response))
  }, [])

  return (
    <ul>
      {customers.map(customer => <li>{customer.id}</li>)}
    </ul>
  )
}
