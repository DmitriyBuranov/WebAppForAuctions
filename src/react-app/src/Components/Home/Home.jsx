import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';
import Footer from '../CommonComponents/Footer';
import Header from '../CommonComponents/Header';
import CarAuction from './CarAuction';

function Home() {

    return (
        <div>
            {/*<Loader></Loader>*/}
            <Header></Header>

            {/*============= Banner Section Starts Here =============*/}
            <section class="banner-section-4 bg_img oh" data-background="assets/images/banner/banner-bg-4.png">
                <div class="container">
                    <div class="row align-items-center">
                        <div class="col-md-10 col-lg-7 col-xl-8">
                            <div class="banner-content cl-white">
                                <h5 class="cate">Enjoy Exclusive</h5>
                                <h1 class="title">Buy Your Car In Real Time <span class="d-xl-block">Bidding</span></h1>
                                <p class="mw-500">
                                    Thousands of Vehicles for Sale Every Day, We havejust the right one for you.
                                </p>
                                <a href="#0" class="custom-button yellow btn-large">Get Started</a>
                            </div>
                        </div>
                        <div class="col-lg-5 col-xl-4">
                            <div class="banner-thumb-4">
                                <a href="#0" class="bid-now"><i class="flaticon-auction"></i><span>Bid Now</span></a>
                                <img src="assets/images/banner/banner-4.png" alt="banner"></img>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="banner-shape d-none d-lg-block bot-0">
                    <img src="assets/css/img/banner-shape-4.png" alt="css"></img>
                </div>
            </section>
            {/*============= Banner Section Ends Here =============*/}


            {/*============= How Section Starts Here =============*/}
            <section class="how-section padding-top padding-bottom pos-rel">
                <div class="container">
                    <div class="section-header text-lg-left">
                        <h2 class="title">How it works</h2>
                        <p>Easy 3 steps to win</p>
                    </div>
                    <div class="row justify-content-center mb--40">
                        <div class="col-md-6 col-lg-4">
                            <div class="how-item">
                                <div class="how-thumb">
                                    <img src="assets/images/how/how1.png" alt="how"></img>
                                </div>
                                <div class="how-content">
                                    <h4 class="title">Sign Up</h4>
                                    <p>No Credit Card Required</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="how-item">
                                <div class="how-thumb">
                                    <img src="assets/images/how/how2.png" alt="how"></img>
                                </div>
                                <div class="how-content">
                                    <h4 class="title">Bid</h4>
                                    <p>Bidding is free Only pay if you win</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="how-item">
                                <div class="how-thumb">
                                    <img src="assets/images/how/how3.png" alt="how"></img>
                                </div>
                                <div class="how-content">
                                    <h4 class="title">Win</h4>
                                    <p>Fun - Excitement - Great deals</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="car-2 d-none d-lg-block"><img src="assets/images/how/car2.png" alt="how"></img></div>
            </section>
            {/*============= How Section Starts Here =============*/}

            <CarAuction></CarAuction>

            {/*============= Ending Auction Section Starts Here =============*/}
            <section class="ending-auction padding-top pos-rel">
                <div class="popular-bg bg_img" data-background="assets/images/auction/popular/popular-bg.png"></div>
                <div class="container">
                    <div class="section-header cl-white">
                        <span class="cate">Closing Within 24 Hours</span>
                        <h2 class="title">Auctions Ending soon</h2>
                        <p>Bid and win great deals,Our auction process is simple, efficient, and transparent.</p>
                    </div>
                    <div class="popular-auction-wrapper">
                        <div class="row justify-content-center mb-40-none">
                            <div class="col-lg-6">
                                <div class="auction-item-3">
                                    <div class="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction01.png" alt="ending"></img></a>
                                        <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                    </div>
                                    <div class="auction-content">
                                        <h6 class="title">
                                            <a href="product-details.html">2021 Honda Insight,
                                                Touring</a>
                                        </h6>
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-auction"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Current Bid</div>
                                                <div class="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div class="bids-area">
                                            Total Bids : <span class="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="auction-item-3">
                                    <div class="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction02.png" alt="ending"></img></a>
                                        <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                    </div>
                                    <div class="auction-content">
                                        <h6 class="title">
                                            <a href="product-details.html">2011 Hyundai Sonata,
                                                Se/Limited</a>
                                        </h6>
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-auction"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Current Bid</div>
                                                <div class="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div class="bids-area">
                                            Total Bids : <span class="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="auction-item-3">
                                    <div class="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction03.png" alt="ending"></img></a>
                                        <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                    </div>
                                    <div class="auction-content">
                                        <h6 class="title">
                                            <a href="product-details.html">2016 Dodge Grand
                                                Caravan, Sxt</a>
                                        </h6>
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-auction"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Current Bid</div>
                                                <div class="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div class="bids-area">
                                            Total Bids : <span class="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="auction-item-3">
                                    <div class="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction04.png" alt="ending"></img></a>
                                        <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                    </div>
                                    <div class="auction-content">
                                        <h6 class="title">
                                            <a href="product-details.html">2009 Jeep Wrangler
                                                Unlimite, Sahara</a>
                                        </h6>
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-auction"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Current Bid</div>
                                                <div class="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div class="bids-area">
                                            Total Bids : <span class="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="auction-item-3">
                                    <div class="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction05.png" alt="ending"></img></a>
                                        <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                    </div>
                                    <div class="auction-content">
                                        <h6 class="title">
                                            <a href="product-details.html">2009 Toyota Prius
                                                (Medford, NY 11763)</a>
                                        </h6>
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-auction"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Current Bid</div>
                                                <div class="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div class="bids-area">
                                            Total Bids : <span class="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="auction-item-3">
                                    <div class="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/ending/auction06.png" alt="ending"></img></a>
                                        <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                    </div>
                                    <div class="auction-content">
                                        <h6 class="title">
                                            <a href="product-details.html">2019 Indian Motorcycle
                                                Co. Scout, Bobber</a>
                                        </h6>
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-auction"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Current Bid</div>
                                                <div class="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div class="bids-area">
                                            Total Bids : <span class="total-bids">130 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="load-wrapper">
                            <a href="#0" class="normal-button">See All Auction</a>
                        </div>
                    </div>
                </div>
            </section>
            {/*============= Ending Auction Section Ends Here =============*/}


            {/*============= Call In Section Starts Here =============*/}
            <section class="call-in-section padding-top">
                <div class="container">
                    <div class="call-wrapper cl-white bg_img" data-background="assets/images/call-in/call-bg.png">
                        <div class="section-header">
                            <h3 class="title">Register for Free & Start Bidding Now!</h3>
                            <p>From cars to diamonds to iPhones, we have it all.</p>
                        </div>
                        <a href="sign-up.html" class="custom-button white">Register</a>
                    </div>
                </div>
            </section>
            {/*============= Call In Section Ends Here =============*/}


            <Footer></Footer>

            <script data-cfasync="false" src="../../cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js"></script><script src="assets/js/jquery-3.3.1.min.js"></script>
            <script src="assets/js/modernizr-3.6.0.min.js"></script>
            <script src="assets/js/plugins.js"></script>
            <script src="assets/js/bootstrap.min.js"></script>
            <script src="assets/js/isotope.pkgd.min.js"></script>
            <script src="assets/js/wow.min.js"></script>
            <script src="assets/js/waypoints.js"></script>
            <script src="assets/js/nice-select.js"></script>
            <script src="assets/js/counterup.min.js"></script>
            <script src="assets/js/owl.min.js"></script>
            <script src="assets/js/magnific-popup.min.js"></script>
            <script src="assets/js/yscountdown.min.js"></script>
            <script src="assets/js/jquery-ui.min.js"></script>
            <script src="assets/js/main.js"></script>
        </div>

    );
}

export default Home;