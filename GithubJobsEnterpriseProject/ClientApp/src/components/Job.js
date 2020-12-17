import React, { useState, useContext } from 'react';
import { MarkedContext } from '../MarkedContext';

export default function Job(props) {
    const [markedJobs, setMarkedJob] = useContext(MarkedContext);

    const handleClickJob = (e) => {
        setMarkedJob(jobs => [...jobs, props.job])
    }

    const cardStyling = {
        width: "400px",
        minHeight: "250px",
        display: "inline-block",
        borderStyle: "solid",
        borderRadius: "7%",
        margin: "20px",
        padding: "5px"
    }

    let link = '/detail?id=' + props.job.id;

    return (
        <div style={cardStyling}>
            <div style={{ height: "80px" }}><a href={link} style={{ fontSize: '20px' }}>{props.job.title}</a>
                <input type="checkbox" value={props.job} onChange={handleClickJob}></input></div>
            <div style={{ height: "45px" }}><p>{props.job.location}</p></div>
            <div style={{ height: "30px" }}><p><strong>Company:</strong> {props.job.company}</p></div>
            <div style={{ height: "30px" }}><p><strong>Type:</strong> {props.job.type}</p></div>
        </div>
    )
}