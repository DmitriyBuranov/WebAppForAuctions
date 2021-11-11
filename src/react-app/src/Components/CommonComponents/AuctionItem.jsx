import React from 'react';
import { Link } from 'react-router-dom';

function AuctionItem(props) {

    return (
        <div className="col-sm-10 col-md-6 col-lg-4">
            <div className="auction-item-2">
                <div className="auction-thumb">
                    <a href="product-details.html"><img src="assets/images/auction/car/auction-2.jpg" alt="car"></img></a>
                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                </div>
                <div className="auction-content">
                    <h6 className="title">
                        <a href="product-details.html">{props.auctionItem.name}</a>
                    </h6>
                    <div className="bid-area">
                        <div className="bid-amount">
                            <div className="icon">
                                <i className="flaticon-auction"></i>
                            </div>
                            <div className="amount-content">
                                <div className="current">Current Bid</div>
                                <div className="amount">{props.auctionItem.priceStart}</div>
                            </div>
                        </div>
                        <div className="bid-amount">
                            <div className="icon">
                                <i className="flaticon-money"></i>
                            </div>
                            <div className="amount-content">
                                <div className="current">Buy Now</div>
                                <div className="amount">{props.auctionItem.sellPrice}</div>
                            </div>
                        </div>
                    </div>
                    <div className="countdown-area">
                        <div className="countdown">
                            <div id="bid_counter27"></div>
                        </div>
                    </div>
                    <div className="text-center">
                        <a href="#0" className="custom-button">Submit a bid</a>
                    </div>
                </div>
            </div>

        </div>
    );
}

export default AuctionItem;