import React, { useState } from 'react';
import {MarkedProvider} from './MarkedContext';
import logo from './logo.png';
import githubLogo from './github-logo.png';
import './App.css';
import Home from './components/Home';
import Marked from './components/Marked';
import Statistics from './components/Statistics';
import SearchResults from './components/SearchResults'
import Detail from './components/Detail'
import Register from './components/Register'
import Login from './components/Login'

import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

function App() {
  // let [markedJobs, setMarkedJobs] = useState([]);

  // function handleChange(markedJob) {
  //   console.log("I am working app")
  //   if (markedJobs.length === 0) {
  //     console.log("null")
  //     markedJobs = markedJob
  //   } else {
  //     setMarkedJobs(jobs => [...jobs, markedJob])
  //   }
    
  //   console.log(markedJobs)
  // }

  let markedJobs = [];

  function handleChange(markedJob) {
    markedJobs.push(markedJob)
    console.log(markedJobs)
  }

  const NavElementStyle = {
    fontSize: 20,
    display: "inline-block",
    margin: "5px",
    padding: "3px",
    textDecoration: 'none',
    backgroundColor: "#78c3ff",
    width: "200px",
  }

  return (
    <MarkedProvider>
    <div className="App">
      
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
    </header>
      
      <Router>
      <div>
        <nav>
          <ul>
            <li style={NavElementStyle}>
              <img src={githubLogo} className="Git-logo" alt="logo" />
              <Link to="/" style={{color:'black'}}>Home</Link>
              <img src={githubLogo} className="Git-logo" alt="logo" />
                </li>
                <li style={NavElementStyle}>
              <img src={githubLogo} className="Git-logo" alt="logo" />
              <Link to="/marked" style={{color:'black'}}>Marked jobs</Link>
              <img src={githubLogo} className="Git-logo" alt="logo" />
            </li>
            <li style={NavElementStyle}>
              <img src={githubLogo} className="Git-logo" alt="logo" />
              <Link to="/search" style={{color:'black'}}>Search</Link>
              <img src={githubLogo} className="Git-logo" alt="logo" />
            </li>
            <li style={NavElementStyle}>
              <img src={githubLogo} className="Git-logo" alt="logo" />
              <Link to="/registration" style={{color:'black'}}>Register</Link>
              <img src={githubLogo} className="Git-logo" alt="logo" />
            </li>
            <li style={NavElementStyle}>
              <img src={githubLogo} className="Git-logo" alt="logo" />
              <Link to="/login" style={{color:'black'}}>Login</Link>
              <img src={githubLogo} className="Git-logo" alt="logo" />
            </li>
            <li style={NavElementStyle}>
              <img src={githubLogo} className="Git-logo" alt="logo" />
              <Link to="/statistics" style={{color:'black'}}>Statistics</Link>
              <img src={githubLogo} className="Git-logo" alt="logo" />
            </li>
          </ul>
        </nav>

        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
        <Switch>
          <Route path="/search">
            <SearchResults />
          </Route>
          <Route path="/login">
            <Login />
          </Route>
          <Route path="/marked">
            <Marked markedJobs={markedJobs}/>
          </Route>
          <Route path="/detail">
            <Detail/>
          </Route>
          <Route path='/registration'>
            <Register/>
          </Route>
          <Route path="/statistics">
            <Statistics />
          </Route>
            <Route path="/">
                <Home onChange={handleChange}/> 
          </Route>
        </Switch>
      </div>
    </Router>
    <br></br>
    </div>
    </MarkedProvider>
  );
}

export default App;
