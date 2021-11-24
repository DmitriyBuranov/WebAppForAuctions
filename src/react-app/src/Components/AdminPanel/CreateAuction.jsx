import React, { useState } from 'react';
import { Button, Form, Container, Row, Col } from 'react-bootstrap';
import { auctionService } from '../../Services/auctionsService';
import { selectLogged, selectJWT } from '../../features/userSlice'
import { useSelector } from 'react-redux';
import { Redirect } from "react-router-dom";
import { useHistory } from "react-router-dom";


function CreateAuction() {
    const logged = useSelector(selectLogged);
    const token = useSelector(selectJWT);
    const history = useHistory();

    const [auctionParameters, setParameters] = useState({
        name: "",
        endDate: "",
        startPrice: 0,
        sellPrice: 0,
        priceStep: 0,
        startDate: "",
        description: ""
    });

    if (logged !== true)
        return <Redirect to="/login" />

    function handleChanges(e) {
        //console.log("changes");
        const { name, value } = e.target;
        setParameters(auctionParameters => ({ ...auctionParameters, [name]: value }));
        e.preventDefault();
        //console.log(auctionParameters);
    };

    function createAuction(e) {
        handleChanges(e);
        //console.log('Starting request to server');

        auctionService.postCreateAuction(auctionParameters, token)
            .then(data => {                
                history.push(`/products/${data}`);
            });
        e.target.reset();
    };

    return (
        <Container >
            <Form className="mt-3" onSubmit={createAuction} onChange={handleChanges}>
                <Row>
                    <Form.Group as={Col}>
                        <Form.Label className="cl-black mt-3">Name</Form.Label>
                        <Form.Control
                            type="text"
                            name="name" />
                        <Form.Label className="cl-black mt-3">Description</Form.Label>
                        <Form.Control
                            type="text"
                            name="description" />
                        <Form.Label className="cl-black mt-3">Start date</Form.Label>
                        <Form.Control
                            type="datetime-local"
                            name="startDate" />
                        <Form.Label className="cl-black mt-3">End date</Form.Label>
                        <Form.Control
                            type="datetime-local"
                            name="endDate" />
                    </Form.Group>
                    <Form.Group as={Col}>
                        <Form.Label className="cl-black mt-3">Start Price</Form.Label>
                        <Form.Control
                            type="number"
                            name="startPrice"
                            step=".01" />
                        <Form.Label className="cl-black mt-3">Sell Price</Form.Label>
                        <Form.Control
                            type="number"
                            name="sellPrice"
                            step=".01" />
                        <Form.Label className="cl-black mt-3">Price Step</Form.Label>
                        <Form.Control
                            type="number"
                            name="priceStep"
                            step=".01" />
                    </Form.Group>
                </Row>
                <Button className="mt-3" type="submit" >Create</Button>
            </Form>
        </Container>
    );

}

export default CreateAuction;