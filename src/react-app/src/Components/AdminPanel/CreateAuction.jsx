import React, { useState } from 'react';
import { Button, Form, Container, Row, Col } from 'react-bootstrap';
import { auctionService } from '../../Services/auctionsService';
import { selectLogged,  selectJWT } from '../../features/userSlice'
import { useSelector } from 'react-redux';
import { Redirect } from "react-router-dom";

function CreateAuction() {

    const logged = useSelector(selectLogged);
    const token = useSelector(selectJWT);

    const [auctionParameters, setParameters] = useState({
        name: "",
        duration: 0,
        startPrice: 0,
        sellPrice: 0,
        priceStep: 0,
        startDate: ""
    });

    if (logged !== true)
        return <Redirect to="/login" />

    function handleChanges(e) {
        console.log("changes");
        const { name, value } = e.target;
        setParameters(auctionParameters => ({ ...auctionParameters, [name]: value }));
        e.preventDefault();
        console.log(auctionParameters);
    };

    function createAuction(e) {
        handleChanges(e);
        console.log('Starting request to server');

        auctionService.postCreateAuction(auctionParameters, token)
            .then(data => {
                console.log(data);
            });
    };


    return (
        <div>

            <div className="hero-section style-2">
                <div className="container">
                    <ul className="breadcrumb">
                        <li>
                            <a href="/home">Home</a>
                        </li>
                        <li>
                            <span>createAuction</span>
                        </li>
                    </ul>
                </div>
                <Container >
                    <Form className="mt-3" onSubmit={createAuction} onChange={handleChanges}>
                        <Row>
                            <Form.Group as={Col}>
                                <Form.Label className="cl-white mt-3">Name</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="name" />
                                <Form.Label className="cl-white mt-3">Start date</Form.Label>
                                <Form.Control
                                    type="datetime-local"
                                    name="startDate" />
                                <Form.Label className="cl-white mt-3">Duration</Form.Label>
                                <Form.Control
                                    type="number"
                                    name="duration" />
                            </Form.Group>
                            <Form.Group as={Col}>
                                <Form.Label className="cl-white mt-3">Start Price</Form.Label>
                                <Form.Control
                                    type="number"
                                    name="startPrice"
                                    step=".01" />
                                <Form.Label className="cl-white mt-3">Sell Price</Form.Label>
                                <Form.Control
                                    type="number" s
                                    name="sellPrice"
                                    step=".01" />
                                <Form.Label className="cl-white mt-3">Price Step</Form.Label>
                                <Form.Control
                                    type="number"
                                    name="priceStep"
                                    step=".01" />
                            </Form.Group>
                        </Row>
                        <Button className="mt-3" type="submit" >Create</Button>
                    </Form>
                </Container>
                <div className="bg_img hero-bg bottom_center" style={{ backgroundImage: "url('/assets/images/banner/banner-bg-4.png')" }}></div>
            </div>


        </div>
    );

}

export default CreateAuction;