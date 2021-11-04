import React from 'react';
import { Router, Route, Switch } from 'react-router-dom'
import { Redirect } from 'react-router'
import  PrivateRoute from './Services/PrivateRoute'


import Home from "./Components/Home/Home"
import Product from "./Components/Product/Product"
import ProductDetails from "./Components/ProductDetails/ProductDetails"
import Profile from "./Components/Profile/Profile"
import { history } from "./Services/history"
import Page404 from "./Components/404/404"




const App=() => {

  return (
    <Router history={history}>
        <Switch>
            {/*<PrivateRoute exact path="/" component={Home} />*/}
            <Route path="/profile" component={Profile} />
            <Route path="/home" component={Home} />
            <Route path="/product" component={Product} />
            <Route path="/productDetails" component={ProductDetails} />
            <Route path="/404" component={Page404} />
            <Redirect from="*" to="/home" />
        </Switch>
    </Router>
  );
}

export default App;
