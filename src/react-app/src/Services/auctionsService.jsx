import  { useState } from 'react';

export const auctionService = {
    GetNearToSart,
    GetNearToEnd,
    postCreateAuction
};

function GetNearToSart(num) {

    const [auctions, setAuctions] = useState([]);

    fetch('api/Auctions/NearToStart' + num)
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

    fetch('api/Auctions/NearToEnd' + num)
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
        endDate: new Date(data.endDate).toISOString(),
        priceStart: Number(data.startPrice),
        sellPrice: Number(data.sellPrice),
        priceStep: Number(data.priceStep),
        startDate: new Date(data.startDate).toISOString(),
        createDate: new Date(),
        description: "<h3 class='title'>" + data.description + "</h3><div class='item'><table class='product-info-table'><tbody><tr><th>Condition</th><td>New</td></tr><tr><th>Mileage</th><td>15,000 miles</td></tr><tr><th>Year</th><td>09-2017</td></tr><tr><th>Engine</th><td>I-4 1,5 l</td></tr><tr><th>Fuel</th><td>Regular</td></tr><tr><th>Transmission</th><td>Automatic</td></tr><tr><th>Color</th><td>Blue</td></tr><tr><th>Doors</th><td>5</td></tr></tbody></table></div>", 
        image: "/assets/images/auction/product/lada_PNG150.png"
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
    return response.json(); 
  }
  
