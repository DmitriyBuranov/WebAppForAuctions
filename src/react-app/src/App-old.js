function App() {
  return (
    <div>
        {/* ============= ScrollToTop Section Starts Here ============= */}
        <div className="overlayer" id="overlayer">
            <div className="loader">
                <div className="loader-inner"></div>
            </div>
        </div>
        <a href="#0" className="scrollToTop"><i className="fas fa-angle-up"></i></a>
        <div className="overlay"></div>
        {/* ============= ScrollToTop Section Ends Here =============*/}
    
    
        {/*============= Header Section Starts Here =============*/}
        <header>
            <div className="header-top">
                <div className="container">
                    <div className="header-top-wrapper">
                        <ul className="customer-support">
                            <li>
                                <a href="#0" className="mr-3"><i className="fas fa-phone-alt"></i><span className="ml-2 d-none d-sm-inline-block">Customer Support</span></a>
                            </li>
                            <li>
                                <i className="fas fa-globe"></i>
                                <select name="language" className="select-bar">
                                    <option value="en">En</option>
                                    <option value="Bn">Bn</option>
                                    <option value="Rs">Rs</option>
                                    <option value="Us">Us</option>
                                    <option value="Pk">Pk</option>
                                    <option value="Arg">Arg</option>
                                </select>
                            </li>
                        </ul>
                        <ul className="cart-button-area">
                            <li>
                                <a href="#0" className="cart-button"><i className="flaticon-shopping-basket"></i><span className="amount">08</span></a>
                            </li>                        
                            <li>
                                <a href="sign-in.html" className="user-button"><i className="flaticon-user"></i></a>
                            </li>                        
                        </ul>
                    </div>
                </div>
            </div>
            <div className="header-bottom">
                <div className="container">
                    <div className="header-wrapper">
                        <div className="logo">
                            <a href="index.html">
                                <img src="/assets/images/logo/logo.png" alt="logo"></img>
                            </a>
                        </div>
                        <ul className="menu ml-auto">
                            <li>
                                <a href="#0">Home</a>
                                <ul className="submenu">
                                    <li>
                                        <a href="index.html">Home Page One</a>
                                    </li>
                                    <li>
                                        <a href="index-2.html">Home Page Two</a>
                                    </li>
                                    <li>
                                        <a href="index-3.html">Home Page Three</a>
                                    </li>
                                    <li>
                                        <a href="index-4.html">Home Page Four</a>
                                    </li>
                                    <li>
                                        <a href="index-5.html">Home Page Five</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a href="product.html">Auction</a>
                            </li>
                            <li>
                                <a href="#0">Pages</a>
                                <ul className="submenu">
                                    <li>
                                        <a href="#0">Product</a>
                                        <ul className="submenu">
                                            <li>
                                                <a href="product.html">Product Page 1</a>
                                            </li>
                                            <li>
                                                <a href="product-2.html">Product Page 2</a>
                                            </li>
                                            <li>
                                                <a href="product-details.html">Product Details</a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a href="#0">My Account</a>
                                        <ul className="submenu">
                                            <li>
                                                <a href="sign-up.html">Sign Up</a>
                                            </li>
                                            <li>
                                                <a href="sign-in.html">Sign In</a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a href="#0">Dashboard</a>
                                        <ul className="submenu">
                                            <li>
                                                <a href="dashboard.html">Dashboard</a>
                                            </li>
                                            <li>
                                                <a href="profile.html">Personal Profile</a>
                                            </li>
                                            <li>
                                                <a href="my-bid.html">My Bids</a>
                                            </li>
                                            <li>
                                                <a href="winning-bids.html">Winning Bids</a>
                                            </li>
                                            <li>
                                                <a href="notifications.html">My Alert</a>
                                            </li>
                                            <li>
                                                <a href="my-favorites.html">My Favorites</a>
                                            </li>
                                            <li>
                                                <a href="referral.html">Referrals</a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a href="about.html">About Us</a>
                                    </li>
                                    <li>
                                        <a href="faqs.html">Faqs</a>
                                    </li>
                                    <li>
                                        <a href="error.html">404 Error</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a href="contact.html">Contact</a>
                            </li>
                        </ul>
                        <form className="search-form">
                            <input type="text" placeholder="Search for brand, model...."></input>
                            <button type="submit"><i className="fas fa-search"></i></button>
                        </form>
                        <div className="search-bar d-md-none">
                            <a href="#0"><i className="fas fa-search"></i></a>
                        </div>
                        <div className="header-bar d-lg-none">
                            <span></span>
                            <span></span>
                            <span></span>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        {/*============= Header Section Ends Here =============*/}
    
        {/*============= Cart Section Starts Here =============*/}
        <div className="cart-sidebar-area">
            <div className="top-content">
                <a href="index.html" className="logo">
                    <img src="/assets/images/logo/logo2.png" alt="logo"></img>
                </a>
                <span className="side-sidebar-close-btn"><i className="fas fa-times"></i></span>
            </div>
            <div className="bottom-content">
                <div className="cart-products">
                    <h4 className="title">Shopping cart</h4>
                    <div className="single-product-item">
                        <div className="thumb">
                            <a href="#0"><img src="/assets/images/shop/shop01.jpg" alt="shop"></img></a>
                        </div>
                        <div className="content">
                            <h4 className="title"><a href="#0">Color Pencil</a></h4>
                            <div className="price"><span className="pprice">$80.00</span> <del className="dprice">$120.00</del></div>
                            {/*<a href="#" className="remove-cart">Remove</a>*/}
                        </div>
                    </div>
                    <div className="single-product-item">
                        <div className="thumb">
                            <a href="#0"><img src="/assets/images/shop/shop02.jpg" alt="shop"></img></a>
                        </div>
                        <div className="content">
                            <h4 className="title"><a href="#0">Water Pot</a></h4>
                            <div className="price"><span className="pprice">$80.00</span> <del className="dprice">$120.00</del></div>
                            {/*<a href="#" className="remove-cart">Remove</a>*/}
                        </div>
                    </div>
                    <div className="single-product-item">
                        <div className="thumb">
                            <a href="#0"><img src="/assets/images/shop/shop03.jpg" alt="shop"></img></a>
                        </div>
                        <div className="content">
                            <h4 className="title"><a href="#0">Art Paper</a></h4>
                            <div className="price"><span className="pprice">$80.00</span> <del className="dprice">$120.00</del></div>
                            {/*<a href="#" className="remove-cart">Remove</a>*/}
                        </div>
                    </div>
                    <div className="single-product-item">
                        <div className="thumb">
                            <a href="#0"><img src="/assets/images/shop/shop04.jpg" alt="shop"></img></a>
                        </div>
                        <div className="content">
                            <h4 className="title"><a href="#0">Stop Watch</a></h4>
                            <div className="price"><span className="pprice">$80.00</span> <del className="dprice">$120.00</del></div>
                            {/*<a href="#" className="remove-cart">Remove</a>*/}
                        </div>
                    </div>
                    <div className="single-product-item">
                        <div className="thumb">
                            <a href="#0"><img src="/assets/images/shop/shop05.jpg" alt="shop"></img></a>
                        </div>
                        <div className="content">
                            <h4 className="title"><a href="#0">Comics Book</a></h4>
                            <div className="price"><span className="pprice">$80.00</span> <del className="dprice">$120.00</del></div>
                            {/*<a href="#" className="remove-cart">Remove</a>*/}
                        </div>
                    </div>
                    <div className="btn-wrapper text-center">
                        <a href="#0" className="custom-button"><span>Checkout</span></a>
                    </div>
                </div>
            </div>
        </div>
        {/*============= Cart Section Ends Here =============*/}
    
    
        {/*============= Banner Section Starts Here =============*/}
        <section className="banner-section bg_img" data-background="assets/images/banner/banner-bg-1.png">
            <div className="container">
                <div className="row align-items-center justify-content-between">
                    <div className="col-lg-6 col-xl-6">
                        <div className="banner-content cl-white">
                            <h5 className="cate">Next Generation Auction</h5>
                            <h1 className="title"><span className="d-xl-block">Find Your</span> Next Deal!</h1>
                            <p>
                                Online Auction is where everyone goes to shop, sell,and give, while discovering variety and affordability.
                            </p>
                            <a href="#0" className="custom-button yellow btn-large">Get Started</a>
                        </div>
                    </div>
                    <div className="d-none d-lg-block col-lg-6">
                        <div className="banner-thumb-2">
                            <img src="/assets/images/banner/banner-1.png" alt="banner"></img>
                        </div>
                    </div>
                </div>
            </div>
            <div className="banner-shape d-none d-lg-block">
                <img src="/assets/css/img/banner-shape.png" alt="css"></img>
            </div>
        </section>
        {/*============= Banner Section Ends Here =============*/}
    
    
        <div className="browse-section ash-bg">
            {/*============= Hightlight Slider Section Starts Here =============*/}
            <div className="browse-slider-section mt--140">
                <div className="container">
                    <div className="section-header-2 cl-white mb-4">
                        <div className="left">
                            <h6 className="title pl-0 w-100">Browse the highlights</h6>
                        </div>
                        <div className="slider-nav">
                            <a href="#0" className="bro-prev"><i className="flaticon-left-arrow"></i></a>
                            <a href="#0" className="bro-next active"><i className="flaticon-right-arrow"></i></a>
                        </div>
                    </div>
                    <div className="m--15">
                        <div className="browse-slider owl-theme owl-carousel">
                            <a href="#0" className="browse-item">
                                <img src="/assets/images/auction/01.png" alt="auction"></img>
                                <span className="info">Vehicles</span>
                            </a>
                            <a href="#0" className="browse-item">
                                <img src="/assets/images/auction/02.png" alt="auction"></img>
                                <span className="info">Jewelry</span>
                            </a>
                            <a href="#0" className="browse-item">
                                <img src="/assets/images/auction/03.png" alt="auction"></img>
                                <span className="info">Watches</span>
                            </a>
                            <a href="#0" className="browse-item">
                                <img src="/assets/images/auction/04.png" alt="auction"></img>
                                <span className="info">Electronics</span>
                            </a>
                            <a href="#0" className="browse-item">
                                <img src="/assets/images/auction/05.png" alt="auction"></img>
                                <span className="info">Sports</span>
                            </a>
                            <a href="#0" className="browse-item">
                                <img src="/assets/images/auction/06.png" alt="auction"></img>
                                <span className="info">Real Estate</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            {/*============= Hightlight Slider Section Ends Here =============*/}
            
            {/*============= Car Auction Section Starts Here =============*/}
            <section className="car-auction-section padding-bottom padding-top pos-rel oh">
                <div className="car-bg"><img src="/assets/images/auction/car/car-bg.png" alt="car"></img></div>
                <div className="container">
                    <div className="section-header-3">
                        <div className="left">
                            <div className="thumb">
                                <img src="/assets/images/header-icons/car-1.png" alt="header-icons"></img>
                            </div>
                            <div className="title-area">
                                <h2 className="title">Vehicles</h2>
                                <p>We offer affordable Vehicles</p>
                            </div>
                        </div>
                        <a href="#0" className="normal-button">View All</a>
                    </div>
                    <div className="row justify-content-center mb-30-none">
                        <div className="col-sm-10 col-md-6 col-lg-4">
                            <div className="auction-item-2">
                                <div className="auction-thumb">
                                    <a href="product-details.html"><img src="/assets/images/auction/car/auction-1.jpg" alt="car"></img></a>
                                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                </div>
                                <div className="auction-content">
                                    <h6 className="title">
                                        <a href="product-details.html">2018 Hyundai Sonata</a>
                                    </h6>
                                    <div className="bid-area">
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-money"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Buy Now</div>
                                                <div className="amount">$5,00.00</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div className="countdown-area">
                                        <div className="countdown">
                                            <div id="bid_counter26"></div>
                                        </div>
                                        <span className="total-bids">30 Bids</span>
                                    </div>
                                    <div className="text-center">
                                        <a href="#0" className="custom-button">Submit a bid</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-sm-10 col-md-6 col-lg-4">
                            <div className="auction-item-2">
                                <div className="auction-thumb">
                                    <a href="product-details.html"><img src="/assets/images/auction/car/auction-2.jpg" alt="car"></img></a>
                                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                </div>
                                <div className="auction-content">
                                    <h6 className="title">
                                        <a href="product-details.html">2018 Nissan Versa, S</a>
                                    </h6>
                                    <div className="bid-area">
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-money"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Buy Now</div>
                                                <div className="amount">$5,00.00</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div className="countdown-area">
                                        <div className="countdown">
                                            <div id="bid_counter27"></div>
                                        </div>
                                        <span className="total-bids">30 Bids</span>
                                    </div>
                                    <div className="text-center">
                                        <a href="#0" className="custom-button">Submit a bid</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-sm-10 col-md-6 col-lg-4">
                            <div className="auction-item-2">
                                <div className="auction-thumb">
                                    <a href="product-details.html"><img src="/assets/images/auction/car/auction-3.jpg" alt="car"></img></a>
                                    <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                </div>
                                <div className="auction-content">
                                    <h6 className="title">
                                        <a href="product-details.html">2018 Honda Accord, Sport</a>
                                    </h6>
                                    <div className="bid-area">
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-money"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Buy Now</div>
                                                <div className="amount">$5,00.00</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div className="countdown-area">
                                        <div className="countdown">
                                            <div id="bid_counter28"></div>
                                        </div>
                                        <span className="total-bids">30 Bids</span>
                                    </div>
                                    <div className="text-center">
                                        <a href="#0" className="custom-button">Submit a bid</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            {/*============= Car Auction Section Ends Here =============*/}
        </div>
    
    
        {/*============= Jewelry Auction Section Starts Here =============*/}
        <section className="jewelry-auction-section padding-bottom padding-top pos-rel">
            <div className="jewelry-bg d-none d-xl-block"><img src="/assets/images/auction/jewelry/jwelry-bg.png" alt="jewelry"></img></div>
            <div className="container">
                <div className="section-header-3">
                    <div className="left">
                        <div className="thumb">
                            <img src="/assets/images/header-icons/coin-1.png" alt="header-icons"></img>
                        </div>
                        <div className="title-area">
                            <h2 className="title">Jewelry</h2>
                            <p>Online jewelry auctions where you can bid now and save money</p>
                        </div>
                    </div>
                    <a href="#0" className="normal-button">View All</a>
                </div>
                <div className="row justify-content-center mb-30-none">
                    <div className="col-sm-10 col-md-6 col-lg-4">
                        <div className="auction-item-2">
                            <div className="auction-thumb">
                                <a href="product-details.html"><img src="/assets/images/auction/jewelry/auction-1.jpg" alt="jewelry"></img></a>
                                <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                            </div>
                            <div className="auction-content">
                                <h6 className="title">
                                    <a href="product-details.html">Gold Ring With Clear Stones</a>
                                </h6>
                                <div className="bid-area">
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-money"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Buy Now</div>
                                            <div className="amount">$5,00.00</div>
                                        </div>
                                    </div>
                                </div>
                                <div className="countdown-area">
                                    <div className="countdown">
                                        <div id="bid_counter23"></div>
                                    </div>
                                    <span className="total-bids">30 Bids</span>
                                </div>
                                <div className="text-center">
                                    <a href="#0" className="custom-button">Submit a bid</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-sm-10 col-md-6 col-lg-4">
                        <div className="auction-item-2">
                            <div className="auction-thumb">
                                <a href="product-details.html"><img src="/assets/images/auction/jewelry/auction-2.jpg" alt="jewelry"></img></a>
                                <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                            </div>
                            <div className="auction-content">
                                <h6 className="title">
                                    <a href="product-details.html">Ring With Clear Stone Accents</a>
                                </h6>
                                <div className="bid-area">
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-money"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Buy Now</div>
                                            <div className="amount">$5,00.00</div>
                                        </div>
                                    </div>
                                </div>
                                <div className="countdown-area">
                                    <div className="countdown">
                                        <div id="bid_counter24"></div>
                                    </div>
                                    <span className="total-bids">30 Bids</span>
                                </div>
                                <div className="text-center">
                                    <a href="#0" className="custom-button">Submit a bid</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-sm-10 col-md-6 col-lg-4">
                        <div className="auction-item-2">
                            <div className="auction-thumb">
                                <a href="product-details.html"><img src="/assets/images/auction/jewelry/auction-3.jpg" alt="jewelry"></img></a>
                                <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                            </div>
                            <div className="auction-content">
                                <h6 className="title">
                                    <a href="product-details.html">Gold Ring With Clear Stones</a>
                                </h6>
                                <div className="bid-area">
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-money"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Buy Now</div>
                                            <div className="amount">$5,00.00</div>
                                        </div>
                                    </div>
                                </div>
                                <div className="countdown-area">
                                    <div className="countdown">
                                        <div id="bid_counter25"></div>
                                    </div>
                                    <span className="total-bids">30 Bids</span>
                                </div>
                                <div className="text-center">
                                    <a href="#0" className="custom-button">Submit a bid</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        {/*============= Jewelry Auction Section Ends Here =============*/}
    
    
        {/*============= Call In Section Starts Here =============*/}
        <section className="call-in-section padding-top pt-max-xl-0">
            <div className="container">
                <div className="call-wrapper cl-white bg_img" data-background="assets/images/call-in/call-bg.png">
                    <div className="section-header">
                        <h3 className="title">Register for Free & Start Bidding Now!</h3>
                        <p>From cars to diamonds to iPhones, we have it all.</p>
                    </div>
                    <a href="sign-up.html" className="custom-button white">Register</a>
                </div>
            </div>
        </section>
        {/*============= Call In Section Ends Here =============*/}
    
    
        {/*============= Watches Auction Section Starts Here =============*/}
        <section className="watches-auction-section padding-bottom padding-top">
            <div className="container">
                <div className="section-header-3">
                    <div className="left">
                        <div className="thumb">
                            <img src="/assets/images/header-icons/coin-1.png" alt="header-icons"></img>
                        </div>
                        <div className="title-area">
                            <h2 className="title">Watches</h2>
                            <p>Shop for men & women designer brand watches</p>
                        </div>
                    </div>
                    <a href="#0" className="normal-button">View All</a>
                </div>
                <div className="row justify-content-center mb-30-none">
                    <div className="col-sm-10 col-md-6 col-lg-4">
                        <div className="auction-item-2">
                            <div className="auction-thumb">
                                <a href="product-details.html"><img src="/assets/images/auction/watches/auction-1.jpg" alt="watches"></img></a>
                                <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                            </div>
                            <div className="auction-content">
                                <h6 className="title">
                                    <a href="product-details.html">Vintage Rolex</a>
                                </h6>
                                <div className="bid-area">
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-money"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Buy Now</div>
                                            <div className="amount">$5,00.00</div>
                                        </div>
                                    </div>
                                </div>
                                <div className="countdown-area">
                                    <div className="countdown">
                                        <div id="bid_counter20"></div>
                                    </div>
                                    <span className="total-bids">30 Bids</span>
                                </div>
                                <div className="text-center">
                                    <a href="#0" className="custom-button">Submit a bid</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-sm-10 col-md-6 col-lg-4">
                        <div className="auction-item-2">
                            <div className="auction-thumb">
                                <a href="product-details.html"><img src="/assets/images/auction/watches/auction-2.jpg" alt="watches"></img></a>
                                <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                            </div>
                            <div className="auction-content">
                                <h6 className="title">
                                    <a href="product-details.html">Lady’s Vintage Rolex Datejust</a>
                                </h6>
                                <div className="bid-area">
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-money"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Buy Now</div>
                                            <div className="amount">$5,00.00</div>
                                        </div>
                                    </div>
                                </div>
                                <div className="countdown-area">
                                    <div className="countdown">
                                        <div id="bid_counter21"></div>
                                    </div>
                                    <span className="total-bids">30 Bids</span>
                                </div>
                                <div className="text-center">
                                    <a href="#0" className="custom-button">Submit a bid</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-sm-10 col-md-6 col-lg-4">
                        <div className="auction-item-2">
                            <div className="auction-thumb">
                                <a href="product-details.html"><img src="/assets/images/auction/watches/auction-3.jpg" alt="watches"></img></a>
                                <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                            </div>
                            <div className="auction-content">
                                <h6 className="title">
                                    <a href="product-details.html">Lady’s Retro Diamond</a>
                                </h6>
                                <div className="bid-area">
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-money"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Buy Now</div>
                                            <div className="amount">$5,00.00</div>
                                        </div>
                                    </div>
                                </div>
                                <div className="countdown-area">
                                    <div className="countdown">
                                        <div id="bid_counter22"></div>
                                    </div>
                                    <span className="total-bids">30 Bids</span>
                                </div>
                                <div className="text-center">
                                    <a href="#0" className="custom-button">Submit a bid</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        {/*============= Watches Auction Section Ends Here =============*/}
    
    
        {/*============= Popular Auction Section Starts Here =============*/}
        <section className="popular-auction padding-top pos-rel">
            <div className="popular-bg bg_img" data-background="assets/images/auction/popular/popular-bg.png"></div>
            <div className="container">
                <div className="section-header cl-white">
                    <span className="cate">Closing Within 24 Hours</span>
                    <h2 className="title">Popular Auctions</h2>
                    <p>Bid and win great deals,Our auction process is simple, efficient, and transparent.</p>
                </div>
                <div className="popular-auction-wrapper">
                    <div className="row justify-content-center mb-30-none">
                        <div className="col-lg-6">
                            <div className="auction-item-3">
                                <div className="auction-thumb">
                                    <a href="product-details.html"><img src="/assets/images/auction/popular/auction-1.jpg" alt="popular"></img></a>
                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                </div>
                                <div className="auction-content">
                                    <h6 className="title">
                                        <a href="product-details.html">Apple Macbook Pro Laptop</a>
                                    </h6>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bids-area">
                                        Total Bids : <span className="total-bids">130 Bids</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-lg-6">
                            <div className="auction-item-3">
                                <div className="auction-thumb">
                                    <a href="product-details.html"><img src="/assets/images/auction/popular/auction-2.jpg" alt="popular"></img></a>
                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                </div>
                                <div className="auction-content">
                                    <h6 className="title">
                                        <a href="product-details.html">Canon EOS Rebel T6I
                                            Digital Camera</a>
                                    </h6>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bids-area">
                                        Total Bids : <span className="total-bids">130 Bids</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-lg-6">
                            <div className="auction-item-3">
                                <div className="auction-thumb">
                                    <a href="product-details.html"><img src="/assets/images/auction/popular/auction-3.jpg" alt="popular"></img></a>
                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                </div>
                                <div className="auction-content">
                                    <h6 className="title">
                                        <a href="product-details.html">14k Gold Geneve Watch,
                                            24.5g</a>
                                    </h6>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bids-area">
                                        Total Bids : <span className="total-bids">130 Bids</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-lg-6">
                            <div className="auction-item-3">
                                <div className="auction-thumb">
                                    <a href="product-details.html"><img src="/assets/images/auction/popular/auction-4.jpg" alt="popular"></img></a>
                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                </div>
                                <div className="auction-content">
                                    <h6 className="title">
                                        <a href="product-details.html">14K White Gold 185.60
                                            Grams 5.95 Carats</a>
                                    </h6>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bids-area">
                                        Total Bids : <span className="total-bids">130 Bids</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-lg-6">
                            <div className="auction-item-3">
                                <div className="auction-thumb">
                                    <a href="product-details.html"><img src="/assets/images/auction/popular/auction-5.jpg" alt="popular"></img></a>
                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                </div>
                                <div className="auction-content">
                                    <h6 className="title">
                                        <a href="product-details.html">2009 Toyota Prius
                                            (Medford, NY 11763)</a>
                                    </h6>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bids-area">
                                        Total Bids : <span className="total-bids">130 Bids</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-lg-6">
                            <div className="auction-item-3">
                                <div className="auction-thumb">
                                    <a href="product-details.html"><img src="/assets/images/auction/popular/auction-6.jpg" alt="popular"></img></a>
                                    <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                </div>
                                <div className="auction-content">
                                    <h6 className="title">
                                        <a href="product-details.html">.6 Gram Pure Gold
                                            Nugget</a>
                                    </h6>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bids-area">
                                        Total Bids : <span className="total-bids">130 Bids</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        {/*============= Popular Auction Section Ends Here =============*/}
    
    
        {/*============= Coins and Bullion Auction Section Starts Here =============*/}
        <section className="coins-and-bullion-auction-section padding-bottom padding-top pos-rel pb-max-xl-0">
            <div className="jewelry-bg d-none d-xl-block"><img src="/assets/images/auction/coins/coin-bg.png" alt="coin"></img></div>
            <div className="container">
                <div className="section-header-3">
                    <div className="left">
                        <div className="thumb">
                            <img src="/assets/images/header-icons/coin-1.png" alt="header-icons"></img>
                        </div>
                        <div className="title-area">
                            <h2 className="title">Coins & Bullion</h2>
                            <p>Discover rare, foreign, & ancient coins that are worth collecting</p>
                        </div>
                    </div>
                    <a href="#0" className="normal-button">View All</a>
                </div>
                <div className="row justify-content-center mb-30-none">
                    <div className="col-sm-10 col-md-6 col-lg-4">
                        <div className="auction-item-2">
                            <div className="auction-thumb">
                                <a href="product-details.html"><img src="/assets/images/auction/coins/auction-1.jpg" alt="coins"></img></a>
                                <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                            </div>
                            <div className="auction-content">
                                <h6 className="title">
                                    <a href="product-details.html">Ancient & World Coins</a>
                                </h6>
                                <div className="bid-area">
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-money"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Buy Now</div>
                                            <div className="amount">$5,00.00</div>
                                        </div>
                                    </div>
                                </div>
                                <div className="countdown-area">
                                    <div className="countdown">
                                        <div id="bid_counter17"></div>
                                    </div>
                                    <span className="total-bids">30 Bids</span>
                                </div>
                                <div className="text-center">
                                    <a href="#0" className="custom-button">Submit a bid</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-sm-10 col-md-6 col-lg-4">
                        <div className="auction-item-2">
                            <div className="auction-thumb">
                                <a href="product-details.html"><img src="/assets/images/auction/coins/auction-2.jpg" alt="coins"></img></a>
                                <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                            </div>
                            <div className="auction-content">
                                <h6 className="title">
                                    <a href="product-details.html">2018 Hyundai Sonata</a>
                                </h6>
                                <div className="bid-area">
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-money"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Buy Now</div>
                                            <div className="amount">$5,00.00</div>
                                        </div>
                                    </div>
                                </div>
                                <div className="countdown-area">
                                    <div className="countdown">
                                        <div id="bid_counter18"></div>
                                    </div>
                                    <span className="total-bids">30 Bids</span>
                                </div>
                                <div className="text-center">
                                    <a href="#0" className="custom-button">Submit a bid</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-sm-10 col-md-6 col-lg-4">
                        <div className="auction-item-2">
                            <div className="auction-thumb">
                                <a href="product-details.html"><img src="/assets/images/auction/coins/auction-3.jpg" alt="coins"></img></a>
                                <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                            </div>
                            <div className="auction-content">
                                <h6 className="title">
                                    <a href="product-details.html">2018 Hyundai Sonata</a>
                                </h6>
                                <div className="bid-area">
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-auction"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Current Bid</div>
                                            <div className="amount">$876.00</div>
                                        </div>
                                    </div>
                                    <div className="bid-amount">
                                        <div className="icon">
                                            <i className="flaticon-money"></i>
                                        </div>
                                        <div className="amount-content">
                                            <div className="current">Buy Now</div>
                                            <div className="amount">$5,00.00</div>
                                        </div>
                                    </div>
                                </div>
                                <div className="countdown-area">
                                    <div className="countdown">
                                        <div id="bid_counter19"></div>
                                    </div>
                                    <span className="total-bids">30 Bids</span>
                                </div>
                                <div className="text-center">
                                    <a href="#0" className="custom-button">Submit a bid</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        {/*============= Coins and Bullion Auction Section Ends Here =============*/}
    
    
        {/*============= Real Estate Section Starts Here =============*/}
        <section className="real-estate-auction padding-top padding-bottom pos-rel oh">
            <div className="car-bg"><img src="/assets/images/auction/realstate/real-bg.png" alt="realstate"></img></div>
            <div className="container">
                <div className="section-header-3">
                    <div className="left">
                        <div className="thumb">
                            <img src="/assets/images/header-icons/coin-1.png" alt="header-icons"></img>
                        </div>
                        <div className="title-area">
                            <h2 className="title">Real Estate</h2>
                            <p>Find auctions for Homes, Condos, Residential & Commercial Properties.</p>
                        </div>
                    </div>
                    <a href="#0" className="normal-button">View All</a>
                </div>
                <div className="auction-slider-4 owl-theme owl-carousel">
                    <div className="auction-item-4">
                        <div className="auction-thumb">
                            <a href="product-details.html"><img src="/assets/images/auction/realstate/auction-1.png" alt="realstate"></img></a>
                            <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                        </div>
                        <div className="auction-content">
                            <h4 className="title">
                                <a href="product-details.html">Brand New Apartments In Esenyurt, Istanbul</a>
                            </h4>
                            <div className="bid-area">
                                <div className="bid-amount">
                                    <div className="icon">
                                        <i className="flaticon-auction"></i>
                                    </div>
                                    <div className="amount-content">
                                        <div className="current">Current Bid</div>
                                        <div className="amount">$876.00</div>
                                    </div>
                                </div>
                                <div className="bid-amount">
                                    <div className="icon">
                                        <i className="flaticon-money"></i>
                                    </div>
                                    <div className="amount-content">
                                        <div className="current">Buy Now</div>
                                        <div className="amount">$5,00.00</div>
                                    </div>
                                </div>
                            </div>
                            <div className="countdown-area">
                                <div className="countdown">
                                    <div id="bid_counter30"></div>
                                </div>
                                <span className="total-bids">30 Bids</span>
                            </div>
                            <div className="text-center">
                                <a href="#0" className="custom-button">Submit a bid</a>
                            </div>
                        </div>
                    </div>
                    <div className="auction-item-4">
                        <div className="auction-thumb">
                            <a href="product-details.html"><img src="/assets/images/auction/realstate/auction-1.png" alt="realstate"></img></a>
                            <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                        </div>
                        <div className="auction-content">
                            <h4 className="title">
                                <a href="product-details.html">Brand New Apartments In Esenyurt, Istanbul</a>
                            </h4>
                            <div className="bid-area">
                                <div className="bid-amount">
                                    <div className="icon">
                                        <i className="flaticon-auction"></i>
                                    </div>
                                    <div className="amount-content">
                                        <div className="current">Current Bid</div>
                                        <div className="amount">$876.00</div>
                                    </div>
                                </div>
                                <div className="bid-amount">
                                    <div className="icon">
                                        <i className="flaticon-money"></i>
                                    </div>
                                    <div className="amount-content">
                                        <div className="current">Buy Now</div>
                                        <div className="amount">$5,00.00</div>
                                    </div>
                                </div>
                            </div>
                            <div className="countdown-area">
                                <div className="countdown">
                                    <div id="bid_counter31"></div>
                                </div>
                                <span className="total-bids">30 Bids</span>
                            </div>
                            <div className="text-center">
                                <a href="#0" className="custom-button">Submit a bid</a>
                            </div>
                        </div>
                    </div>
                    <div className="auction-item-4">
                        <div className="auction-thumb">
                            <a href="product-details.html"><img src="/assets/images/auction/realstate/auction-1.png" alt="realstate"></img></a>
                            <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                        </div>
                        <div className="auction-content">
                            <h4 className="title">
                                <a href="product-details.html">Brand New Apartments In Esenyurt, Istanbul</a>
                            </h4>
                            <div className="bid-area">
                                <div className="bid-amount">
                                    <div className="icon">
                                        <i className="flaticon-auction"></i>
                                    </div>
                                    <div className="amount-content">
                                        <div className="current">Current Bid</div>
                                        <div className="amount">$876.00</div>
                                    </div>
                                </div>
                                <div className="bid-amount">
                                    <div className="icon">
                                        <i className="flaticon-money"></i>
                                    </div>
                                    <div className="amount-content">
                                        <div className="current">Buy Now</div>
                                        <div className="amount">$5,00.00</div>
                                    </div>
                                </div>
                            </div>
                            <div className="countdown-area">
                                <div className="countdown">
                                    <div id="bid_counter32"></div>
                                </div>
                                <span className="total-bids">30 Bids</span>
                            </div>
                            <div className="text-center">
                                <a href="#0" className="custom-button">Submit a bid</a>
                            </div>
                        </div>
                    </div>
                    <div className="auction-item-4">
                        <div className="auction-thumb">
                            <a href="product-details.html"><img src="/assets/images/auction/realstate/auction-1.png" alt="realstate"></img></a>
                            <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                        </div>
                        <div className="auction-content">
                            <h4 className="title">
                                <a href="product-details.html">Brand New Apartments In Esenyurt, Istanbul</a>
                            </h4>
                            <div className="bid-area">
                                <div className="bid-amount">
                                    <div className="icon">
                                        <i className="flaticon-auction"></i>
                                    </div>
                                    <div className="amount-content">
                                        <div className="current">Current Bid</div>
                                        <div className="amount">$876.00</div>
                                    </div>
                                </div>
                                <div className="bid-amount">
                                    <div className="icon">
                                        <i className="flaticon-money"></i>
                                    </div>
                                    <div className="amount-content">
                                        <div className="current">Buy Now</div>
                                        <div className="amount">$5,00.00</div>
                                    </div>
                                </div>
                            </div>
                            <div className="countdown-area">
                                <div className="countdown">
                                    <div id="bid_counter33"></div>
                                </div>
                                <span className="total-bids">30 Bids</span>
                            </div>
                            <div className="text-center">
                                <a href="#0" className="custom-button">Submit a bid</a>
                            </div>
                        </div>
                    </div>
                    <div className="auction-item-4">
                        <div className="auction-thumb">
                            <a href="product-details.html"><img src="/assets/images/auction/realstate/auction-1.png" alt="realstate"></img></a>
                            <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                        </div>
                        <div className="auction-content">
                            <h4 className="title">
                                <a href="product-details.html">Brand New Apartments In Esenyurt, Istanbul</a>
                            </h4>
                            <div className="bid-area">
                                <div className="bid-amount">
                                    <div className="icon">
                                        <i className="flaticon-auction"></i>
                                    </div>
                                    <div className="amount-content">
                                        <div className="current">Current Bid</div>
                                        <div className="amount">$876.00</div>
                                    </div>
                                </div>
                                <div className="bid-amount">
                                    <div className="icon">
                                        <i className="flaticon-money"></i>
                                    </div>
                                    <div className="amount-content">
                                        <div className="current">Buy Now</div>
                                        <div className="amount">$5,00.00</div>
                                    </div>
                                </div>
                            </div>
                            <div className="countdown-area">
                                <div className="countdown">
                                    <div id="bid_counter34"></div>
                                </div>
                                <span className="total-bids">30 Bids</span>
                            </div>
                            <div className="text-center">
                                <a href="#0" className="custom-button">Submit a bid</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="slider-nav real-style ml-auto">
                    <a href="#0" className="real-prev"><i className="flaticon-left-arrow"></i></a>
                    <div className="pagination"></div>
                    <a href="#0" className="real-next active"><i className="flaticon-right-arrow"></i></a>
                </div>
            </div>
        </section>
        {/*============= Real Estate Section Starts Here =============*/}
    
    
        {/*============= Art Auction Section Starts Here =============*/}
        <section className="art-and-electronics-auction-section padding-top">
            <div className="container">
                <div className="row justify-content-center mb--50">
                    <div className="col-xl-6 col-lg-8 mb-50">
                        <div className="section-header-2">
                            <div className="left">
                                <div className="thumb">
                                    <img src="/assets/images/header-icons/camera-1.png" alt="header-icons"></img>
                                </div>
                                <h2 className="title">Electronics</h2>
                            </div>
                            <div className="slider-nav">
                                <a href="#0" className="electro-prev"><i className="flaticon-left-arrow"></i></a>
                                <a href="#0" className="electro-next active"><i className="flaticon-right-arrow"></i></a>
                            </div>
                        </div>
                        <div className="auction-slider-1 owl-carousel owl-theme  mb-30-none">
                            <div className="slide-item">
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/electronics/auction-1.jpg" alt="electronics"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">Magnifying Glasses, Jewelry Loupe odit qui corporis</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter1"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/electronics/auction-2.jpg" alt="electronics"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">Surveillance WiFi Exterieur, 1080P Camera</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter2"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/electronics/auction-3.jpg" alt="electronics"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">WiFi Doorbell Camera for Apartments</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter3"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/electronics/auction-4.jpg" alt="electronics"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">GPD Pocket 2 Ultrabook 7" inch</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter4"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="slide-item">
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/electronics/auction-1.jpg" alt="electronics"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">Magnifying Glasses, Jewelry Loupe odit qui corporis</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter5"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/electronics/auction-2.jpg" alt="electronics"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">Surveillance WiFi Exterieur, 1080P Camera</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter6"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/electronics/auction-3.jpg" alt="electronics"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">WiFi Doorbell Camera for Apartments</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter7"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/electronics/auction-4.jpg" alt="electronics"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">GPD Pocket 2 Ultrabook 7" inch</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter8"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-xl-6 col-lg-8 mb-50">
                        <div className="section-header-2">
                            <div className="left">
                                <div className="thumb">
                                    <img src="/assets/images/header-icons/art-1.png" alt="header-icons"></img>
                                </div>
                                <h2 className="title">Art</h2>
                            </div>
                            <div className="slider-nav">
                                <a href="#0" className="art-prev"><i className="flaticon-left-arrow"></i></a>
                                <a href="#0" className="art-next active"><i className="flaticon-right-arrow"></i></a>
                            </div>
                        </div>
                        <div className="auction-slider-2 owl-carousel owl-theme mb-30-none">
                            <div className="slide-item">
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/art/auction-1.jpg" alt="art"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">Magnifying Glasses, Jewelry Loupe odit qui corporis</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter9"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/art/auction-2.jpg" alt="art"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">Surveillance WiFi Exterieur, 1080P Camera</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter10"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/art/auction-3.jpg" alt="art"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">WiFi Doorbell Camera for Apartments</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter11"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/art/auction-4.jpg" alt="art"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">GPD Pocket 2 Ultrabook 7" inch</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter12"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="slide-item">
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/art/auction-1.jpg" alt="art"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">Magnifying Glasses, Jewelry Loupe odit qui corporis</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter13"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/art/auction-2.jpg" alt="art"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">Surveillance WiFi Exterieur, 1080P Camera</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter14"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/art/auction-3.jpg" alt="art"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">WiFi Doorbell Camera for Apartments</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter15"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                                <div className="auction-item-1">
                                    <div className="auction-thumb">
                                        <a href="product-details.html"><img src="/assets/images/auction/art/auction-4.jpg" alt="art"></img></a>
                                        <a href="#0" className="rating"><i className="far fa-star"></i></a>
                                        <a href="#0" className="bid"><i className="flaticon-auction"></i></a>
                                    </div>
                                    <div className="auction-content">
                                        <h6 className="title">
                                            <a href="product-details.html">GPD Pocket 2 Ultrabook 7" inch</a>
                                        </h6>
                                        <div className="bid-amount">
                                            <div className="icon">
                                                <i className="flaticon-auction"></i>
                                            </div>
                                            <div className="amount-content">
                                                <div className="current">Current Bid</div>
                                                <div className="amount">$876.00</div>
                                            </div>
                                        </div>
                                        <div className="countdown-area">
                                            <div className="countdown">
                                                <div id="bid_counter16"></div>
                                            </div>
                                            <span className="total-bids">30 Bids</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        {/*============= Art Auction Section Ends Here =============*/}
    
    
        {/*============= How Section Starts Here =============*/}
        <section className="how-section padding-top">
            <div className="container">
                <div className="how-wrapper section-bg">
                    <div className="section-header text-lg-left">
                        <h2 className="title">How it works</h2>
                        <p>Easy 3 steps to win</p>
                    </div>
                    <div className="row justify-content-center mb--40">
                        <div className="col-md-6 col-lg-4">
                            <div className="how-item">
                                <div className="how-thumb">
                                    <img src="/assets/images/how/how1.png" alt="how"></img>
                                </div>
                                <div className="how-content">
                                    <h4 className="title">Sign Up</h4>
                                    <p>No Credit Card Required</p>
                                </div>
                            </div>
                        </div>
                        <div className="col-md-6 col-lg-4">
                            <div className="how-item">
                                <div className="how-thumb">
                                    <img src="/assets/images/how/how2.png" alt="how"></img>
                                </div>
                                <div className="how-content">
                                    <h4 className="title">Bid</h4>
                                    <p>Bidding is free Only pay if you win</p>
                                </div>
                            </div>
                        </div>
                        <div className="col-md-6 col-lg-4">
                            <div className="how-item">
                                <div className="how-thumb">
                                    <img src="/assets/images/how/how3.png" alt="how"></img>
                                </div>
                                <div className="how-content">
                                    <h4 className="title">Win</h4>
                                    <p>Fun - Excitement - Great deals</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        {/*============= How Section Ends Here =============*/}
    
    
        {/*============= Client Section Starts Here =============*/}
        <section className="client-section padding-top padding-bottom">
            <div className="container">
                <div className="section-header">
                    <h2 className="title">Don’t just take our word for it!</h2>
                    <p>Our hard work is paying off. Great reviews from amazing customers.</p>
                </div>
                <div className="m--15">
                    <div className="client-slider owl-theme owl-carousel">
                        <div className="client-item">
                            <div className="client-content">
                                <p>I can't stop bidding! It's a great way to spend some time and I want everything on Sbidu.</p>
                            </div>
                            <div className="client-author">
                                <div className="thumb">
                                    <a href="#0">
                                        <img src="/assets/images/client/client01.png" alt="client"></img>
                                    </a>
                                </div>
                                <div className="content">
                                    <h6 className="title"><a href="#0">Alexis Moore</a></h6>
                                    <div className="ratings">
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="client-item">
                            <div className="client-content">
                                <p>I came I saw I won. Love what I have won, and will try to win something else.</p>
                            </div>
                            <div className="client-author">
                                <div className="thumb">
                                    <a href="#0">
                                        <img src="/assets/images/client/client02.png" alt="client"></img>
                                    </a>
                                </div>
                                <div className="content">
                                    <h6 className="title"><a href="#0">Darin Griffin</a></h6>
                                    <div className="ratings">
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="client-item">
                            <div className="client-content">
                                <p>This was my first time, but it was exciting. I will try it again. Thank you so much.</p>
                            </div>
                            <div className="client-author">
                                <div className="thumb">
                                    <a href="#0">
                                        <img src="/assets/images/client/client03.png" alt="client"></img>
                                    </a>
                                </div>
                                <div className="content">
                                    <h6 className="title"><a href="#0">Tom Powell</a></h6>
                                    <div className="ratings">
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                        <span><i className="fas fa-star"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        {/*============= Client Section Ends Here =============*/}
    
    
        {/*============= Footer Section Starts Here =============*/}
        <footer className="bg_img padding-top oh" data-background="assets/images/footer/footer-bg.jpg">
            <div className="footer-top-shape">
                <img src="/assets/css/img/footer-top-shape.png" alt="css"></img>
            </div>
            <div className="anime-wrapper">
                <div className="anime-1 plus-anime">
                    <img src="/assets/images/footer/p1.png" alt="footer"></img>
                </div>
                <div className="anime-2 plus-anime">
                    <img src="/assets/images/footer/p2.png" alt="footer"></img>
                </div>
                <div className="anime-3 plus-anime">
                    <img src="/assets/images/footer/p3.png" alt="footer"></img>
                </div>
                <div className="anime-5 zigzag">
                    <img src="/assets/images/footer/c2.png" alt="footer"></img>
                </div>
                <div className="anime-6 zigzag">
                    <img src="/assets/images/footer/c3.png" alt="footer"></img>
                </div>
                <div className="anime-7 zigzag">
                    <img src="/assets/images/footer/c4.png" alt="footer"></img>
                </div>
            </div>
            <div className="newslater-wrapper">
                <div className="container">
                    <div className="newslater-area">
                        <div className="newslater-thumb">
                            <img src="/assets/images/footer/newslater.png" alt="footer"></img>
                        </div>
                        <div className="newslater-content">
                            <div className="section-header left-style mb-low">
                                <h5 className="cate">Subscribe to Sbidu</h5>
                                <h3 className="title">To Get Exclusive Benefits</h3>
                            </div>
                            <form className="subscribe-form">
                                <input type="text" placeholder="Enter Your Email" name="email"></input>
                                <button type="submit" className="custom-button">Subscribe</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <div className="footer-top padding-bottom padding-top">
                <div className="container">
                    <div className="row mb--60">
                        <div className="col-sm-6 col-lg-3">
                            <div className="footer-widget widget-links">
                                <h5 className="title">Auction Categories</h5>
                                <ul className="links-list">
                                    <li>
                                        <a href="#0">Ending Now</a>
                                    </li>
                                    <li>
                                        <a href="#0">Vehicles</a>
                                    </li>
                                    <li>
                                        <a href="#0">Watches</a>
                                    </li>
                                    <li>
                                        <a href="#0">Electronics</a>
                                    </li>
                                    <li>
                                        <a href="#0">Real Estate</a>
                                    </li>
                                    <li>
                                        <a href="#0">Jewelry</a>
                                    </li>
                                    <li>
                                        <a href="#0">Art</a>
                                    </li>
                                    <li>
                                        <a href="#0">Sports & Outdoor</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div className="col-sm-6 col-lg-3">
                            <div className="footer-widget widget-links">
                                <h5 className="title">About Us</h5>
                                <ul className="links-list">
                                    <li>
                                        <a href="#0">About Sbidu</a>
                                    </li>
                                    <li>
                                        <a href="#0">Help</a>
                                    </li>
                                    <li>
                                        <a href="#0">Affiliates</a>
                                    </li>
                                    <li>
                                        <a href="#0">Jobs</a>
                                    </li>
                                    <li>
                                        <a href="#0">Press</a>
                                    </li>
                                    <li>
                                        <a href="#0">Our blog</a>
                                    </li>
                                    <li>
                                        <a href="#0">Collectors' portal</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div className="col-sm-6 col-lg-3">
                            <div className="footer-widget widget-links">
                                <h5 className="title">We're Here to Help</h5>
                                <ul className="links-list">
                                    <li>
                                        <a href="#0">Your Account</a>
                                    </li>
                                    <li>
                                        <a href="#0">Safe and Secure</a>
                                    </li>
                                    <li>
                                        <a href="#0">Shipping Information</a>
                                    </li>
                                    <li>
                                        <a href="#0">Contact Us</a>
                                    </li>
                                    <li>
                                        <a href="#0">Help & FAQ</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div className="col-sm-6 col-lg-3">
                            <div className="footer-widget widget-follow">
                                <h5 className="title">Follow Us</h5>
                                <ul className="links-list">
                                    <li>
                                        <a href="#0"><i className="fas fa-phone-alt"></i>(646) 663-4575</a>
                                    </li>
                                    <li>
                                        <a href="#0"><i className="fas fa-blender-phone"></i>(646) 968-0608</a>
                                    </li>
                                    <li>
                                        <a href="#0"><i className="fas fa-envelope-open-text"></i><span className="__cf_email__" data-cfemail="aec6cbc2deeecbc0c9c1dac6cbc3cb80cdc1c3">[email&#160;protected]</span></a>
                                    </li>
                                    <li>
                                        <a href="#0"><i className="fas fa-location-arrow"></i>1201 Broadway Suite</a>
                                    </li>
                                </ul>
                                <ul className="social-icons">
                                    <li>
                                        <a href="#0" className="active"><i className="fab fa-facebook-f"></i></a>
                                    </li>
                                    <li>
                                        <a href="#0"><i className="fab fa-twitter"></i></a>
                                    </li>
                                    <li>
                                        <a href="#0"><i className="fab fa-instagram"></i></a>
                                    </li>
                                    <li>
                                        <a href="#0"><i className="fab fa-linkedin-in"></i></a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="footer-bottom">
                <div className="container">
                    <div className="copyright-area">
                        <div className="footer-bottom-wrapper">
                            <div className="logo">
                                <a href="index.html"><img src="/assets/images/logo/footer-logo.png" alt="logo"></img></a>
                            </div>
                            <ul className="gateway-area">
                                <li>
                                    <a href="#0"><img src="/assets/images/footer/paypal.png" alt="footer"></img></a>
                                </li>
                                <li>
                                    <a href="#0"><img src="/assets/images/footer/visa.png" alt="footer"></img></a>
                                </li>
                                <li>
                                    <a href="#0"><img src="/assets/images/footer/discover.png" alt="footer"></img></a>
                                </li>
                                <li>
                                    <a href="#0"><img src="/assets/images/footer/mastercard.png" alt="footer"></img></a>
                                </li>
                            </ul>
                            <div className="copyright"><p>&copy; Copyright 2021 | <a href="#0">Sbidu</a> By <a href="#0">Uiaxis</a></p></div>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
        {/*============= Footer Section Ends Here =============*/}
    
    
    
        <script data-cfasync="false" src="../../cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js"></script><script src="assets/js/jquery-3.3.1.min.js"></script>
        <script src="assets/js/modernizr-3.6.0.min.js"></script>
        <script src="assets/js/plugins.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
        <script src="assets/js/isotope.pkgd.min.js"></script>
        <script src="assets/js/wow.min.js"></script>
        <script src="assets/js/waypoints.js"></script>
        <script src="assets/js/nice-select.js"></script>
        <script src="assets/js/counterup.min.js"></script>
        <script src="assets/js/owl.min.js"></script>
        <script src="assets/js/magnific-popup.min.js"></script>
        <script src="assets/js/yscountdown.min.js"></script>
        <script src="assets/js/jquery-ui.min.js"></script>
        <script src="assets/js/main.js"></script>
    </div>
  );
}

export default App;
