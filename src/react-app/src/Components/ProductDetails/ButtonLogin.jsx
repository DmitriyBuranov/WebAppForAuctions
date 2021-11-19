import React from 'react';
import { Link } from 'react-router-dom';

function ButtonLogin(props) {
    return (
        <> 
            <Link to="/login" className="custom-button">Login to submit a bid</Link>             
        </>
    );
}

export default ButtonLogin;