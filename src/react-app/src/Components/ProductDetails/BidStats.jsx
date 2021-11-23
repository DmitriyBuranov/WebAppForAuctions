import React from 'react';
import Countdown from "react-countdown";

function BidStats(props) {
    // Random component
    const Completionist = () => <span>Auction finished!</span>;

    // Renderer callback with condition
    const renderer = ({ days, hours, minutes, seconds, completed }) => {
        if (completed) {
            // props.loadAuction();
            // Render a complete state
            return <Completionist />;
        } else {
            // Render a countdown
            return (
                <span>
                    {days}d : {hours}h : {minutes}m : {seconds}s
                </span>
            );
        }
    };

    return (
        <div className="col-lg-4">
            <div className="product-sidebar-area">
                <div className="product-single-sidebar mb-3">
                    <h6 className="title">This Auction Ends in:</h6>
                    <div className="countdown">
                        <div id="bid_counter1">
                            {
                                props.auction.status === 3 ? <Completionist /> : <Countdown date={new Date(props.auction.finish)} renderer={renderer} />
                            }
                        </div>
                    </div>
                    <div className="side-counter-area">
                        <div className="side-counter-item">
                            <div className="thumb">
                                <img src="/assets/images/product/icon1.png" alt="product" />
                            </div>
                            <div className="content">
                                <h3 className="count-title"><span className="counter">{props.betStats.activeBidders}</span></h3>
                                <p>Active Bidders</p>
                            </div>
                        </div>
                        <div className="side-counter-item">
                            <div className="thumb">
                                <img src="/assets/images/product/icon2.png" alt="product" />
                            </div>
                            <div className="content">
                                <h3 className="count-title"><span className="counter">{props.betStats.watching}</span></h3>
                                <p>Watching</p>
                            </div>
                        </div>
                        <div className="side-counter-item">
                            <div className="thumb">
                                <img src="/assets/images/product/icon3.png" alt="product" />
                            </div>
                            <div className="content">
                                <h3 className="count-title"><span className="counter">{props.betStats.totalBids}</span></h3>
                                <p>Total Bids</p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    );
}

export default BidStats;