import React, { useState, useEffect } from 'react';
import AuctionWithBids from '../CommonComponents/AuctionWithBids';
import { Link } from 'react-router-dom';

function CarAuctionNearToEnd() {

    const [auctions, setAuctions] = useState([]);

    const num = 6;

    useEffect(() => {
        fetch('api/Auctions/NearToEnd' + num)
            .then(response => response.json())
            .then((data) => {
                console.log(data);
                setAuctions(data);
            })
            .catch(error => console.error('Unable to get AuctionsNearToEnd.', error));
    }, []);

    return (
        <section className="ending-auction padding-top pos-rel">
            <div className="popular-bg bg_img" style={{ backgroundImage: "url('/assets/images/auction/popular/popular-bg.png')" }}></div>
            <div className="container">
                <div className="section-header cl-white">
                    <span className="cate">Closing Within 24 Hours</span>
                    <h2 className="title">Auctions Ending soon</h2>
                    <p>Bid and win great deals,Our auction process is simple, efficient, and transparent.</p>
                </div>
                <div className="popular-auction-wrapper">
                    <div className="row justify-content-center mb-40-none">
                        {auctions.map((auction) => (
                            <AuctionWithBids key={auction.id} auctionItem={auction}></AuctionWithBids >
                        ))}
                    </div>
                    <div className="load-wrapper">
                        <Link to="/products" className="normal-button">See All Auction</Link>
                    </div>
                </div>
            </div>
        </section>
    );
}

export default CarAuctionNearToEnd;