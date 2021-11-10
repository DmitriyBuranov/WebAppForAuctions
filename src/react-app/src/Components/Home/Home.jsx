import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';
import Footer from '../CommonComponents/Footer';
import Header from '../CommonComponents/Header';
import Loader from '../CommonComponents/Loader';
import CarAuction from './CarAuction';
import { useSelector } from 'react-redux';
import { selectLogged, selectJWT } from '../../features/userSlice';

function Home() {
    const logged = useSelector(selectLogged);
    const jwt = useSelector(selectJWT);

    return (
        <div>
            {logged ? jwt : ""}

            {/*============= Banner Section Starts Here =============*/}
            <section className="banner-section-4 bg_img oh" style={ { backgroundImage: "url('assets/images/banner/banner-bg-4.png')" } }>
                <div className="container">
                    <div className="row align-items-center">
                        <div className="col-md-10 col-lg-7 col-xl-8">
                            <div className="banner-content cl-white">
                                <h5 className="cate">Enjoy Exclusive</h5>
                                <h1 className="title">Buy Your Car In Real Time <span className="d-xl-block">Bidding</span></h1>
                                <p className="mw-500">
                                    Thousands of Vehicles for Sale Every Day, We havejust the right one for you.
                                </p>
                                <a href="#0" className="custom-button yellow btn-large">Get Started</a>
                            </div>
                        </div>
                        <div className="col-lg-5 col-xl-4">
                            <div className="banner-thumb-4">
                                <a href="#0" className="bid-now"><i className="flaticon-auction"></i><span>Bid Now</span></a>
                                <img src="assets/images/banner/banner-4.png" alt="banner"></img>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="banner-shape d-none d-lg-block bot-0">
                    <img src="assets/css/img/banner-shape-4.png" alt="css"></img>
                </div>
            </section>
            {/*============= Banner Section Ends Here =============*/}


            {/*============= How Section Starts Here =============*/}
            <section className="how-section padding-top padding-bottom pos-rel">
                <div className="container">
                    <div className="section-header text-lg-left">
                        <h2 className="title">How it works</h2>
                        <p>Easy 3 steps to win</p>
                    </div>
                    <div className="row justify-content-center mb--40">
                        <div className="col-md-6 col-lg-4">
                            <div className="how-item">
                                <div className="how-thumb">
                                    <img src="assets/images/how/how1.png" alt="how"></img>
                                </div>
                                <div className="how-content">
                                    <h4 className="title">Sign Up</h4>
                                    <p>No Credit Card Required</p>
                                </div>
                            </div>
                        </div>
                        <div className="col-md-6 col-lg-4">
                            <div className="how-item">
                                <div className="how-thumb">
                                    <img src="assets/images/how/how2.png" alt="how"></img>
                                </div>
                                <div className="how-content">
                                    <h4 className="title">Bid</h4>
                                    <p>Bidding is free Only pay if you win</p>
                                </div>
                            </div>
                        </div>
                        <div className="col-md-6 col-lg-4">
                            <div className="how-item">
                                <div className="how-thumb">
                                    <img src="assets/images/how/how3.png" alt="how"></img>
                                </div>
                                <div className="how-content">
                                    <h4 className="title">Win</h4>
                                    <p>Fun - Excitement - Great deals</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="car-2 d-none d-lg-block"><img src="assets/images/how/car2.png" alt="how"></img></div>
            </section>
            {/*============= How Section Starts Here =============*/}

            <CarAuction></CarAuction>

            {/*============= Ending Auction Section Starts Here =============*/}
            <section className="ending-auction padding-top pos-rel">
                <div className="popular-bg bg_img" style={ { backgroundImage: "url('assets/images/popular/popular-bg.png')" } }></div>
                <div className="container">
                    <div className="section-header cl-white">
                        <span className="cate">Closing Within 24 Hours</span>
                        <h2 className="title">Auctions Ending soon</h2>
                        <p>Bid and win great deals,Our auction process is simple, efficient, and transparent.</p>
                    </div>
                    <div className="popular-auction-wrapper">
                        <div className="row justify-content-center mb-40-none">
                            <div className="col-lg-6">
                                <div className="auction-item-3">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction01.png" alt="ending"></img></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">2021 Honda Insight,
                                                Touring</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="bids-area">
                                            Total Bids : <span className="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-lg-6">
                                <div className="auction-item-3">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction02.png" alt="ending"></img></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">2011 Hyundai Sonata,
                                                Se/Limited</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="bids-area">
                                            Total Bids : <span className="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-lg-6">
                                <div className="auction-item-3">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction03.png" alt="ending"></img></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">2016 Dodge Grand
                                                Caravan, Sxt</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="bids-area">
                                            Total Bids : <span className="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-lg-6">
                                <div className="auction-item-3">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction04.png" alt="ending"></img></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">2009 Jeep Wrangler
                                                Unlimite, Sahara</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="bids-area">
                                            Total Bids : <span className="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-lg-6">
                                <div className="auction-item-3">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction05.png" alt="ending"></img></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">2009 Toyota Prius
                                                (Medford, NY 11763)</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="bids-area">
                                            Total Bids : <span className="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-lg-6">
                                <div className="auction-item-3">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction06.png" alt="ending"></img></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">2019 Indian Motorcycle
                                                Co. Scout, Bobber</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="bids-area">
                                            Total Bids : <span className="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="load-wrapper">
                            <a href="#0" className="normal-button">See All Auction</a>
                        </div>
                    </div>
                </div>
            </section>
            {/*============= Ending Auction Section Ends Here =============*/}


            {/*============= Call In Section Starts Here =============*/}
            <section className="call-in-section padding-top">
                <div className="container">
                    <div className="call-wrapper cl-white bg_img" style={ { backgroundImage: "url('assets/images/call-in/call-bg.png')" } } >
                        <div className="section-header">
                            <h3 className="title">Register for Free & Start Bidding Now!</h3>
                            <p>From cars to diamonds to iPhones, we have it all.</p>
                        </div>
                        <a href="sign-up.html" className="custom-button white">Register</a>
                    </div>
                </div>
            </section>
            {/*============= Call In Section Ends Here =============*/}
        </div>

    );
}

export default Home;