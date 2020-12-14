import logo from './logo.svg';
import './App.css';
import Home from './components/Home';
import Marked from './components/Marked';
import Statistics from './components/Statistics';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
      </header>
      <Router>
      <div>
        <nav>
          <ul>
            <li>
                <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/marked">Marked jobs</Link>
            </li>
            <li>
              <Link to="/statistics">Statistics</Link>
            </li>
          </ul>
        </nav>

        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
        <Switch>
          <Route path="/marked">
            <Marked />
          </Route>
          <Route path="/statistics">
            <Statistics />
          </Route>
          <Route path="/">
            <Home />
          </Route>
        </Switch>
      </div>
    </Router>
    <br></br>
    </div>
  );
}

export default App;
