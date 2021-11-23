import React from 'react';
import CarAuctionNearToStart from './CarAuctionNearTostart';
import CarAuctionNearToEnd from './CarAuctionNearToEnd';
import { Link } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { selectLogged } from '../../features/userSlice';

function Home() {
    const logged = useSelector(selectLogged);

    return (
        <div>
            {/*============= Banner Section Starts Here =============*/}
            <section className="banner-section-4 bg_img oh" style={{ backgroundImage: "url('/assets/images/banner/banner-bg-4.png')" }}>
                <div className="container">
                    <div className="row align-items-center">
                        <div className="col-md-10 col-lg-7 col-xl-8">
                            <div className="banner-content cl-white">
                                <h5 className="cate">Enjoy Exclusive</h5>
                                <h1 className="title">Buy Your Car In Real Time <span className="d-xl-block">Bidding</span></h1>
                                <p className="mw-500">
                                    Thousands of Vehicles for Sale Every Day, We havejust the right one for you.
                                </p>
                                <Link to="/products" className="custom-button yellow btn-large">Get Started</Link>
                            </div>
                        </div>
                        <div className="col-lg-5 col-xl-4">
                            <div className="banner-thumb-4">
                                <Link to="/products" className="bid-now"><i className="flaticon-auction"></i><span>Bid Now</span></Link>
                                <img src="/assets/images/banner/banner-4.png" alt="banner"></img>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="banner-shape d-none d-lg-block bot-0">
                    <img src="/assets/css/img/banner-shape-4.png" alt="css"></img>
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
                                    <img src="/assets/images/how/how1.png" alt="how"></img>
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
                                    <img src="/assets/images/how/how2.png" alt="how"></img>
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
                                    <img src="/assets/images/how/how3.png" alt="how"></img>
                                </div>
                                <div className="how-content">
                                    <h4 className="title">Win</h4>
                                    <p>Fun - Excitement - Great deals</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="car-2 d-none d-lg-block"><img src="/assets/images/how/car2.png" alt="how"></img></div>
            </section>
            {/*============= How Section Ends Here =============*/}

            <CarAuctionNearToStart />
            <CarAuctionNearToEnd />

            {logged ? "" :
                (
                    <>
                        {/*============= Call In Section Starts Here =============*/}
                        < section className="call-in-section padding-top">
                            <div className="container">
                                <div className="call-wrapper cl-white bg_img" style={{ backgroundImage: "url('/assets/images/call-in/call-bg.png')" }} >
                                    <div className="section-header">
                                        <h3 className="title">Register for Free & Start Bidding Now!</h3>
                                        <p>From cars to diamonds to iPhones, we have it all.</p>
                                    </div>
                                    <Link to="/register" className="custom-button white" >Register</Link>
                                </div>
                            </div>
                        </section>
                        {/*============= Call In Section Ends Here =============*/}
                    </>
                )
            }
        </div >

    );
}

export default Home;