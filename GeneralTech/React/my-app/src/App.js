import axios from 'axios';
import React, { useEffect, useState } from 'react';
import './App.css';
import logo from './logo.svg';

// Example usage

function RRow(props) {
  console.log(props)

  const pp = Object.entries(props.dd)
  let x = pp.map(kvp => <td key={props.inx + kvp[0]}>{kvp[1]}</td>)

  return (

    <tr key={props.inx}>

      {x}
      {/* <tr> <td>{props.inx}</td><td>{props.dd.date}-&gt;</td><td>{props.dd.temperatureC}</td></tr > */}
    </tr>

  )

}
function App() {
  const [data, setData] = useState([])
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get('http://localhost:5000/weatherforecast')
        setData(() => response.data)
        //  console.log(response.data)
      } catch (error) {
        console.error("Error fetching data", error)
      }
    }
    fetchData()

  }, [])
  return (

    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>

        <div>
          {/* {console.log(`data=${data}`)} */}
          {

            (data.length > 0) ?
              <table>
                <thead ><tr><th>index</th><th>date</th><th>temperature</th></tr></thead>
                <tbody>
                  {
                    data.map((w, index) => (
                      <RRow dd={w} inx={index} key={index} />
                    ))

                  }
                </tbody>
              </table>
              // <ul>
              //   {data.map(
              //     (w, index) => (
              //       <li key={index}><span>{w.date}-&gt;</span><span>{w.temperatureC}</span></li>
              //     )
              //   )}
              // </ul>) 
              : (<span>this is a surprise</span>)
          }
        </div>


        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
