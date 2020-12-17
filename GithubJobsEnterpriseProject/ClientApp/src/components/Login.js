import React, {useState,useEffect} from 'react'

export default function Login() {

    const handleSubmit = (event) => {
        
    }

    return (
            <form method="POST" action="/login" onSubmit={handleSubmit} style={{ padding: '5%', border: '1px solid #ced4da', marginBottom: '2%'}}>
                <div class="container login-form">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="text" class="form-control" name='Username' placeholder="Your Username *"/>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="password" class="form-control" name='Password' placeholder="Your Password *"/>
                            </div>
                        </div>
                    </div>
                </div>
                <button type="submit" style={{ border: 'none', borderRadius:'1.5rem',
                 padding: '1%',  width: '12%', cursor: 'pointer', background: '#0062cc', color: '#fff'}}>Login</button>
            </form>
    )
}
