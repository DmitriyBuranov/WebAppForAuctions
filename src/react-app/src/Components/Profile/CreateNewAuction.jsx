import React from 'react';
import { useSelector } from 'react-redux';

import { Redirect } from "react-router-dom";
import { selectLogged, selectLoading, selectCurrent } from '../../features/userSlice';
import CreateAuction from '../AdminPanel/CreateAuction';
import Loader from '../CommonComponents/Loader';
import ProfileLeftMenu from '../CommonComponents/ProfileLeftMenu';
import ProfileTopMenu from '../CommonComponents/ProfileTopMenu';

function CreateNewAuction() {
    const logged = useSelector(selectLogged);
    const loading = useSelector(selectLoading);
    const user = useSelector(selectCurrent);

    if (logged !== true)
        return <Redirect to="/login" />

    if (!user.admin)
        return <Redirect to="/profile" />

    return (
        <div>
            {loading ? <Loader /> : ""}

            <ProfileTopMenu />

            <section className="dashboard-section padding-bottom mt--240 mt-lg--440 pos-rel">
                <div className="container">
                    <div className="row justify-content-center">

                        <ProfileLeftMenu />

                        <div className="col-lg-8">
                            <div className="dash-bid-item dashboard-widget mb-40-60">
                                <div className="header">
                                    <h4 className="title">Create Auction</h4>                                    
                                </div>
                                
                                <CreateAuction/>

                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    );
}

export default CreateNewAuction;