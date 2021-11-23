import React, { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { Redirect, Link } from 'react-router-dom';
import { selectJWT, selectLogged } from '../../features/userSlice';
import parse from 'html-react-parser';
import FAQs from './FAQs';
import BidHistory from './BidHistory';
import DeliveryOptions from './DeliveryOptions';
import BidArea from './BidArea';
import { HubConnectionBuilder } from '@microsoft/signalr';
import axios from 'axios';
import Loader from '../CommonComponents/Loader';
import { Alert } from 'react-bootstrap';
import BidStats from './BidStats';

function ProductDetails(props) {
    const id = Number(props.match.params.id);
    const logged = useSelector(selectLogged);
    const [loading, setLoading] = useState(false);

    const [auction, setAuction] = useState([]);

    const [betPrice, setBetPrice] = useState(0);
    const [betStats, setBetStats] = useState([]);
    const [betError, setBetError] = useState("");

    const [history, setHistory] = useState([]);

    const jwt = useSelector(selectJWT);

    const loadAuction = React.useCallback(() => {
        axios.get(`/api/auctions/${id}`)
            .then((result) => {                
                result.data.description = parse(result.data.description);
                setAuction(result.data);
                setBetPrice(result.data.currentPrice + result.data.priceStep)
                setLoading(false);
            });
    }, [id]);

    const createBet = (amount) => {
        const data = {
            auctionId: Number(id),
            amount: Number(amount)
        }

        const config = {
            headers: { Authorization: `Bearer ${jwt}` }
        };
        axios.post('/api/bets', data, config)
            .then((result) => {
                setBetError("");
            })
            .catch((error) => {
                setLoading(false);
                if (error.response.data) {
                    setAuction(obj => {
                        obj.currentPrice = error.response.data.currentPrice;
                        return obj;
                    });
                    setBetPrice(error.response.data.currentPrice + error.response.data.priceStep);
                    setBetStats(error.response.data.stats);
                    setBetError(error.response.data.error);
                }
                else {
                    setBetError(error.message);
                }
            });
    }

    const addBid = (e) => {
        e.preventDefault();
        setLoading(true);
        createBet(betPrice);
        return false;
    }

    const buyNow = (e) => {
        e.preventDefault();
        setLoading(true);
        createBet(auction.sellPrice);
        return false;
    }

    useEffect(() => {
        setLoading(true);

        loadAuction();

        axios.get(`/api/bets/stats/${id}`)
            .then((result) => {                
                setBetStats(result.data);
            })
            .catch((error) => { console.log(error); });

        const connection = new HubConnectionBuilder()
            .withUrl("https://localhost:5001/hubs/bet")
            //.withUrl("/api/hubs/bet")
            .withAutomaticReconnect([0, 3000, 5000, 10000, 15000, 30000])
            .build();

        connection.start()
            .then(result => {
                console.log('Connected!');

                connection.invoke("JoinGroup", `Auction_${id}`);

                connection.on('NewBet', data => {
                    setBetError("");
                    setLoading(false);
                    setAuction(obj => {
                        obj.currentPrice = data.currentPrice;
                        obj.priceStep = data.priceStep;
                        obj.status = data.status;
                        obj.winner = data.winner;
                        return obj;
                    })
                    setBetPrice(data.currentPrice + data.priceStep);
                    setBetStats(data.stats);
                });

                connection.on('AuctionFinished', data => {                    
                    loadAuction();
                });
            })
            .catch(e => console.log('Connection failed: ', e));
    }, [id, loadAuction]);

    useEffect(() => {
        axios.get(`/api/bets/history/${id}`)
            .then((result) => {
                if (result.data.length > 0) {
                    setHistory(result.data);
                }
            })
            .catch((error) => { console.log(error); });

    }, [id, betStats.totalBids]);

    if (isNaN(id))
        return <Redirect to="/products" />

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
                                    <img src={auction.image} alt="product" />
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

                                {
                                    (auction.status === 3) ?
                                        (
                                            <ul className="price-table mb-30">
                                                <li className="header">
                                                    <h5 className="current">Status</h5>
                                                    <h3 className="price">Finished</h3>
                                                </li>
                                                {
                                                    auction.winner !== "" ?
                                                        (
                                                            <>
                                                                <li>
                                                                    <h5 className="current">Winner</h5>
                                                                    <h5 className="price">{auction.winner}</h5>
                                                                </li>
                                                                <li>
                                                                    <h5 className="current">Win Price</h5>
                                                                    <h5 className="price">${auction.currentPrice}</h5>
                                                                </li>
                                                            </>
                                                        )
                                                        :
                                                        ""
                                                }
                                            </ul>
                                        )
                                        :
                                        (
                                            <>
                                                <ul className="price-table mb-30">
                                                    <li className="header">
                                                        <h5 className="current">Current Price</h5>
                                                        <h3 className="price">US ${auction.currentPrice}</h3>
                                                    </li>
                                                    <li>
                                                        <span className="details">Bid Increment</span>
                                                        <h5 className="info">${auction.priceStep}</h5>
                                                    </li>
                                                </ul>

                                                {betError !== "" ? <Alert variant="danger">{betError}</Alert> : ''}
                                                <BidArea loading={loading} logged={logged} betPrice={betPrice} onEdit={(e) => setBetPrice(e)} onSubmit={(e) => addBid(e)} />
                                                {
                                                    !logged ? "" :
                                                        (
                                                            <div className="buy-now-area">
                                                                <a href="#0" className="custom-button" onClick={(e) => buyNow(e)}>Buy Now: ${auction.sellPrice}</a>
                                                            </div>
                                                        )
                                                }

                                            </>
                                        )
                                }
                            </div>
                        </div>

                        <BidStats betStats={betStats} auction={auction} loadAuction={() => loadAuction()} />
                    </div >
                </div >
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
                                    <div className="content">Bid History ({betStats.totalBids})</div>
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
                                {auction.description}
                            </div>
                        </div>
                        <DeliveryOptions />
                        <BidHistory items={history} totalBids={betStats.totalBids} />
                        <FAQs />
                    </div>
                </div>
            </section >
        </div >
    );
}

export default ProductDetails;