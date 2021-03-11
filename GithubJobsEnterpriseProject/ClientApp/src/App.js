import React, { useState, useEffect } from "react";
import axios from "axios";
import { MarkedProvider } from "./MarkedContext";
import logo from "./logo.png";
import githubLogo from "./github-logo.png";
import "./App.css";
import Home from "./components/Home";
import Marked from "./components/Marked";
import Statistics from "./components/Statistics";
import SearchResults from "./components/SearchResults";
import Detail from "./components/Detail";
import Register from "./components/Register";
import Login from "./components/Login";
import HireForm from "./components/HireForm";

import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

function App() {
    const [jobs, setJobs] = useState([]);
    const [username, setUsername] = useState("");
    const [isLoggedIn, setIsLoggedIn] = useState([false]);

    let markedJobs = [];

    function handleChange(markedJob) {
        markedJobs.push(markedJob);
        console.log(markedJobs);
    }

    const SeparatedButtonStyle = {
        position: "absolute",
        width: "120px",
        fontSize: 20,
        borderStyle: "solid",
        float: "right",
        left: "90%",
        top: "5%",
        transform: "translate(95 %)",
        display: "inline-block",
        margin: "5px",
        padding: "3px",
        backgroundColor: "#fc0303",
        borderRadius: "15px",
    };

    const NavElementStyle = {
        fontSize: 20,
        display: "inline-block",
        margin: "5px",
        padding: "3px",
        borderRadius: "15px",
        textDecoration: "none",
        backgroundColor: "#78c3ff",
        width: "180px",
        hight: "40px",
    };

    useEffect(() => {
        getJobs();
        getUser();
    }, []);

    const getJobs = () => {
        axios.get("/api").then((data) => setJobs(data.data));
    };

    const getUser = () => {
        axios.get('/getCookieData').then(data => {
            if ((data.data).length != 0) {
                setIsLoggedIn(true)
                setUsername(data.data)
            }
        });
    };

    const setlogout = () => {
        setIsLoggedIn(false);
    };

    return (
        <MarkedProvider>
            <div className="App">
                <header className="App-header">
                    {isLoggedIn === true && <p> User: {username} </p>}
                    <img src={logo} className="App-logo" alt="logo" />
                </header>

                <Router>
                    <div className="cardsDiv">
                        <nav>
                            <ul>
                                {isLoggedIn === true && (
                                    <li style={SeparatedButtonStyle}>
                                        <Link to="/hire-form">Hire with us!</Link>
                                    </li>
                                )}
                                <li style={NavElementStyle}>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                    <Link to="/" style={{ color: "black" }}>
                                        Home
                  </Link>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                </li>
                                <li style={NavElementStyle}>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                    <Link to="/marked" style={{ color: "black" }}>
                                        Marked jobs
                  </Link>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                </li>
                                <li style={NavElementStyle}>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                    <Link to="/search" style={{ color: "black" }}>
                                        Search
                  </Link>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                </li>
                                <li style={NavElementStyle}>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                    <Link to="/registration" style={{ color: "black" }}>
                                        Register
                  </Link>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                </li>
                                <li style={NavElementStyle}>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                    <Link to="/login" style={{ color: "black" }}>
                                        Login
                  </Link>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                </li>
                                <li style={NavElementStyle}>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                    <Link to="/statistics" style={{ color: "black" }}>
                                        Statistics
                  </Link>
                                    <img src={githubLogo} className="Git-logo" alt="logo" />
                                </li>
                                {isLoggedIn === false && (
                                    <li style={NavElementStyle}>
                                        <img src={githubLogo} className="Git-logo" alt="logo" />
                                        <Link to="/login" style={{ color: "black" }}>
                                            Login
                    </Link>
                                        <img src={githubLogo} className="Git-logo" alt="logo" />
                                    </li>
                                )}
                                {isLoggedIn === true && (
                                    <li style={NavElementStyle}>
                                        <form action="/logout">
                                            <img src={githubLogo} className="Git-logo" alt="logo" />
                                            <button
                                                type="submit"
                                                onClick={setlogout}
                                                className="buttonLogout"
                                            >
                                                Logout
                      </button>
                                            <img src={githubLogo} className="Git-logo" alt="logo" />
                                        </form>
                                    </li>
                                )}
                            </ul>
                        </nav>

                        {/* A <Switch> looks through its children <Route>s and
                        renders the first one that matches the current URL. */}
                        <Switch>
                            <Route path="/hire-form">
                                <HireForm />
                            </Route>
                            <Route path="/search">
                                <SearchResults />
                            </Route>
                            <Route path="/login">
                                <Login />
                            </Route>
                            <Route path="/marked">
                                <Marked markedJobs={markedJobs} />
                            </Route>
                            <Route path="/detail">
                                <Detail />
                            </Route>
                            <Route path="/registration">
                                <Register />
                            </Route>
                            <Route path="/statistics">
                                <Statistics />
                            </Route>
                            <Route path="/">
                                <Home jobs={jobs} onChange={handleChange} />
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