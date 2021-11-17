import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';

import { Redirect, Link } from "react-router-dom";
import { selectCurrent, selectLogged, selectLoading } from '../../features/userSlice';
import { Alert } from 'react-bootstrap';
import Loader from '../CommonComponents/Loader';
import ProfileLeftMenu from '../CommonComponents/ProfileLeftMenu';
import ProfileTopMenu from '../CommonComponents/ProfileTopMenu';

function PersonalDetailsView(props) {

    return (
        <div className="col-12">
            <div className="dash-pro-item mb-30 dashboard-widget">
                <div className="header">
                    <h4 className="title">Personal Details</h4>
                    <span className="edit" onClick={props.onShow} ><i className="flaticon-edit"></i> Edit</span>
                </div>

                <ul className="dash-pro-body">
                    <li>
                        <div className="info-name">First Name</div>
                        <div className="info-value">{props.user.firstName}</div>
                    </li>
                    <li>
                        <div className="info-name">Last Name</div>
                        <div className="info-value">{props.user.lastName}</div>
                    </li>
                    <li>
                        <div className="info-name">Email Address</div>
                        <div className="info-value">{props.user.username}</div>
                    </li>
                    <li>
                        <div className="info-name">Password</div>
                        <div className="info-value">xxxxxxxxxxxxxxxx</div>
                    </li>
                </ul>
            </div>
        </div>
    );
}

export default PersonalDetailsView;