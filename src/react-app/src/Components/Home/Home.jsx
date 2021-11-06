import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';
import Footer from '../CommonComponents/Footer';
import Header from '../CommonComponents/Header';

function Home() {

    return (
        <div>
            {/*<Loader></Loader>*/}
            <Header></Header>

            {/*============= Cart Section Starts Here =============*/}
            <div class="cart-sidebar-area">
                <div class="top-content">
                    <a href="index.html" class="logo">
                        <img src="assets/images/logo/logo2.png" alt="logo"></img>
                    </a>
                    <span class="side-sidebar-close-btn"><i class="fas fa-times"></i></span>
                </div>
                <div class="bottom-content">
                    <div class="cart-products">
                        <h4 class="title">Shopping cart</h4>
                        <div class="single-product-item">
                            <div class="thumb">
                                <a href="#0"><img src="assets/images/shop/shop01.jpg" alt="shop"></img></a>
                            </div>
                            <div class="content">
                                <h4 class="title"><a href="#0">Color Pencil</a></h4>
                                <div class="price"><span class="pprice">$80.00</span> <del class="dprice">$120.00</del></div>
                                <a href="#" class="remove-cart">Remove</a>
                            </div>
                        </div>
                        <div class="single-product-item">
                            <div class="thumb">
                                <a href="#0"><img src="assets/images/shop/shop02.jpg" alt="shop"></img></a>
                            </div>
                            <div class="content">
                                <h4 class="title"><a href="#0">Water Pot</a></h4>
                                <div class="price"><span class="pprice">$80.00</span> <del class="dprice">$120.00</del></div>
                                <a href="#" class="remove-cart">Remove</a>
                            </div>
                        </div>
                        <div class="single-product-item">
                            <div class="thumb">
                                <a href="#0"><img src="assets/images/shop/shop03.jpg" alt="shop"></img></a>
                            </div>
                            <div class="content">
                                <h4 class="title"><a href="#0">Art Paper</a></h4>
                                <div class="price"><span class="pprice">$80.00</span> <del class="dprice">$120.00</del></div>
                                <a href="#" class="remove-cart">Remove</a>
                            </div>
                        </div>
                        <div class="single-product-item">
                            <div class="thumb">
                                <a href="#0"><img src="assets/images/shop/shop04.jpg" alt="shop"></img></a>
                            </div>
                            <div class="content">
                                <h4 class="title"><a href="#0">Stop Watch</a></h4>
                                <div class="price"><span class="pprice">$80.00</span> <del class="dprice">$120.00</del></div>
                                <a href="#" class="remove-cart">Remove</a>
                            </div>
                        </div>
                        <div class="single-product-item">
                            <div class="thumb">
                                <a href="#0"><img src="assets/images/shop/shop05.jpg" alt="shop"></img></a>
                            </div>
                            <div class="content">
                                <h4 class="title"><a href="#0">Comics Book</a></h4>
                                <div class="price"><span class="pprice">$80.00</span> <del class="dprice">$120.00</del></div>
                                <a href="#" class="remove-cart">Remove</a>
                            </div>
                        </div>
                        <div class="btn-wrapper text-center">
                            <a href="#0" class="custom-button"><span>Checkout</span></a>
                        </div>
                    </div>
                </div>
            </div>
            {/*============= Cart Section Ends Here =============*/}


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


            {/*============= Car Auction Section Starts Here =============*/}
            <section class="car-auction-section padding-bottom pos-rel oh">
                <div class="car-bg"><img src="assets/images/auction/car/car-bg.png" alt="car"></img></div>
                <div class="container">
                    <div class="section-header-3">
                        <div class="left d-block">
                            <h2 class="title mb-3">Featured Items</h2>
                            <p>Start winning cars with comfort</p>
                        </div>
                        <a href="#0" class="normal-button">View All</a>
                    </div>
                    <div class="row justify-content-center mb-30-none">
                        <div class="col-sm-10 col-md-6 col-lg-4">
                            <div class="auction-item-2">
                                <div class="auction-thumb">
                                    <a href="product-details.html"><img src="assets/images/auction/car/auction-1.jpg" alt="car"></img></a>
                                    <a href="#0" class="rating"><i class="far fa-star"></i></a>
                                    <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                </div>
                                <div class="auction-content">
                                    <h6 class="title">
                                        <a href="product-details.html">2018 Hyundai Sonata</a>
                                    </h6>
                                    <div class="bid-area">
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-auction"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Current Bid</div>
                                                <div class="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-money"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Buy Now</div>
                                                <div class="amount">$5,00.00</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="countdown-area">
                                        <div class="countdown">
                                            <div id="bid_counter26"></div>
                                        </div>
                                        <span class="total-bids">30 Bids</span>
                                    </div>
                                    <div class="text-center">
                                        <a href="#0" class="custom-button">Submit a bid</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-10 col-md-6 col-lg-4">
                            <div class="auction-item-2">
                                <div class="auction-thumb">
                                    <a href="product-details.html"><img src="assets/images/auction/car/auction-2.jpg" alt="car"></img></a>
                                    <a href="#0" class="rating"><i class="far fa-star"></i></a>
                                    <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                </div>
                                <div class="auction-content">
                                    <h6 class="title">
                                        <a href="product-details.html">2018 Nissan Versa, S</a>
                                    </h6>
                                    <div class="bid-area">
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-auction"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Current Bid</div>
                                                <div class="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-money"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Buy Now</div>
                                                <div class="amount">$5,00.00</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="countdown-area">
                                        <div class="countdown">
                                            <div id="bid_counter27"></div>
                                        </div>
                                        <span class="total-bids">30 Bids</span>
                                    </div>
                                    <div class="text-center">
                                        <a href="#0" class="custom-button">Submit a bid</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-10 col-md-6 col-lg-4">
                            <div class="auction-item-2">
                                <div class="auction-thumb">
                                    <a href="product-details.html"><img src="assets/images/auction/car/auction-3.jpg" alt="car"></img></a>
                                    <a href="#0" class="rating"><i class="far fa-star"></i></a>
                                    <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                </div>
                                <div class="auction-content">
                                    <h6 class="title">
                                        <a href="product-details.html">2018 Honda Accord, Sport</a>
                                    </h6>
                                    <div class="bid-area">
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-auction"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Current Bid</div>
                                                <div class="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div class="bid-amount">
                                            <div class="icon">
                                                <i class="flaticon-money"></i>
                                            </div>
                                            <div class="amount-content">
                                                <div class="current">Buy Now</div>
                                                <div class="amount">$5,00.00</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="countdown-area">
                                        <div class="countdown">
                                            <div id="bid_counter28"></div>
                                        </div>
                                        <span class="total-bids">30 Bids</span>
                                    </div>
                                    <div class="text-center">
                                        <a href="#0" class="custom-button">Submit a bid</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            {/*============= Car Auction Section Ends Here =============*/}


            {/*============= Trending Section Starts Here =============*/}
            <section class="trending-section padding-bottom padding-top">
                <div class="container">
                    <div class="section-header-3">
                        <div class="left d-block">
                            <h2 class="title mb-3">Trending Items</h2>
                            <p>Bid on 1,000’s of vehicles from more than 25 countries</p>
                        </div>
                        <a href="#0" class="normal-button">View All</a>
                    </div>
                    <div class="row justify-content-center mb-30-none">
                        <div class="col-md-6 col-lg-12">
                            <div class="auction-item-6">
                                <div class="auction-inner">
                                    <div class="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/trending/auction-1.png" alt="trending"></img></a>
                                        <a href="#0" class="rating"><i class="far fa-star"></i></a>
                                        <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                    </div>
                                    <div class="auction-content">
                                        <h5 class="title"><a href="product-details.html">2016 KIA Optima, EX</a></h5>
                                        <div class="item-information">
                                            <ul>
                                                <li><span>Number</span>1-38005900</li>
                                                <li><span>VIN</span>2G1WG5EK3B1312245</li>
                                                <li><span>Milage</span> 153k miles (246k km)</li>
                                                <li><span>Location</span>Sandston (VA)</li>
                                            </ul>
                                            <ul>
                                                <li><span>Engine</span>2.0 Diesel</li>
                                                <li><span>Transmission</span>Automated</li>
                                                <li><span>Body</span>Offroad car</li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="auction-bidding">
                                        <div class="countdown">
                                            <div id="bid_counter3"></div>
                                        </div>
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
                                        <a href="#0" class="custom-button">Submit a bid</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-12">
                            <div class="auction-item-6">
                                <div class="auction-inner">
                                    <div class="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/trending/auction-2.png" alt="trending"></img></a>
                                        <a href="#0" class="rating"><i class="far fa-star"></i></a>
                                        <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                    </div>
                                    <div class="auction-content">
                                        <h5 class="title"><a href="product-details.html">2019 Polaris General, 1000 Eps</a></h5>
                                        <div class="item-information">
                                            <ul>
                                                <li><span>Number</span>1-38005900</li>
                                                <li><span>VIN</span>2G1WG5EK3B1312245</li>
                                                <li><span>Milage</span> 153k miles (246k km)</li>
                                                <li><span>Location</span>Sandston (VA)</li>
                                            </ul>
                                            <ul>
                                                <li><span>Engine</span>2.0 Diesel</li>
                                                <li><span>Transmission</span>Automated</li>
                                                <li><span>Body</span>Offroad car</li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="auction-bidding">
                                        <div class="countdown">
                                            <div id="bid_counter4"></div>
                                        </div>
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
                                        <a href="#0" class="custom-button">Submit a bid</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-12">
                            <div class="auction-item-6">
                                <div class="auction-inner">
                                    <div class="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/trending/auction-3.png" alt="trending"></img></a>
                                        <a href="#0" class="rating"><i class="far fa-star"></i></a>
                                        <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                    </div>
                                    <div class="auction-content">
                                        <h5 class="title"><a href="product-details.html">2018 Hyundai Elantra, Sel/Value/Limited</a></h5>
                                        <div class="item-information">
                                            <ul>
                                                <li><span>Number</span>1-38005900</li>
                                                <li><span>VIN</span>2G1WG5EK3B1312245</li>
                                                <li><span>Milage</span> 153k miles (246k km)</li>
                                                <li><span>Location</span>Sandston (VA)</li>
                                            </ul>
                                            <ul>
                                                <li><span>Engine</span>2.0 Diesel</li>
                                                <li><span>Transmission</span>Automated</li>
                                                <li><span>Body</span>Offroad car</li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="auction-bidding">
                                        <div class="countdown">
                                            <div id="bid_counter5"></div>
                                        </div>
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
                                        <a href="#0" class="custom-button">Submit a bid</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-12">
                            <div class="auction-item-6">
                                <div class="auction-inner">
                                    <div class="auction-thumb">
                                        <a href="product-details.html"><img src="assets/images/auction/trending/auction-4.png" alt="trending"></img></a>
                                        <a href="#0" class="rating"><i class="far fa-star"></i></a>
                                        <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                                    </div>
                                    <div class="auction-content">
                                        <h5 class="title"><a href="product-details.html">2018 Toyota Camry, L/Le/Xle/Se/Xse</a></h5>
                                        <div class="item-information">
                                            <ul>
                                                <li><span>Number</span>1-38005900</li>
                                                <li><span>VIN</span>2G1WG5EK3B1312245</li>
                                                <li><span>Milage</span> 153k miles (246k km)</li>
                                                <li><span>Location</span>Sandston (VA)</li>
                                            </ul>
                                            <ul>
                                                <li><span>Engine</span>2.0 Diesel</li>
                                                <li><span>Transmission</span>Automated</li>
                                                <li><span>Body</span>Offroad car</li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="auction-bidding">
                                        <div class="countdown">
                                            <div id="bid_counter6"></div>
                                        </div>
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
                                        <a href="#0" class="custom-button">Submit a bid</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            {/*============= Trending Section Ends Here =============*/}


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


            {/*============= Footer Section Starts Here =============*/}
            <Footer></Footer>
            {/*============= Footer Section Ends Here =============*/}

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