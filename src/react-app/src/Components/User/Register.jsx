import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';

import { Redirect, Link } from "react-router-dom";
import { registerAsync, selectErrors, selectLogged, selectLoading, setError } from '../../features/userSlice';
import { Alert } from 'react-bootstrap';
import Loader from '../CommonComponents/Loader';

function Register() {
    const logged = useSelector(selectLogged);
    const errors = useSelector(selectErrors);
    const loading = useSelector(selectLoading);
    
    const dispatch = useDispatch();

    const [firstName, setFirstName] = useState('');    
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [repeatPassword, setRepeatPassword] = useState('');

    function doRegister(e) {
        e.preventDefault();

        const data = {
            firstName: firstName,
            lastName: lastName,
            username: email,
            password: password,
            repeatPassword: repeatPassword
        };

        dispatch(registerAsync(data));
        return false;
    }

    if (logged === true)
        return <Redirect to="/profile" />

    return (
        <div>
            {loading ? <Loader /> : ""}

            <div className="hero-section">
                <div className="bg_img hero-bg bottom_center" style={ { backgroundImage: "url('/assets/images/banner/hero-bg.png')" } } ></div>
            </div>

            <section className="account-section padding-bottom">
                <div className="container">
                    <div className="account-wrapper mt--100 mt-lg--440">
                        <div className="left-side">
                            <div className="section-header">
                                <h2 className="title">SIGN UP</h2>
                                <p>We're happy you're here!</p>
                            </div>
                            {errors ?<Alert variant="danger">{errors.map(line => (<p key={line}>{line}</p>))}</Alert> : ''}
                            <form className="login-form" onSubmit={doRegister}>
                                <div className="form-group mb-30">
                                    <label htmlFor="login-firstname"><i className="far fa-user"></i></label>
                                    <input type="text" id="login-firstname" placeholder="First Name" onChange={(e) => setFirstName(e.target.value)} />
                                </div>
                                <div className="form-group mb-30">
                                    <label htmlFor="login-lastname"><i className="far fa-user"></i></label>
                                    <input type="text" id="login-lastname" placeholder="Last Name" onChange={(e) => setLastName(e.target.value)} />
                                </div>
                                <div className="form-group mb-30">
                                    <label htmlFor="login-email"><i className="far fa-envelope"></i></label>
                                    <input type="text" id="login-email" placeholder="Email Address" onChange={(e) => setEmail(e.target.value)} />
                                </div>
                                <div className="form-group mb-30">
                                    <label htmlFor="login-pass"><i className="fas fa-lock"></i></label>
                                    <input type="password" id="login-pass" placeholder="Password" onChange={(e) => setPassword(e.target.value)} />
                                </div>    
                                <div className="form-group mb-30">
                                    <label htmlFor="login-pass"><i className="fas fa-lock"></i></label>
                                    <input type="кepeatЗassword" id="login-pass" placeholder="Repeat Password" onChange={(e) => setRepeatPassword(e.target.value)} />
                                </div>    
                                <div className="form-group mb-0">
                                    <button type="submit" className="custom-button">Sign Up</button>
                                </div>
                            </form>
                        </div>
                        <div className="right-side cl-white">
                            <div className="section-header mb-0">
                                <h3 className="title mt-0">ALREADY HAVE AN ACCOUNT?</h3>
                                <p>Log in and go to your Dashboard.</p>
                                <Link to="/login" className="custom-button transparent" onClick={() => dispatch(setError(null))}>Login</Link>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    );
}

export default Register;