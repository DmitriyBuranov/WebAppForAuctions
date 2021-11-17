import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import AuctionItem from '../CommonComponents/AuctionItem';
import { auctionService } from '../../Services/auctionsService';

function CarAuctionNearToStart() {

    const [auctions, setAuctions] = useState([]);

    const num = 3;

    useEffect(() => {
        fetch('api/v1/Auctions/NearToStart' + num)
            .then(response => response.json())
            .then((data) => {
                console.log(data);
                setAuctions(data);
            })
            .catch(error => console.error('Unable to get AuctionsNearToStart.', error));
    }, []);

    return (
        <div>
            <section className="car-auction-section padding-bottom pos-rel oh">
                <div className="car-bg"><img src="assets/images/auction/car/car-bg.png" alt="car"></img></div>
                <div className="container">
                    <div className="section-header-3">
                        <div className="left d-block">
                            <h2 className="title mb-3">Featured Items</h2>
                            <p>Start winning cars with comfort</p>
                        </div>
                        <a href="/product" className="normal-button">View All</a>
                    </div>
                    <div className="row justify-content-center mb-30-none">
                        {auctions.map((auction) => (
                            <AuctionItem auctionItem={auction}></AuctionItem>
                        ))}
                    </div>
                </div>
            </section>
        </div>
    );
}

export default CarAuctionNearToStart;