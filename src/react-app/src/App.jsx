import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import { Redirect } from 'react-router'

import Home from "./Components/Home/Home"
import Product from "./Components/Product/Product"
import Page404 from "./Components/404/404"
import Footer from './Components/CommonComponents/Footer';
import Header from './Components/CommonComponents/Header';

import Login from "./Components/User/Login"
import Register from './Components/User/Register';

import Profile from "./Components/Profile/Profile"
import Dashboard from "./Components/Profile/Dashboard"
import MyBids from "./Components/Profile/MyBids"
import MyWinnings from './Components/Profile/MyWinnings';
import ScrollToTop from './Components/CommonComponents/ScrollToTop';
import ProductDetails from './Components/ProductDetails/ProductDetails';
import CreateNewAuction from './Components/Profile/CreateNewAuction';

const App=() => {
  return (
    <BrowserRouter>
       <ScrollToTop />
    
        {/* <Loader /> */}
        <Header />

        <Switch>
            {/*<PrivateRoute exact path="/" component={Home} />*/}
            <Route path="/login" component={Login} />
            <Route path="/register" component={Register} />
            <Route path="/profile" component={Profile} />
            <Route path="/dashboard" component={Dashboard} />
            <Route path="/bids" component={MyBids} />
            <Route path="/winnings" component={MyWinnings} />
            <Route path="/home" component={Home} />

            <Route
                path="/products"
                render={({ match: { url } }) => (
                  <>
                    <Route path={`${url}/`} component={Product} exact />
                    <Route path={`${url}/:id`} component={ProductDetails} exact/>
                  </>
                )}
              />

            <Route path="/404" component={Page404} />
            <Route path="/createAuction" component={CreateNewAuction}/>
            <Redirect from="*" to="/home" />
        </Switch>

        <Footer />

    </BrowserRouter>
  );
}

export default App;
