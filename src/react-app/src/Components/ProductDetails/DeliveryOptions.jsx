import React from 'react';

function DeliveryOptions(props) {
    return (
        <div className="tab-pane fade show" id="delevery">
            <div className="shipping-wrapper">
                <div className="item">
                    <h5 className="title">shipping</h5>
                    <div className="table-wrapper">
                        <table className="shipping-table">
                            <thead>
                                <tr>
                                    <th>Available delivery methods </th>
                                    <th>Price</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Customer Pick-up (within 10 days)</td>
                                    <td>$0.00</td>
                                </tr>
                                <tr>
                                    <td>Standard Shipping (5-7 business days)</td>
                                    <td>Not Applicable</td>
                                </tr>
                                <tr>
                                    <td>Expedited Shipping (2-4 business days)</td>
                                    <td>Not Applicable</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div className="item">
                    <h5 className="title">Notes</h5>
                    <p>Please carefully review our shipping and returns policy before committing to a bid.
                        From time to time, and at its sole discretion, Sbidu may change the prevailing fee structure for shipping and handling.</p>
                </div>
            </div>
        </div>
    );
}

export default DeliveryOptions;