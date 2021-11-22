import React from 'react';
import { useLocation } from 'react-router-dom';

function Footer() {
    const location = useLocation();

    if (location.pathname === "/404" || location.pathname === "/createAuction" )
        return '';

    return (
        <div>
            <footer className="bg_img padding-top oh" style={ { backgroundImage: "url('/assets/images/footer/footer-bg.jpg')" } }>
                <div className="footer-top-shape">
                    <img src="/assets/css/img/footer-top-shape.png" alt="css"></img>
                </div>
                <div className="anime-wrapper">
                    <div className="anime-1 plus-anime">
                        <img src="/assets/images/footer/p1.png" alt="footer"></img>
                    </div>
                    <div className="anime-2 plus-anime">
                        <img src="/assets/images/footer/p2.png" alt="footer"></img>
                    </div>
                    <div className="anime-3 plus-anime">
                        <img src="/assets/images/footer/p3.png" alt="footer"></img>
                    </div>
                    <div className="anime-5 zigzag">
                        <img src="/assets/images/footer/c2.png" alt="footer"></img>
                    </div>
                    <div className="anime-6 zigzag">
                        <img src="/assets/images/footer/c3.png" alt="footer"></img>
                    </div>
                    <div className="anime-7 zigzag">
                        <img src="/assets/images/footer/c4.png" alt="footer"></img>
                    </div>
                </div>
                <div className="newslater-wrapper">
                    <div className="container">
                        <div className="newslater-area">
                            <div className="newslater-thumb">
                                <img src="/assets/images/footer/newslater.png" alt="footer"></img>
                            </div>
                            <div className="newslater-content">
                                <div className="section-header left-style mb-low">
                                    <h5 className="cate">Subscribe to Sbidu</h5>
                                    <h3 className="title">To Get Exclusive Benefits</h3>
                                </div>
                                <form className="subscribe-form">
                                    <input type="text" placeholder="Enter Your Email" name="email"></input>
                                    <button type="submit" className="custom-button">Subscribe</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="footer-top padding-bottom padding-top">
                    <div className="container">
                        <div className="row mb--60">
                            <div className="col-sm-6 col-lg-3">
                                <div className="footer-widget widget-links">
                                    <h5 className="title">Auction Categories</h5>
                                    <ul className="links-list">
                                        <li>
                                            <a href="#0">Ending Now</a>
                                        </li>
                                        <li>
                                            <a href="#0">Vehicles</a>
                                        </li>
                                        <li>
                                            <a href="#0">Watches</a>
                                        </li>
                                        <li>
                                            <a href="#0">Electronics</a>
                                        </li>
                                        <li>
                                            <a href="#0">Real Estate</a>
                                        </li>
                                        <li>
                                            <a href="#0">Jewelry</a>
                                        </li>
                                        <li>
                                            <a href="#0">Art</a>
                                        </li>
                                        <li>
                                            <a href="#0">Sports & Outdoor</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div className="col-sm-6 col-lg-3">
                                <div className="footer-widget widget-links">
                                    <h5 className="title">About Us</h5>
                                    <ul className="links-list">
                                        <li>
                                            <a href="#0">About Sbidu</a>
                                        </li>
                                        <li>
                                            <a href="#0">Help</a>
                                        </li>
                                        <li>
                                            <a href="#0">Affiliates</a>
                                        </li>
                                        <li>
                                            <a href="#0">Jobs</a>
                                        </li>
                                        <li>
                                            <a href="#0">Press</a>
                                        </li>
                                        <li>
                                            <a href="#0">Our blog</a>
                                        </li>
                                        <li>
                                            <a href="#0">Collectors' portal</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div className="col-sm-6 col-lg-3">
                                <div className="footer-widget widget-links">
                                    <h5 className="title">We're Here to Help</h5>
                                    <ul className="links-list">
                                        <li>
                                            <a href="#0">Your Account</a>
                                        </li>
                                        <li>
                                            <a href="#0">Safe and Secure</a>
                                        </li>
                                        <li>
                                            <a href="#0">Shipping Information</a>
                                        </li>
                                        <li>
                                            <a href="#0">Contact Us</a>
                                        </li>
                                        <li>
                                            <a href="#0">Help & FAQ</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div className="col-sm-6 col-lg-3">
                                <div className="footer-widget widget-follow">
                                    <h5 className="title">Follow Us</h5>
                                    <ul className="links-list">
                                        <li>
                                            <a href="#0"><i className="fas fa-phone-alt"></i>(646) 663-4575</a>
                                        </li>
                                        <li>
                                            <a href="#0"><i className="fas fa-blender-phone"></i>(646) 968-0608</a>
                                        </li>
                                        <li>
                                            <a href="#0"><i className="fas fa-envelope-open-text"></i><span className="__cf_email__" data-cfemail="2a424f465a6a4f444d455e424f474f04494547">[email&#160;protected]</span></a>
                                        </li>
                                        <li>
                                            <a href="#0"><i className="fas fa-location-arrow"></i>1201 Broadway Suite</a>
                                        </li>
                                    </ul>
                                    <ul className="social-icons">
                                        <li>
                                            <a href="#0" className="active"><i className="fab fa-facebook-f"></i></a>
                                        </li>
                                        <li>
                                            <a href="#0"><i className="fab fa-twitter"></i></a>
                                        </li>
                                        <li>
                                            <a href="#0"><i className="fab fa-instagram"></i></a>
                                        </li>
                                        <li>
                                            <a href="#0"><i className="fab fa-linkedin-in"></i></a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="footer-bottom">
                    <div className="container">
                        <div className="copyright-area">
                            <div className="footer-bottom-wrapper">
                                <div className="logo">
                                    <a href="index.html"><img src="/assets/images/logo/footer-logo.png" alt="logo"></img></a>
                                </div>
                                <ul className="gateway-area">
                                    <li>
                                        <a href="#0"><img src="/assets/images/footer/paypal.png" alt="footer"></img></a>
                                    </li>
                                    <li>
                                        <a href="#0"><img src="/assets/images/footer/visa.png" alt="footer"></img></a>
                                    </li>
                                    <li>
                                        <a href="#0"><img src="/assets/images/footer/discover.png" alt="footer"></img></a>
                                    </li>
                                    <li>
                                        <a href="#0"><img src="/assets/images/footer/mastercard.png" alt="footer"></img></a>
                                    </li>
                                </ul>
                                <div className="copyright"><p>&copy; Copyright 2021 | <a href="#0">Sbidu</a> By <a href="#0">Uiaxis</a></p></div>
                            </div>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    );
}

export default Footer;