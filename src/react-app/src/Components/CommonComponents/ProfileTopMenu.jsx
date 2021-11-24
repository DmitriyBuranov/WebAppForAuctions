import React from 'react';
import { Link, useLocation } from "react-router-dom";

function ProfileTopMenu() {
    const location = useLocation();
    let pageName = "";

    if (location.pathname === "/dashboard") {
        pageName = "Dashboard";
    }
    else if (location.pathname === "/profile") {        
        pageName = "Personal Profile";
    }
    else if (location.pathname === "/bids") {
        pageName = "My Bids";
    }
    else if (location.pathname === "/winnings") {
        pageName = "Winning Bids";
    }
    else if (location.pathname === "/createAuction") {
        pageName = "Create Auction";
    }

    return (
        <div className="hero-section style-2">
            <div className="container">
                <ul className="breadcrumb">
                    <li>
                        <Link to="/home" className="user-button">Home</Link>
                    </li>
                    <li>

                    </li>
                    <li>
                        <span>{pageName}</span>
                    </li>
                </ul>
            </div>
            <div className="bg_img hero-bg bottom_center" style={{ backgroundImage: "url('/assets/images/banner/hero-bg.png')" }} ></div>
        </div>
    );
}

export default ProfileTopMenu;