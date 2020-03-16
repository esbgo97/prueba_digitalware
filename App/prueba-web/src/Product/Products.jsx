import React, { Component } from 'react'
import Container from 'react-bootstrap/Container'
import Alert from 'react-bootstrap/Alert'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Form from 'react-bootstrap/Form'
import Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import http from '../utils/httpClient'

class Products extends Component {
    constructor(props) {
        super(props);
        this.state = {
            alert: {
                show: false,
                type: "info",
                text: ""
            },
            products: []
        }
    }

    componentDidMount() {
        http.get("Product/GetProducts")
            .then((resp) => {
                this.setState({
                    ...this.state,
                    products: resp.data
                })
            })
            .catch(this.showAlert)
    }
    showAlert(text) {
        this.setState({
            ...this.state,
            alert: { show: true, text, type:"danger" }
        });
    }
    handleSubmit(ev) {
        ev.preventDefault();
        // debugger
        let fields = ev.target.elements;
        let data = { Id: 0 }
        for (let i in fields) {
            data[fields[i].name] = fields[i].value;
        }
        http.post("Product/SaveProduct", data)
            .then((resp) => {
                this.setState({
                    ...this.state,
                    alert: { show: true, text: "Se guardo el producto correctamente!", type: "success" }
                })
            })
            .catch((e)=>this.showAlert)
    }
    render() {
        return (<Container fluid>
            <Row>
                <Col>
                    <Card style={{ width: '50rem' }}>
                        <Card.Body>
                            <Card.Title> Productos</Card.Title>

                            <Form onSubmit={this.handleSubmit}>
                                <Form.Control name="Code" placeholder="Codigo" type="text" />
                                <br />
                                <Form.Control name="Name" placeholder="Nombre" type="text" />
                                <br />
                                <Form.Control name="Description" placeholder="Descripcion" type="text" />
                                <br />
                                <Form.Control name="Units" placeholder="Unidades" type="number" />
                                <br />
                                <Form.Control name="Price" placeholder="Precio" type="number" step="0.01" />
                                <br />
                                <br />
                                <Button variant="primary" type="submit">Guardar</Button>
                                <br />
                            </Form>

                            <Alert show={this.state.alert.show} variant={this.state.alert.type}>
                                {this.state.alert.text.toString()}
                            </Alert>

                        </Card.Body>
                    </Card>
                </Col>

                <Col>
                    <Card style={{ width: '50rem' }}>
                        {this.state.products.map((item, k) => <li key={k}>{item.code} - {item.name}</li>)}
                    </Card>
                </Col>
            </Row>
        </Container>)
    }
}
export default Products