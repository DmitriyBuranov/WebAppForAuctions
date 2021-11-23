import React from 'react';
import { Link } from 'react-router-dom';

function AuctionWithBids(props) {
    return(
        <div className="col-lg-6">
        <div className="auction-item-3">
            <div className="auction-thumb">
                <Link to={{pathname: `/products/${props.auctionItem.id}`}}><img src={props.auctionItem.image} alt="ending"></img></Link>
                <Link to={{pathname: `/products/${props.auctionItem.id}`}} className="bid"><i className="flaticon-auction"></i></Link>
            </div>
            <div className="auction-content">
                <h6 className="title">
                    <Link to={{pathname: `/products/${props.auctionItem.id}`}}>{props.auctionItem.name}</Link>                    
                </h6>
                <div className="bid-amount">
                    <div className="icon">
                        <i className="flaticon-auction"></i>
                    </div>
                    <div className="amount-content">
                        <div className="current">Current Bid</div>
                        <div className="amount">{props.auctionItem.currentMaxBet == null ? props.auctionItem.priceStart : props.auctionItem.currentMaxBet}</div>
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