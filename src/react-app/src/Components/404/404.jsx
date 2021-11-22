import React from 'react';
import { Link } from 'react-router-dom';

function Page404() {

    return (
        <div className="error-section padding-top padding-bottom bg_img" style={ { backgroundImage: "url('/assets/images/error-bg.png')" } }>
        <div className="container">
            <div className="error-wrapper">
                <div className="error-thumb">
                    <img src="/assets/images/error.png" alt="error"/>
                </div>
                <h4 className="title">Return to the <Link to="/home">homepage</Link></h4>
            </div>
        </div>
    </div>
    );
}

export default  Page404 ;