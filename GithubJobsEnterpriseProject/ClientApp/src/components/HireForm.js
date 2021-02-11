import React from 'react';
import HiringPicture from '../hiring.png';

export default function HireForm() {
    const showSubmitMessage = function (e) {
        alert('You have saved the job successfully! Thank you!');
    }

    return (

        <form method="POST" style={{ padding: '5%', border: '1px solid #ced4da', marginBottom: '2%' }} onSubmit={ showSubmitMessage }>
            <img src={HiringPicture} style={{ height: "200px" }} alt="Empty heart" />
            <p>Here you can add jobs to our database. Of course after advertising on this page we will send you a <strong>very high bill</strong>, but of course it worth it.</p>
            <div class="container register-form">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" class="form-control" name='Title' placeholder="Title of the job *" required/>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" name='Company' placeholder="The hiring company's name *" required />
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" name='Type' placeholder="Type of the job *" required/>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" name='Location' placeholder="Location *" required/>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" name='HowToApply' placeholder="How to apply this job *" required/>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control" name='CompanyUrl' placeholder="Your company's url *" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <textarea style={{ height: "305px" }} class="form-control" name='Description' placeholder="Write a description here *" required />
                        </div>
                    </div>
                </div>
            </div>
            <button type="submit" style={{
                border: 'none', borderRadius: '1.5rem',
                padding: '1%', width: '12%', cursor: 'pointer', background: '#0062cc', color: '#fff'
            }}>Send job offer!</button>
        </form>
    
    )
}