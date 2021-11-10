import React from 'react';
import { Link, useLocation  } from 'react-router-dom';

function Header() {
    const location = useLocation();

    if (location.pathname === "/404")
        return '';

    return (
        <div>
            <header>
                <div className="header-top">
                    <div className="container">
                        <div className="header-top-wrapper">
                            <ul className="customer-support">

                            </ul>
                            <ul className="cart-button-area">
                                <li>
                                    <Link to="/dashboard" className="user-button"><i className="flaticon-user"></i></Link>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div className="header-bottom">
                    <div className="container">
                        <div className="header-wrapper">
                            <div className="logo">
                                <a href="index.html">
                                    <img src="assets/images/logo/logo.png" alt="logo"></img>
                                </a>
                            </div>
                            <ul className="menu ml-auto">
                                <li>
                                    <Link to="/home">Home</Link>
                                </li>
                                <li>
                                    <a href="product.html">Auction</a>
                                </li>
                                <li>
                                    <a href="#0">Pages</a>
                                    <ul className="submenu">
                                        <li>
                                            <a href="#0">Product</a>
                                            <ul className="submenu">
                                                <li>
                                                    <a href="product.html">Product Page 1</a>
                                                </li>
                                                <li>
                                                    <a href="product-2.html">Product Page 2</a>
                                                </li>
                                                <li>
                                                    <a href="product-details.html">Product Details</a>
                                                </li>
                                            </ul>
                                        </li>
                                        <li>
                                            <a href="#0">My Account</a>
                                            <ul className="submenu">
                                                <li>
                                                    <a href="sign-up.html">Sign Up</a>
                                                </li>
                                                <li>
                                                    <a href="sign-in.html">Sign In</a>
                                                </li>
                                            </ul>
                                        </li>
                                        <li>
                                            <a href="#0">Dashboard</a>
                                            <ul className="submenu">
                                                <li>
                                                    <a href="dashboard.html">Dashboard</a>
                                                </li>
                                                <li>
                                                    <a href="profile.html">Personal Profile</a>
                                                </li>
                                                <li>
                                                    <a href="my-bid.html">My Bids</a>
                                                </li>
                                                <li>
                                                    <a href="winning-bids.html">Winning Bids</a>
                                                </li>
                                                <li>
                                                    <a href="notifications.html">My Alert</a>
                                                </li>
                                                <li>
                                                    <a href="my-favorites.html">My Favorites</a>
                                                </li>
                                                <li>
                                                    <a href="referral.html">Referrals</a>
                                                </li>
                                            </ul>
                                        </li>
                                        <li>
                                            <a href="about.html">About Us</a>
                                        </li>
                                        <li>
                                            <a href="faqs.html">Faqs</a>
                                        </li>
                                        <li>
                                            <a href="error.html">404 Error</a>
                                        </li>
                                    </ul>
                                </li>
                                <li>
                                    <a href="contact.html">Contact</a>
                                </li>
                            </ul>
                            <div className="header-bar d-lg-none">
                                <span></span>
                                <span></span>
                                <span></span>
                            </div>
                        </div>
                    </div>
                </div>
            </header>
        </div>
    );
}

export default Header;