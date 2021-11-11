import React, { useState } from 'react';

export const auctionService = {
    getNearToSart,
    getNearToEnd,
};

function getNearToSart(num) {

    const [auctions, setAuctions] = [];

    fetch('api/v1/Auctions/NearToStart' + num)
        .then(response => response.json())
        .then((data) => {
            console.log(data);
            setAuctions(data);
        })
        .catch(error => console.error('Unable to get AuctionsNearToStart.', error));

    return auctions
}

function getNearToEnd(num) {

    const [auctions, setAuctions] = [];

    fetch('api/v1/Auctions/NearToEnd' + num)
        .then(response => response.json())
        .then((data) => {
            console.log(data);
            setAuctions(data);
        })
        .catch(error => console.error('Unable to get AuctionsNearToEnd.', error));

    return auctions
}
