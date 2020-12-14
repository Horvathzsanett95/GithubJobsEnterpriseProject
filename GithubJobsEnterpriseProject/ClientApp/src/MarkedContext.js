import React, { useState, createContext } from "react";

export const MarkedContext = createContext();

export const MarkedProvider = (props) => {
    const [markedJobs, setMarkedJob] = useState([]);

    return (
        <MarkedContext.Provider value={[markedJobs, setMarkedJob]}>
            {props.children}
        </MarkedContext.Provider>
    )
}

