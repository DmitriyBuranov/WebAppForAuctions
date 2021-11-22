import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import AuctionItem from '../CommonComponents/AuctionItem';

function Product() {    
    const [auctionsNearToStart, setAuctionsNearToStart] = useState([]);

    const num = 3;

    useEffect(() => {
        fetch('api/Auctions/NearToStart' + num)
            .then(response => response.json())
            .then((data) => {
                console.log(data);
                setAuctionsNearToStart(data);
            })
            .catch(error => console.error('Unable to get AuctionsNearToStart.', error));
    }, []);


    const [auctions, setAuctions] = useState([]);

    const [parameters, setParameters] = useState({
        numberOfAuction: 10,
        sortBy: 'Name' 
     });

     function handleChanges(e) {
        console.log("Catch changes"); 
        const { name, value } = e.target;
        setParameters(parameters => ({ ...parameters, [name]: value }));
     };

    useEffect(() => {
        console.log("using effect"); 
        fetch('api/Auctions/WithBetsOrderedBy'+ parameters.sortBy + parameters.numberOfAuction)
            .then(response => response.json())
            .then((data) => {
                console.log(data);
                setAuctions(data);
            })
            .catch(error => console.error('Unable to get Auctions for pagination.', error));
    }, [parameters]);

    return (
        <div>
            {/*============= Hero Section Starts Here =============*/}
            <div className="hero-section style-2">
                <div className="container">
                    <ul className="breadcrumb">
                        <li>
                            <Link to="/home" className="user-button">Home</Link>
                        </li>
                        <li>
                            <span>Auctions</span>
                        </li>
                    </ul>
                </div>
                <div className="bg_img hero-bg bottom_center" style={{ backgroundImage: "url('/assets/images/banner/banner-bg-4.png')" }}></div>
            </div>
            {/*============= Hero Section Ends Here =============*/}


            {/*============= Featured Auction Section Starts Here =============*/}
            <section className="featured-auction-section padding-bottom mt--240 mt-lg--440 pos-rel">
                <div className="container">
                    <div className="section-header cl-white mw-100 left-style">
                        <h3 className="title">Bid on These Featured Auctions!</h3>
                    </div>
                    <div className="row justify-content-center mb-30-none">
                        {auctionsNearToStart.map((auction, i) => (
                            <AuctionItem key={i} auctionItem={auction}></AuctionItem>
                        ))}
                    </div>
                </div>
            </section>
            {/*============= Featured Auction Section Ends Here =============*/}


            {/*============= Product Auction Section Starts Here =============*/}
            <div className="product-auction padding-bottom">
                <div className="container">
                    <div className="product-header mb-40">
                        <div className="product-header-item">
                            <div className="item">Sort By : </div>
                            <select onChange = {handleChanges}  name="sortBy" className="select-bar" defaultValue = "Name">
                                <option value="All">All</option>
                                <option  value="Name">Name</option>
                                <option value="Date">Date</option>
                            </select>
                        </div>
                        <div className="product-header-item">
                            <div className="item">Show : </div>
                            <select onChange = {handleChanges}  name="numberOfAuction" className="select-bar" defaultValue = "10" >
                                <option value="05">5</option>
                                <option value="10">10</option>
                                <option value="15">15</option>
                                <option value="30">30</option>
                            </select>
                        </div>
                    </div>
                    <div className="row mb-30-none justify-content-center">
                        {auctions.map((auction, i) => (
                            <AuctionItem key={i} auctionItem={auction}></AuctionItem>
                        ))}
                    </div>
                </div>
            </div>
            {/*============= Product Auction Section Ends Here =============*/}

        </div>
    );
}

export default Product;