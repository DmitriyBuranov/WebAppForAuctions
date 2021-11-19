import React from 'react';
import { useSelector } from 'react-redux';

import { Redirect } from "react-router-dom";
import { selectLogged, selectLoading } from '../../features/userSlice';
import Loader from '../CommonComponents/Loader';
import ProfileLeftMenu from '../CommonComponents/ProfileLeftMenu';
import ProfileTopMenu from '../CommonComponents/ProfileTopMenu';

function MyBids() {
    const logged = useSelector(selectLogged);
    const loading = useSelector(selectLoading);

    if (logged !== true)
        return <Redirect to="/login" />

    return (
        <div>
            {loading ? <Loader /> : ""}

            <ProfileTopMenu/>

            <section className="dashboard-section padding-bottom mt--240 mt-lg--440 pos-rel">
                <div className="container">
                    <div className="row justify-content-center">

                        <ProfileLeftMenu />

                        <div className="col-lg-8">
                            <div className="dash-bid-item dashboard-widget mb-40-60">
                                <div className="header">
                                    <h4 className="title">My Bids</h4>
                                    <span className="notify"><i className="flaticon-alarm"></i> Manage Notifications</span>
                                </div>
                                <ul className="button-area nav nav-tabs">
                                    <li>
                                        <a href="#upcoming" data-toggle="tab" className="custom-button active">Upcoming</a>
                                    </li>
                                    <li>
                                        <a href="#past" data-toggle="tab" className="custom-button">Past</a>
                                    </li>
                                </ul>
                            </div>
                            <div className="tab-content">
                                <div className="tab-pane fade show active" id="upcoming">
                                    <div className="row mb-30-none justify-content-center">
                                        <div className="col-sm-10 col-md-6">
                                            <div className="auction-item-2">
                                                <div className="auction-thumb">
                                                    <a href="product-details.html"><img src="/assets/images/auction/car/auction-1.jpg" alt="car"/></a>
                                                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                                </div>
                                                <div className="auction-content">
                                                    <h6 className="title">
                                                        <a href="#0">2018 Hyundai Sonata</a>
                                                    </h6>
                                                    <div className="bid-area">
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-auction"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Current Bid</div>
                                                                <div className="amount">$876.00</div>
                                                            </div>
                                                        </div>
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-money"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Buy Now</div>
                                                                <div className="amount">$5,00.00</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div className="countdown-area">
                                                        <div className="countdown">
                                                            <div id="bid_counter26"></div>
                                                        </div>
                                                        <span className="total-bids">30 Bids</span>
                                                    </div>
                                                    <div className="text-center">
                                                        <a href="#0" className="custom-button">Submit a bid</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="col-sm-10 col-md-6">
                                            <div className="auction-item-2">
                                                <div className="auction-thumb">
                                                    <a href="product-details.html"><img src="/assets/images/auction/car/auction-2.jpg" alt="car"/></a>
                                                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                                </div>
                                                <div className="auction-content">
                                                    <h6 className="title">
                                                        <a href="#0">2018 Nissan Versa, S</a>
                                                    </h6>
                                                    <div className="bid-area">
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-auction"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Current Bid</div>
                                                                <div className="amount">$876.00</div>
                                                            </div>
                                                        </div>
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-money"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Buy Now</div>
                                                                <div className="amount">$5,00.00</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div className="countdown-area">
                                                        <div className="countdown">
                                                            <div id="bid_counter27"></div>
                                                        </div>
                                                        <span className="total-bids">30 Bids</span>
                                                    </div>
                                                    <div className="text-center">
                                                        <a href="#0" className="custom-button">Submit a bid</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="col-sm-10 col-md-6">
                                            <div className="auction-item-2">
                                                <div className="auction-thumb">
                                                    <a href="product-details.html"><img src="/assets/images/auction/product/01.png" alt="product"/></a>
                                                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                                </div>
                                                <div className="auction-content">
                                                    <h6 className="title">
                                                        <a href="#0">2019 Mercedes-Benz C, 300</a>
                                                    </h6>
                                                    <div className="bid-area">
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-auction"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Current Bid</div>
                                                                <div className="amount">$876.00</div>
                                                            </div>
                                                        </div>
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-money"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Buy Now</div>
                                                                <div className="amount">$5,00.00</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div className="countdown-area">
                                                        <div className="countdown">
                                                            <div id="bid_counter1"></div>
                                                        </div>
                                                        <span className="total-bids">30 Bids</span>
                                                    </div>
                                                    <div className="text-center">
                                                        <a href="#0" className="custom-button">Submit a bid</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="col-sm-10 col-md-6">
                                            <div className="auction-item-2">
                                                <div className="auction-thumb">
                                                    <a href="product-details.html"><img src="/assets/images/auction/product/02.png" alt="product"/></a>
                                                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                                </div>
                                                <div className="auction-content">
                                                    <h6 className="title">
                                                        <a href="#0">2017 Harley-Davidson XG750,</a>
                                                    </h6>
                                                    <div className="bid-area">
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-auction"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Current Bid</div>
                                                                <div className="amount">$876.00</div>
                                                            </div>
                                                        </div>
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-money"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Buy Now</div>
                                                                <div className="amount">$5,00.00</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div className="countdown-area">
                                                        <div className="countdown">
                                                            <div id="bid_counter2"></div>
                                                        </div>
                                                        <span className="total-bids">30 Bids</span>
                                                    </div>
                                                    <div className="text-center">
                                                        <a href="#0" className="custom-button">Submit a bid</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div className="tab-pane fade" id="past">
                                    <div className="row justify-content-center mb-30-none">
                                        <div className="col-sm-10 col-md-6">
                                            <div className="auction-item-2">
                                                <div className="auction-thumb">
                                                    <a href="product-details.html"><img src="/assets/images/auction/jewelry/auction-1.jpg" alt="jewelry"/></a>
                                                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                                </div>
                                                <div className="auction-content">
                                                    <h6 className="title">
                                                        <a href="product-details.html">Gold Ring With Clear Stones</a>
                                                    </h6>
                                                    <div className="bid-area">
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-auction"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Current Bid</div>
                                                                <div className="amount">$876.00</div>
                                                            </div>
                                                        </div>
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-money"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Buy Now</div>
                                                                <div className="amount">$5,00.00</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div className="countdown-area">
                                                        <div className="countdown">
                                                            <div id="bid_counter23"></div>
                                                        </div>
                                                        <span className="total-bids">30 Bids</span>
                                                    </div>
                                                    <div className="text-center">
                                                        <a href="#0" className="custom-button">Submit a bid</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="col-sm-10 col-md-6">
                                            <div className="auction-item-2">
                                                <div className="auction-thumb">
                                                    <a href="product-details.html"><img src="/assets/images/auction/jewelry/auction-2.jpg" alt="jewelry"/></a>
                                                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                                </div>
                                                <div className="auction-content">
                                                    <h6 className="title">
                                                        <a href="product-details.html">Ring With Clear Stone Accents</a>
                                                    </h6>
                                                    <div className="bid-area">
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-auction"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Current Bid</div>
                                                                <div className="amount">$876.00</div>
                                                            </div>
                                                        </div>
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-money"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Buy Now</div>
                                                                <div className="amount">$5,00.00</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div className="countdown-area">
                                                        <div className="countdown">
                                                            <div id="bid_counter24"></div>
                                                        </div>
                                                        <span className="total-bids">30 Bids</span>
                                                    </div>
                                                    <div className="text-center">
                                                        <a href="#0" className="custom-button">Submit a bid</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="col-sm-10 col-md-6">
                                            <div className="auction-item-2">
                                                <div className="auction-thumb">
                                                    <a href="product-details.html"><img src="/assets/images/auction/jewelry/auction-3.jpg" alt="jewelry"/></a>
                                                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                                </div>
                                                <div className="auction-content">
                                                    <h6 className="title">
                                                        <a href="product-details.html">Gold Ring With Clear Stones</a>
                                                    </h6>
                                                    <div className="bid-area">
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-auction"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Current Bid</div>
                                                                <div className="amount">$876.00</div>
                                                            </div>
                                                        </div>
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-money"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Buy Now</div>
                                                                <div className="amount">$5,00.00</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div className="countdown-area">
                                                        <div className="countdown">
                                                            <div id="bid_counter25"></div>
                                                        </div>
                                                        <span className="total-bids">30 Bids</span>
                                                    </div>
                                                    <div className="text-center">
                                                        <a href="#0" className="custom-button">Submit a bid</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="col-sm-10 col-md-6">
                                            <div className="auction-item-2">
                                                <div className="auction-thumb">
                                                    <a href="product-details.html"><img src="/assets/images/auction/product/04.png" alt="jewelry"/></a>
                                                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                                </div>
                                                <div className="auction-content">
                                                    <h6 className="title">
                                                        <a href="product-details.html">Gold Ring With Clear Stones</a>
                                                    </h6>
                                                    <div className="bid-area">
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-auction"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Current Bid</div>
                                                                <div className="amount">$876.00</div>
                                                            </div>
                                                        </div>
                                                        <div className="bid-amount">
                                                            <div className="icon">
                                                                <i className="flaticon-money"></i>
                                                            </div>
                                                            <div className="amount-content">
                                                                <div className="current">Buy Now</div>
                                                                <div className="amount">$5,00.00</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div className="countdown-area">
                                                        <div className="countdown">
                                                            <div id="bid_counter30"></div>
                                                        </div>
                                                        <span className="total-bids">30 Bids</span>
                                                    </div>
                                                    <div className="text-center">
                                                        <a href="#0" className="custom-button">Submit a bid</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    );
}

export default MyBids;