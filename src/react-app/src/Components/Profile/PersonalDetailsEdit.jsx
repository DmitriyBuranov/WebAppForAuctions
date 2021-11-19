import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';

import { updateAsync, selectErrors } from '../../features/userSlice';
import { Alert } from 'react-bootstrap';

function PersonalDetailsEdit(props) {    
    const errors = useSelector(selectErrors);    
    const dispatch = useDispatch();

    const [firstName, setFirstName] = useState(props.user.firstName);
    const [lastName, setLastName] = useState(props.user.lastName);
    const [username, setUsername] = useState(props.user.username);
    const [password, setPassword] = useState('');

    function doUpdate(e) {
        debugger;
        
        e.preventDefault();

        const data = {
            firstName: firstName,
            lastName: lastName,
            username: username,
            password: password
        };

        dispatch(updateAsync(data));
        return false;
    }

    return (
        <div className="col-12">
            <div className="dash-pro-item mb-30 dashboard-widget">
                <div className="header">
                    <h4 className="title">Personal Details</h4>
                    <span className="edit" onClick={props.onHide} ><i className="flaticon-edit"></i> Cancel</span>
                </div>

                {errors ? <Alert variant="danger">{errors.map(line => (<p key="{line}">{line}</p>))}</Alert> : ''}

                <ul className="dash-pro-body">
                    <li>
                        <div className="info-name">First Name</div>
                        <div className="info-value">
                            <input type="text" id="profile-firstname" placeholder="First Name" defaultValue={props.user.firstName} onChange={(e) => setFirstName(e.target.value)} />
                        </div>
                    </li>
                    <li>
                        <div className="info-name">Last Name</div>
                        <div className="info-value">
                            <input type="text" id="profile-lastname" placeholder="Last Name" defaultValue={props.user.lastName} onChange={(e) => setLastName(e.target.value)} />
                        </div>
                    </li>
                    <li>
                        <div className="info-name">Email Address</div>
                        <div className="info-value">
                            <input type="text" id="profile-username" placeholder="Email" defaultValue={props.user.username} onChange={(e) => setUsername(e.target.value)} />
                        </div>
                    </li>
                    <li>
                        <div className="info-name">Password</div>
                        <div className="info-value">
                            <input type="password" id="login-password" onChange={(e) => setPassword(e.target.value)}/>
                        </div>
                    </li>
                </ul>
                
                <div className="form-group mb-0">
                    <button type="submit" className="custom-button white" onClick={doUpdate}>Save</button>                        
                    <button type="submit" className="custom-button white" onClick={props.onHide} style={{marginLeft: '15px'}}>Cancel</button>
                </div>
            </div>
        </div>
    );
}

export default PersonalDetailsEdit;