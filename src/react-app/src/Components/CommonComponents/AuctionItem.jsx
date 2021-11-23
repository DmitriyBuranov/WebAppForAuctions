import React from 'react';
import { Link } from 'react-router-dom';

function AuctionItem(props) {

    return (
        <div className="col-sm-10 col-md-6 col-lg-4">
            <div className="auction-item-2">
                <div className="auction-thumb">
                    <Link to={{pathname: `/products/${props.auctionItem.id}`}}><img src={props.auctionItem.image} alt="car" widt="330" height="247"></img></Link>                    
                    <Link to={{pathname: `/products/${props.auctionItem.id}`}} className="rating"><i className="far fa-star"></i></Link>  
                    <Link to={{pathname: `/products/${props.auctionItem.id}`}} className="bid"><i className="flaticon-auction"></i></Link>                      
                </div>
                <div className="auction-content">
                    <h6 className="title">
                        <Link to={{pathname: `/products/${props.auctionItem.id}`}}>{props.auctionItem.name}</Link>                        
                    </h6>
                    <div className="bid-area">
                        <div className="bid-amount">
                            <div className="icon">
                                <i className="flaticon-auction"></i>
                            </div>
                            <div className="amount-content">
                                <div className="current">Current Bid</div>
                                <div className="amount">{props.auctionItem.currentMaxBet == null ? props.auctionItem.priceStart : props.auctionItem.currentMaxBet}</div>
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
                            <div id="bid_counter1"></div>
                        </div>
                        <span className="total-bids">{props.auctionItem.count} Bids</span>
                    </div>
                    <div className="text-center">
                        <Link to={{pathname: `/products/${props.auctionItem.id}`}} className="custom-button">Submit a bid</Link>
                    </div>
                </div>
            </div>

        </div>
    );
}

export default AuctionItem;