import React from 'react';
import ButtonLogin from './ButtonLogin';
import ButtonBid from './ButtonBid';

function BidArea(props) {
    return (
        <>
            <div className="product-bid-area">
                <form className="product-bid-form" onSubmit={(e) => props.onSubmit(e)}>
                    <div className="search-icon">
                        <img src="/assets/images/product/search-icon.png" alt="product" />
                    </div>
                    {props.logged ? <ButtonBid betPrice={props.betPrice} onEdit={(e) => props.onEdit(e)} /> : <ButtonLogin />}
                </form>
            </div>
        </>
    );
}

export default BidArea;