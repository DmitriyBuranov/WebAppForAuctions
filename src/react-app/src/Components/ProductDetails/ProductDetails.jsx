import React, { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { Link } from 'react-router-dom';
import { selectJWT, selectLogged } from '../../features/userSlice';
import parse from 'html-react-parser';
import FAQs from './FAQs';
import BidHistory from './BidHistory';
import DeliveryOptions from './DeliveryOptions';
import BidArea from './BidArea';
import { HubConnectionBuilder } from '@microsoft/signalr';
import axios from 'axios';
import Loader from '../CommonComponents/Loader';

function ProductDetails(props) {
    const logged = useSelector(selectLogged);

    const [auction, setAuction] = useState([]);
    const [description, setDescription] = useState("");
    const [bidPrice, setBidPrice] = useState(0);
    const [auctionPrice, setAuctionPrice] = useState(0);
    const [loading, setLoading] = useState(false); 
    
    const id = Number(props.match.params.id);
    const jwt = useSelector(selectJWT);

    const onAddBid = (e) => {
        e.preventDefault();
    
        setLoading(true);        

        const data = {
            auctionId: Number(id),
            amount: Number(bidPrice)
        }

        const config = {
            headers: { Authorization: `Bearer ${jwt}` }
        };
        axios.post('/api/bets', data, config)
            .then((result) => {
                //setLoading(false);                
            })            
            .catch((error) => {
                console.log(error);                
            });
        
        return false;
    }

    useEffect(() => {
        setLoading(true);   
        axios.get(`/api/auctions/${id}`)
            .then((result) => {
                console.log(result.data);
                setAuction(result.data);
                setAuctionPrice(result.data.priceStart);
                setDescription(parse(result.data.description))
                setBidPrice(result.data.priceStart + result.data.priceStep)
                setLoading(false); 
            });
    }, [id]);

    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl("https://localhost:5001/hubs/bet")
            //.withUrl("/api/hubs/bet/")
            .withAutomaticReconnect([0, 3000, 5000, 10000, 15000, 30000])
            .build();

        connection.start()
            .then(result => {
                console.log('Connected!');

                connection.invoke("JoinGroup", `Auction_${id}`);

                connection.on('NewBet', data => {
                    debugger;
                    setLoading(false); 
                    setAuctionPrice(data.priceStart);                    
                    setBidPrice(data.priceStart + data.priceStep);
                });
            })
            .catch(e => console.log('Connection failed: ', e));
    }, [id]);

    return (
        <div>

            {loading ? <Loader /> : ""}


            <div className="hero-section style-2">
                <div className="container">
                    <ul className="breadcrumb">
                        <li>
                            <Link to="/home" className="user-button">Home</Link>
                        </li>
                        <li>
                            <Link to="/products" className="user-button">Actions</Link>
                        </li>
                        <li>
                            <span>{auction.name}</span>
                        </li>
                    </ul>
                </div>
                <div className="bg_img hero-bg bottom_center" style={{ backgroundImage: "url('/assets/images/banner/hero-bg.png')" }}></div>
            </div>

            <section className="product-details padding-bottom mt--240 mt-lg--440">
                <div className="container">
                    <div className="product-details-slider-top-wrapper">
                        <div className="product-details-slider owl-theme owl-carousel" style={{ display: 'block' }} id="sync1">
                            <div className="slide-top-item">
                                <div className="slide-inner">
                                    <img src="/assets/images/product/product1.png" alt="product" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="row mt-40-60-80">
                        <div className="col-lg-8">
                            <div className="product-details-content">
                                <div className="product-details-header">
                                    <h2 className="title">{auction.name}</h2>
                                    <ul>
                                        <li>Item #: {auction.id}</li>
                                    </ul>
                                </div>
                                <ul className="price-table mb-30">
                                    <li className="header">
                                        <h5 className="current">Current Price</h5>
                                        <h3 className="price">US ${auctionPrice}</h3>
                                    </li>
                                    <li>
                                        <span className="details">Bid Increment (US)</span>
                                        <h5 className="info">${auction.priceStep}</h5>
                                    </li>
                                </ul>

                                <BidArea loading={loading} logged={logged} bidPrice={bidPrice} onEdit={(e) => setBidPrice(e)} onSubmit={(e) => onAddBid(e)} />

                                {/* <div className="buy-now-area">
                                    <a href="#0" className="custom-button">Buy Now: ${auction.sellPrice}</a>                                    
                                </div> */}
                            </div>
                        </div>
                        <div className="col-lg-4">
                            <div className="product-sidebar-area">
                                <div className="product-single-sidebar mb-3">
                                    <h6 className="title">This Auction Ends in:</h6>
                                    <div className="countdown">
                                        <div id="bid_counter1"></div>
                                    </div>
                                    <div className="side-counter-area">
                                        <div className="side-counter-item">
                                            <div className="thumb">
                                                <img src="/assets/images/product/icon1.png" alt="product" />
                                            </div>
                                            <div className="content">
                                                <h3 className="count-title"><span className="counter">61</span></h3>
                                                <p>Active Bidders</p>
                                            </div>
                                        </div>
                                        <div className="side-counter-item">
                                            <div className="thumb">
                                                <img src="/assets/images/product/icon2.png" alt="product" />
                                            </div>
                                            <div className="content">
                                                <h3 className="count-title"><span className="counter">203</span></h3>
                                                <p>Watching</p>
                                            </div>
                                        </div>
                                        <div className="side-counter-item">
                                            <div className="thumb">
                                                <img src="/assets/images/product/icon3.png" alt="product" />
                                            </div>
                                            <div className="content">
                                                <h3 className="count-title"><span className="counter">82</span></h3>
                                                <p>Total Bids</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div className="product-tab-menu-area mb-40-60 mt-70-100">
                    <div className="container">
                        <ul className="product-tab-menu nav nav-tabs">
                            <li>
                                <a href="#details" className="active" data-toggle="tab">
                                    <div className="thumb">
                                        <img src="/assets/images/product/tab1.png" alt="product" />
                                    </div>
                                    <div className="content">Description</div>
                                </a>
                            </li>
                            <li>
                                <a href="#delevery" data-toggle="tab">
                                    <div className="thumb">
                                        <img src="/assets/images/product/tab2.png" alt="product" />
                                    </div>
                                    <div className="content">Delivery Options</div>
                                </a>
                            </li>
                            <li>
                                <a href="#history" data-toggle="tab">
                                    <div className="thumb">
                                        <img src="/assets/images/product/tab3.png" alt="product" />
                                    </div>
                                    <div className="content">Bid History (36)</div>
                                </a>
                            </li>
                            <li>
                                <a href="#questions" data-toggle="tab">
                                    <div className="thumb">
                                        <img src="/assets/images/product/tab4.png" alt="product" />
                                    </div>
                                    <div className="content">Questions </div>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div className="container">
                    <div className="tab-content">
                        <div className="tab-pane fade show active" id="details">
                            <div className="tab-details-content">
                                {description}
                            </div>
                        </div>
                        <DeliveryOptions />
                        <BidHistory />
                        <FAQs />
                    </div>
                </div>
            </section>
        </div>
    );
}

export default ProductDetails;