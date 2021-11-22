import  { useState } from 'react';

export const auctionService = {
    GetNearToSart,
    GetNearToEnd,
    postCreateAuction
};

function GetNearToSart(num) {

    const [auctions, setAuctions] = useState([]);

    fetch('api/v1/Auctions/NearToStart' + num)
        .then(response => response.json())
        .then((data) => {
            console.log(data);
            setAuctions(data);
        })
        .catch(error => console.error('Unable to get AuctionsNearToStart.', error));

    return auctions
}

function GetNearToEnd(num) {

    const [auctions, setAuctions] = useState([]);

    fetch('api/v1/Auctions/NearToEnd' + num)
        .then(response => response.json())
        .then((data) => {
            console.log(data);
            setAuctions(data);
        })
        .catch(error => console.error('Unable to get AuctionsNearToEnd.', error));

    return auctions
}


async function postCreateAuction( data = {}, token) {

    const dataForRequest = {
        name: data.name,
        endDate: new Date(data.endtDate).toISOString(),
        priceStart: Number(data.startPrice),
        sellPrice: Number(data.sellPrice),
        priceStep: Number(data.priceStep),
        startDate: new Date(data.startDate).toISOString()
    }

    const response = await fetch("/api/Auctions", {
      method: 'POST', 
      mode: 'cors', 
      cache: 'no-cache', 
      credentials: 'same-origin', 
      headers: {
        'Content-Type': 'application/json',
        'Authorization' : 'Bearer ' + token
      },
      redirect: 'follow', 
      referrerPolicy: 'no-referrer', 
      body: JSON.stringify(dataForRequest) 
    });
    return response.statusText; 
  }
  
