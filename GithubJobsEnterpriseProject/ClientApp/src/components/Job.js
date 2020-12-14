import React, { useState, useContext } from 'react';
import { MarkedContext } from '../MarkedContext';

export default function Job(props) {
    const [markedJobs, setMarkedJob] = useContext(MarkedContext);

    const handleClickJob = (e) => {
        setMarkedJob(jobs => [...jobs, props.job])
    }

    let link = '/detail?id=' + props.job.id;

    return (
        <div style={{}}>
            <a href={link}  style={{fontSize:'20px'}}>{props.job.title}</a>
            <input type="checkbox"  value={props.job} onChange={handleClickJob}></input> 
        </div>
    )
}