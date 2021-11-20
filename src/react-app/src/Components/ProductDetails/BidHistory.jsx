import React from 'react';
import BidHistoryItem from './BidHistoryItem';

function BidHistory(props) {
    console.log(props)
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
                                {
                                    props.items.map((item) => (
                                        <BidHistoryItem key={item.id} item={item} ></BidHistoryItem>
                                    ))
                                }
                            </tbody>
                        </table>
                        {/* {
                            props.totalBids !== props.items.length ?
                                (
                                    <div className="text-center mb-3 mt-4">
                                        <a href="#0" className="button-3" onClick={(e) => props.onClick(props.page + 1)}>Load More</a>
                                    </div>
                                )
                                :
                                ""
                        } */}
                    </div>
                </div>
            </div>
        </div>
    );
}

export default BidHistory;