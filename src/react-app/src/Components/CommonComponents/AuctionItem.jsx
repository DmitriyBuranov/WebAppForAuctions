import React from 'react';
import { Link } from 'react-router-dom';

function AuctionItem(props) {

    return (
        <div class="col-sm-10 col-md-6 col-lg-4">
            <div class="auction-item-2">
                <div class="auction-thumb">
                    <a href="product-details.html"><img src="assets/images/auction/car/auction-2.jpg" alt="car"></img></a>
                    <a href="#0" class="rating"><i class="far fa-star"></i></a>
                    <a href="#0" class="bid"><i class="flaticon-auction"></i></a>
                </div>
                <div class="auction-content">
                    <h6 class="title">
                        <a href="product-details.html">{props.auctionItem.name}</a>
                    </h6>
                    <div class="bid-area">
                        <div class="bid-amount">
                            <div class="icon">
                                <i class="flaticon-auction"></i>
                            </div>
                            <div class="amount-content">
                                <div class="current">Current Bid</div>
                                <div class="amount">{props.auctionItem.currentBid}</div>
                            </div>
                        </div>
                        <div class="bid-amount">
                            <div class="icon">
                                <i class="flaticon-money"></i>
                            </div>
                            <div class="amount-content">
                                <div class="current">Buy Now</div>
                                <div class="amount">{props.auctionItem.byingPrice}</div>
                            </div>
                        </div>
                    </div>
                    <div class="countdown-area">
                        <div class="countdown">
                            <div id="bid_counter27"></div>
                        </div>
                        <span class="total-bids">{props.auctionItem.totalBids}</span>
                    </div>
                    <div class="text-center">
                        <a href="#0" class="custom-button">Submit a bid</a>
                    </div>
                </div>
            </div>

        </div>
    );
}

export default AuctionItem;