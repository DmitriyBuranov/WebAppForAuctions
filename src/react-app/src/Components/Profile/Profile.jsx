import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';

import { Redirect, Link } from "react-router-dom";
import { registerAsync, selectErrors, selectLogged, selectLoading } from '../../features/userSlice';
import { Alert } from 'react-bootstrap';
import Loader from '../CommonComponents/Loader';
import ProfileLeftMenu from '../CommonComponents/ProfileLeftMenu';
import ProfileTopMenu from '../CommonComponents/ProfileTopMenu';

function Profile() {
    const logged = useSelector(selectLogged);    
    const loading = useSelector(selectLoading);

    if (logged !== true)
        return <Redirect to="/login" />

    return (
        <div>
            {loading ? <Loader /> : ""}

            <ProfileTopMenu/>

            <section className="dashboard-section padding-bottom mt--240 mt-lg--440 pos-rel">
                <div className="container">
                    <div className="row justify-content-center">
                        
                        <ProfileLeftMenu/>

                        <div className="col-lg-8">
                            <div className="row">
                                <div className="col-12">
                                    <div className="dash-pro-item mb-30 dashboard-widget">
                                        <div className="header">
                                            <h4 className="title">Personal Details</h4>
                                            <span className="edit"><i className="flaticon-edit"></i> Edit</span>
                                        </div>
                                        <ul className="dash-pro-body">
                                            <li>
                                                <div className="info-name">Name</div>
                                                <div className="info-value">Albert Owens</div>
                                            </li>
                                            <li>
                                                <div className="info-name">Date of Birth</div>
                                                <div className="info-value">15-03-1974</div>
                                            </li>
                                            <li>
                                                <div className="info-name">Address</div>
                                                <div className="info-value">8198 Fieldstone Dr.La Crosse, WI 54601</div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div className="col-12">
                                    <div className="dash-pro-item mb-30 dashboard-widget">
                                        <div className="header">
                                            <h4 className="title">Account Settings</h4>
                                            <span className="edit"><i className="flaticon-edit"></i> Edit</span>
                                        </div>
                                        <ul className="dash-pro-body">
                                            <li>
                                                <div className="info-name">Language</div>
                                                <div className="info-value">English (United States)</div>
                                            </li>
                                            <li>
                                                <div className="info-name">Time Zone</div>
                                                <div className="info-value">(GMT-06:00) Central America</div>
                                            </li>
                                            <li>
                                                <div className="info-name">Status</div>
                                                <div className="info-value"><i className="flaticon-check text-success"></i> Active</div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div className="col-12">
                                    <div className="dash-pro-item mb-30 dashboard-widget">
                                        <div className="header">
                                            <h4 className="title">Email Address</h4>
                                            <span className="edit"><i className="flaticon-edit"></i> Edit</span>
                                        </div>
                                        <ul className="dash-pro-body">
                                            <li>
                                                <div className="info-name">Email</div>
                                                <div className="info-value"><a href="http://pixner.net/cdn-cgi/l/email-protection" className="__cf_email__" data-cfemail="e889848a8d9a9cdbdcd1a88f85898184c68b8785">[email&#160;protected]</a></div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div className="col-12">
                                    <div className="dash-pro-item mb-30 dashboard-widget">
                                        <div className="header">
                                            <h4 className="title">Phone</h4>
                                            <span className="edit"><i className="flaticon-edit"></i> Edit</span>
                                        </div>
                                        <ul className="dash-pro-body">
                                            <li>
                                                <div className="info-name">Mobile</div>
                                                <div className="info-value">+1 234-567-8925</div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div className="col-12">
                                    <div className="dash-pro-item dashboard-widget">
                                        <div className="header">
                                            <h4 className="title">Security</h4>
                                            <span className="edit"><i className="flaticon-edit"></i> Edit</span>
                                        </div>
                                        <ul className="dash-pro-body">
                                            <li>
                                                <div className="info-name">Password</div>
                                                <div className="info-value">xxxxxxxxxxxxxxxx</div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    );
}

export default Profile;