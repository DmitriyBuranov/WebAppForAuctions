import React, { useState, useEffect, useRef } from 'react';
import { useSelector, useDispatch } from 'react-redux';

import { Redirect, Link } from "react-router-dom";
import { error, selectCurrent, selectLogged, selectLoading } from '../../features/userSlice';
import { Alert } from 'react-bootstrap';
import Loader from '../CommonComponents/Loader';
import ProfileLeftMenu from '../CommonComponents/ProfileLeftMenu';
import ProfileTopMenu from '../CommonComponents/ProfileTopMenu';
import PersonalDetailsView from './PersonalDetailsView';
import PersonalDetailsEdit from './PersonalDetailsEdit';


import { HubConnectionBuilder } from '@microsoft/signalr';

function Profile() {
    const logged = useSelector(selectLogged);
    const loading = useSelector(selectLoading);
    const user = useSelector(selectCurrent);
    const dispatch = useDispatch();

    const [ chat, setChat ] = useState([]);
    const latestChat = useRef(null);
    latestChat.current = chat;

    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl('https://localhost:5001/hubs/bet')            
            //.withUrl('/api/bets/new')
            .withAutomaticReconnect()
            .build();   

        connection.start()
            .then(result => {
                console.log('Connected!');
                
                connection.invoke("JoinGroup", "Auction_1");
                
                connection.on('NewBet', message => {
                    console.log('NewBet! '  + message);
                });
            })
            .catch(e => console.log('Connection failed: ', e));
    }, []);


    useEffect(() => {    
        setEditPersonalDetails(false); 
        dispatch(error(null));
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
                                        <PersonalDetailsEdit user={user} onHide={() => { setEditPersonalDetails(false); dispatch(error(null)); } } /> : 
                                        <PersonalDetailsView user={user} onShow={() => { setEditPersonalDetails(true); dispatch(error(null)); }} />
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