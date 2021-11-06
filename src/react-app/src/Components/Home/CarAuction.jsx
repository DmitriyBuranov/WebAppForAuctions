import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import AuctionItem from '../CommonComponents/AuctionItem';

function CarAuction() {

    const [auctions, setAuctions] = useState([]);

    fetch('api/v1/Auctions')
    .then(response => response.json())
    .then((data) => {
        console.log(data);
        setAuctions(data);
    })
    .catch(error => console.error('Unable to get Auctions.', error));

    const auctionItem =   {
        name: '2021 Lada 6',
        currentBid: '$651.00',
        byingPrice: '$3568.00',
        totalBids: '99 Bids'
        /*img: ,*/
        /*timer: ,*/
        /*id: ,*/
      };


    return (
        <div>
            <section class="car-auction-section padding-bottom pos-rel oh">
                <div class="car-bg"><img src="assets/images/auction/car/car-bg.png" alt="car"></img></div>
                <div class="container">
                    <div class="section-header-3">
                        <div class="left d-block">
                            <h2 class="title mb-3">Featured Items</h2>
                            <p>Start winning cars with comfort</p>
                        </div>
                        {/*Вставить ссылку на страницу продуктов*/}
                        <a href="#0" class="normal-button">View All</a>
                    </div>
                    <div class="row justify-content-center mb-30-none">                        
                            <AuctionItem auctionItem = {auctionItem}></AuctionItem>
                            <AuctionItem auctionItem = {auctionItem}></AuctionItem> 
                            <AuctionItem auctionItem = {auctionItem}></AuctionItem>                      
                    </div>
                </div>
            </section>
        </div>
    );
}

export default CarAuction;