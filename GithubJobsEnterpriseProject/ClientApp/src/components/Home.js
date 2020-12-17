import React, { useState, useEffect } from 'react'
import axios from 'axios';
import Job from './Job';

export default function Home(props) {
    //const [markedJob, setMarkedJob] = useState([]);

    const markedJob = [];

    const handleSubmit = (job) => {
        props.onChange(job)
    }

    const [jobs, setJobs] = useState([]);

    useEffect(() => {
        getJobs();
    }, []);


    function handleChangeSubmit(){
        props.onChange(markedJob)
        }
        

        

    const getJobs = () => {
        axios.get('/api').then(data => setJobs(data.data))
    }

    function showElements(job) {
        return (<Job job={job} onChange={handleSubmit}/>)
    }

    return jobs.map(showElements)
}
