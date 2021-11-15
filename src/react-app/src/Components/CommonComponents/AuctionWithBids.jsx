import React from 'react';
import { Link } from 'react-router-dom';

function AuctionWithBids(props) {
    return(
        <div className="col-lg-6">
        <div className="auction-item-3">
            <div className="auction-thumb">
                <a href="product-details.html"><img src="assets/images/auction/ending/auction01.png" alt="ending"></img></a>
                <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
            </div>
            <div className="auction-content">
                <h6 className="title">
                    <a href="product-details.html">{props.auctionItem.name}g</a>
                </h6>
                <div className="bid-amount">
                    <div className="icon">
                        <i className="flaticon-auction"></i>
                    </div>
                    <div className="amount-content">
                        <div className="current">Current Bid</div>
                        <div className="amount">{props.auctionItem.currentMaxBet}</div>
                    </div>
                </div>
                <div className="bids-area">
                    Total Bids : <span className="total-bids">{props.auctionItem.count}</span>
                </div>
            </div>
        </div>
    </div>
    );
}

export default AuctionWithBids;