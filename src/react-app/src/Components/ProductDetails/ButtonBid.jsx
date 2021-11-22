import React from 'react';

function ButtonBid(props) {    
    return (
        <>            
            <input type="text" placeholder="Enter you bid amount" value={props.betPrice} onChange={(e) => props.onEdit(e.target.value)} />
            <button type="submit" className="custom-button">Submit a bid</button>
        </>
    );
}

export default ButtonBid;