import React from 'react';

function BidHistoryItem(props) {    
    return (
        <tr>
            <td data-history="bidder">
                <div className="user-info">
                    <div className="thumb">
                        <img src={`/assets/images/history/0${props.item.userId}.png`} alt="history" />
                    </div>
                    <div className="content">
                        {props.item.fullName}
                    </div>
                </div>
            </td>
            <td data-history="date">{new Date(props.item.date).toLocaleDateString()}</td>
            <td data-history="time">{new Date(props.item.date).toLocaleTimeString()}</td>
            <td data-history="unit price">${props.item.amount}</td>
        </tr>
    );
}

export default BidHistoryItem;