import React from 'react';
import { NavLink, Link } from "react-router-dom";
import { useSelector, useDispatch } from 'react-redux';
import { selectCurrent, logout } from '../../features/userSlice';
import Cookies from 'js-cookie'
import { cookieName } from '../../features/userAPI';

function ProfileLeftMenu() {
    const user = useSelector(selectCurrent);
    const dispatch = useDispatch();

    let fullName = "";

    if (user != null)
        fullName = user.firstName + " " + user.lastName;

    function doLogout(e) {
        e.preventDefault();
        Cookies.remove(cookieName);
        dispatch(logout());
        return false;
    }

    return (
        <div className="col-sm-10 col-md-7 col-lg-4">
            <div className="dashboard-widget mb-30 mb-lg-0 sticky-menu">
                <div className="user">
                    <div className="thumb-area">
                        <div className="thumb">
                            <img src={`/assets/images/history/0${user.id}.png`} alt="user" />
                        </div>
                        <input type="file" id="profile-pic" className="d-none" />
                    </div>
                    <div className="content">
                        <h5 className="title">
                            <Link to='/profile'>{fullName}</Link>
                        </h5>
                    </div>
                </div>
                <ul className="dashboard-menu">
                    {/* <li>
                        <NavLink exact activeClassName='active' to='/dashboard'><i className="flaticon-dashboard"></i>Dashboard</NavLink>
                    </li> */}
                    <li>
                        <NavLink exact activeClassName='active' to='/profile'><i className="flaticon-settings"></i>Personal Profile</NavLink>
                    </li>

                    {
                        !user.admin ? "" :
                            (
                                <li>
                                    <NavLink exact activeClassName='active' to='/createAuction'><i className="flaticon-auction"></i>Create Auction</NavLink>
                                </li>
                            )
                    }

                    {/* <li>
                        <NavLink exact activeClassName='active' to='/bids'><i className="flaticon-auction"></i>My Bids</NavLink>
                    </li>
                    <li>
                        <NavLink exact activeClassName='active' to='/winnings'><i className="flaticon-best-seller"></i>Winning Bids</NavLink>
                    </li> */}
                    <li>
                        <a href="{}" onClick={doLogout}><i className="flaticon-alarm"></i>Log out</a>
                    </li>
                </ul>
            </div>
        </div>
    );
}

export default ProfileLeftMenu;