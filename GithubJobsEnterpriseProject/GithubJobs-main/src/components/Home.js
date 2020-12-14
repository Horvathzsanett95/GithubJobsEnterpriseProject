import React, { useState, useEffect } from 'react'
import axios from 'axios';
import Job from './Job';

export default function Home() {

    const [jobs, setJobs] = useState([]);

    useEffect(() => {
        getJobs();
    }, []);
        

    const getJobs = () => {
        axios.get('https://jobs.github.com/positions.json').then(data => setJobs(data.data))
    }

    return console.log(jobs), jobs.map(job => <Job job={job} />);
}
