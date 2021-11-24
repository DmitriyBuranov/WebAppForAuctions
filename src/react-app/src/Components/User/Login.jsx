import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';

import { Redirect, Link } from "react-router-dom";
import { loginAsync, selectErrors, selectLogged, selectLoading, setError } from '../../features/userSlice';
import { Alert } from 'react-bootstrap';
import Loader from '../CommonComponents/Loader';

function Login() {
    const logged = useSelector(selectLogged);
    const errors = useSelector(selectErrors);
    const loading = useSelector(selectLoading);
    const dispatch = useDispatch();

    const [email, setEmail] = useState('');
    const emailValue = email;

    const [password, setPassword] = useState('');
    const passwordValue = password;

    function doLogin(e) {
        e.preventDefault();

        const data = {
            username: emailValue,
            password: passwordValue
        };

        dispatch(loginAsync(data));
        return false;
    }



    if (logged === true)
        return <Redirect to="/profile" />

    return (
        <div>

            {loading ? <Loader /> : ""}

            <div className="hero-section">
                <div className="bg_img hero-bg bottom_center" style={{ backgroundImage: "url('assets/images/banner/hero-bg.png')" }} ></div>
            </div>

            <section className="account-section padding-bottom">
                <div className="container">
                    <div className="account-wrapper mt--100 mt-lg--440">
                        <div className="left-side">
                            <div className="section-header">
                                <h2 className="title">HI, THERE</h2>
                                <p>You can log in to your Sbidu account here.</p>
                            </div>

                            {errors ? <Alert variant="danger">{errors.map((line, index) => (<p key={index}>{line}</p>))}</Alert> : ''}

                            <form className="login-form" onSubmit={doLogin}>
                                <div className="form-group mb-30">
                                    <label htmlFor="login-email"><i className="far fa-envelope"></i></label>
                                    <input type="text" id="login-email" placeholder="Email Address" onChange={(e) => setEmail(e.target.value)} />
                                </div>
                                <div className="form-group">
                                    <label htmlFor="login-pass"><i className="fas fa-lock"></i></label>
                                    <input type="password" id="login-pass" placeholder="Password" onChange={(e) => setPassword(e.target.value)} />
                                </div>
                                <div className="form-group mb-0">
                                    <button type="submit" className="custom-button">LOG IN</button>
                                </div>
                            </form>
                        </div>
                        <div className="right-side cl-white">
                            <div className="section-header mb-0">
                                <h3 className="title mt-0">NEW HERE?</h3>
                                <p>Sign up and create your Account</p>
                                <Link to="/register" className="custom-button transparent" onClick={() => dispatch(setError(null))}>Sign Up</Link>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    );
}

export default Login;