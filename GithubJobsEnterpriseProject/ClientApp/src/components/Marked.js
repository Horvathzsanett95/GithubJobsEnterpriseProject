import React, { useState, useContext } from 'react';
import Job from './Job';
import {MarkedContext} from '../MarkedContext';

export default function Marked() {
    
    const [markedJobs, setMarkedJobs] = useContext(MarkedContext)
    return markedJobs.map((job =>  <Job job={job} />))
    
}
