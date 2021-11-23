import React, { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';

import { Redirect } from "react-router-dom";
import { setError, selectCurrent, selectLogged, selectLoading } from '../../features/userSlice';
import Loader from '../CommonComponents/Loader';
import ProfileLeftMenu from '../CommonComponents/ProfileLeftMenu';
import ProfileTopMenu from '../CommonComponents/ProfileTopMenu';
import PersonalDetailsView from './PersonalDetailsView';
import PersonalDetailsEdit from './PersonalDetailsEdit';

function Profile() {
    const logged = useSelector(selectLogged);
    const loading = useSelector(selectLoading);
    const user = useSelector(selectCurrent);
    const dispatch = useDispatch();

    useEffect(() => {    
        setEditPersonalDetails(false); 
        setError(null);
    }, [user]);

    const [editPersonalDetails, setEditPersonalDetails] = useState(false);

    if (logged !== true || user === null)
        return <Redirect to="/login" />

    return (
        <div>
            {loading ? <Loader /> : ""}

            <ProfileTopMenu />
            <section className="dashboard-section padding-bottom mt--240 mt-lg--440 pos-rel">
                <div className="container">
                    <div className="row justify-content-center">
                        <ProfileLeftMenu />
                        <div className="col-lg-8">
                            <div className="row">
                                {
                                    editPersonalDetails ?
                                        <PersonalDetailsEdit user={user} onHide={() => { setEditPersonalDetails(false); dispatch(setError(null)); } } /> : 
                                        <PersonalDetailsView user={user} onShow={() => { setEditPersonalDetails(true); dispatch(setError(null)); }} />
                                }
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    );
}

export default Profile;