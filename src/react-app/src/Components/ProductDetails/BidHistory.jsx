import React from 'react';

function BidHistory(props) {    
    return (
        <div className="tab-pane fade show" id="history">
            <div className="history-wrapper">
                <div className="item">
                    <h5 className="title">Bid History</h5>
                    <div className="history-table-area">
                        <table className="history-table">
                            <thead>
                                <tr>
                                    <th>Bidder</th>
                                    <th>date</th>
                                    <th>time</th>
                                    <th>unit price</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td data-history="bidder">
                                        <div className="user-info">
                                            <div className="thumb">
                                                <img src="/assets/images/history/01.png" alt="history" />
                                            </div>
                                            <div className="content">
                                                Moses Watts
                                            </div>
                                        </div>
                                    </td>
                                    <td data-history="date">06/16/2021</td>
                                    <td data-history="time">02:45:25 PM</td>
                                    <td data-history="unit price">$900.00</td>
                                </tr>
                                <tr>
                                    <td data-history="bidder">
                                        <div className="user-info">
                                            <div className="thumb">
                                                <img src="/assets/images/history/02.png" alt="history" />
                                            </div>
                                            <div className="content">
                                                Pat Powell
                                            </div>
                                        </div>
                                    </td>
                                    <td data-history="date">06/16/2021</td>
                                    <td data-history="time">02:45:25 PM</td>
                                    <td data-history="unit price">$900.00</td>
                                </tr>
                                <tr>
                                    <td data-history="bidder">
                                        <div className="user-info">
                                            <div className="thumb">
                                                <img src="/assets/images/history/03.png" alt="history" />
                                            </div>
                                            <div className="content">
                                                Jack Rodgers
                                            </div>
                                        </div>
                                    </td>
                                    <td data-history="date">06/16/2021</td>
                                    <td data-history="time">02:45:25 PM</td>
                                    <td data-history="unit price">$900.00</td>
                                </tr>
                                <tr>
                                    <td data-history="bidder">
                                        <div className="user-info">
                                            <div className="thumb">
                                                <img src="/assets/images/history/04.png" alt="history" />
                                            </div>
                                            <div className="content">
                                                Arlene Paul
                                            </div>
                                        </div>
                                    </td>
                                    <td data-history="date">06/16/2021</td>
                                    <td data-history="time">02:45:25 PM</td>
                                    <td data-history="unit price">$900.00</td>
                                </tr>
                                <tr>
                                    <td data-history="bidder">
                                        <div className="user-info">
                                            <div className="thumb">
                                                <img src="/assets/images/history/05.png" alt="history" />
                                            </div>
                                            <div className="content">
                                                Marcia Clarke
                                            </div>
                                        </div>
                                    </td>
                                    <td data-history="date">06/16/2021</td>
                                    <td data-history="time">02:45:25 PM</td>
                                    <td data-history="unit price">$900.00</td>
                                </tr>
                            </tbody>
                        </table>
                        <div className="text-center mb-3 mt-4">
                            <a href="#0" className="button-3">Load More</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default BidHistory;