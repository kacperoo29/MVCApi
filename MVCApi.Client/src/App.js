import logo from './logo.svg'
import './App.css'

import axios from 'axios'
import React, { Component } from 'react'

class App extends Component {
  constructor () {
    super()
    this.state = { data: [] }
  }

  componentDidMount () {
    axios
      .get('https://localhost:5001/api/Customer/GetAllCustomers')
      .then(res => this.setState({ data: res.data }))
  }

  render () {
    return (
      <div>
        <ul>
          {this.state.data.map(customer => (
            <li>{customer['id']}</li>
          ))}
        </ul>
      </div>
    )
  }
}

export default App
