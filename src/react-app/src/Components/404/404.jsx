import React from 'react';
import { Link } from 'react-router-dom';

function Page404() {

    return (
        <div className="col-lg-8 offset-lg-2">
            <div>
                <h1>
                    <span>Page Not Found. Eror 404.</span>
                </h1>
                <span>Sorry, we can't find that page! Don't worry though, everything is STILL AWESOME!</span>
                <p>
                <Link to="/home" className="btn btn-link">Back to site</Link>
                </p>
            </div>
            <img src="./assets/images/emmet-fe70d8bbd77eb5ec2f0a84f515f5121b.png"></img>

        </div>
    );
}

export default  Page404 ;