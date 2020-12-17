import React, { useState, useEffect } from 'react'
import Login from './Login'

export default function Register() {
    const handleSubmit = (event) => {
        
    }

    return (
        <form method="POST" action="/registration" onSubmit={handleSubmit} style={{ padding: '5%', border: '1px solid #ced4da', marginBottom: '2%'}}>
                <div class="container register-form">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="text" class="form-control" name='Username' placeholder="Your Username *"/>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" name='Email' placeholder="Your Email *"/>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="password" class="form-control" name='Password' placeholder="Your Password *"/>
                            </div>
                            <div class="form-group">
                                <input type="password" class="form-control" name='PasswordRe' placeholder="Confirm Password *"/>
                            </div>
                        </div>
                    </div>
                </div>
            <button type="submit" style={{ border: 'none', borderRadius:'1.5rem',
                 padding: '1%',  width: '12%', cursor: 'pointer', background: '#0062cc', color: '#fff'}}>Register</button>
            </form>
    )
}
