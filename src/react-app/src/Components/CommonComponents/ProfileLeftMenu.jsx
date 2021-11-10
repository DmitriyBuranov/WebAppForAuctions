import React from 'react';
import { NavLink } from "react-router-dom";


function ProfileLeftMenu() {

    return (
        <div className="col-sm-10 col-md-7 col-lg-4">
            <div className="dashboard-widget mb-30 mb-lg-0 sticky-menu">
                <div className="user">
                    <div className="thumb-area">
                        <div className="thumb">
                            <img src="assets/images/dashboard/user.png" alt="user" />
                        </div>
                        <input type="file" id="profile-pic" className="d-none" />
                    </div>
                    <div className="content">
                        <h5 className="title"><a href="#0">Percy Reed</a></h5>
                    </div>
                </div>
                <ul className="dashboard-menu">
                    <li>
                        <NavLink exact activeClassName='active' to='/dashboard'><i className="flaticon-dashboard"></i>Dashboard</NavLink>
                    </li>
                    <li>
                        <NavLink exact activeClassName='active' to='/profile'><i className="flaticon-settings"></i>Personal Profile</NavLink>
                    </li>
                    <li>
                        <NavLink exact activeClassName='active' to='/bids'><i className="flaticon-auction"></i>My Bids</NavLink>
                    </li>
                    <li>
                        <NavLink exact activeClassName='active' to='/winnings'><i className="flaticon-best-seller"></i>Winning Bids</NavLink>
                    </li>
                </ul>
            </div>
        </div>
    );
}

export default ProfileLeftMenu;