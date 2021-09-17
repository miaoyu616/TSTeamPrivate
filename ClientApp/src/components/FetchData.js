import React, { Component } from 'react';
import { Container, Row, Col, Button, Input, FormGroup, Label, Jumbotron } from 'reactstrap';
import "../css/FetchData.css";


export class FetchData extends Component {
  constructor(props) {
    super(props);
    this.state = {
      heroList: [],
      loading: true,
      selectedHero: '',
      info: undefined,
      infoLoaded: false
    }
    this.handleHeroChange = this.handleHeroChange.bind(this);
    this.updateInfo = this.updateInfo.bind(this);
  }

  componentDidMount() {
    this.getHeros();
  }

  render() {
    let nameList = this.state.loading
      ? <p><em>Loading Hero List...</em></p>
      : this.renderHeroSelectList(this.state.heroList);

    let heroInfo = this.state.infoLoaded
      ? this.renderHeroInfo(this.state.info)
      : undefined;

    return (
      <div>
        <h1>
          Get hero info
        </h1>
        {nameList}
        {heroInfo}
      </div>
    );
  }

  renderHeroSelectList(heroList) {
    return (
      <Container>
        <FormGroup>

          <Label for="heroSelector">Select your hero</Label>
          <Row>
            <Col xs="10">
              <Input type="select" name="select" id="heroSelector" value={this.state.selectedHero} onChange={this.handleHeroChange}>
                {heroList.map((heroName) =>
                  <option key={heroName}>{heroName}</option>
                )}
              </Input>
            </Col>
            <Col xs="2">
              <Button outline color="primary" id="digIn" onClick={this.updateInfo}>Dig In</Button>
            </Col>
          </Row>
        </FormGroup>
      </Container>
    )
  }

  renderHeroInfo(heroInfo) {
    return (
      <div>
        <Jumbotron fluid>
          <Container fluid className='info'>
            <img className='img-fluid' src={heroInfo.ProfilePic}/>
            <h3>{heroInfo.Name}</h3>
            <h4>{heroInfo.Species}</h4>
            <h4>{heroInfo.Gender}</h4>
            <p>{heroInfo.Intro}</p>
          </Container>
        </Jumbotron>
      </div>
    )
  }
  handleHeroChange(event) {
    this.setState({ selectedHero: event.target.value });
  }

  async getHeros() {
    fetch('test/getHeros')
      .then(res => res.json()).then(data => {
        this.setState({ heroList: data });
        this.setState({ selectedHero: data[0] });
        this.setState({ loading: false });

      })
  }
  async updateInfo() {
    fetch('test/getInfo', {
      method: "post",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        Name: this.state.selectedHero
      })
    }).then(res => res.json()).then(data => {
      this.setState({ info: data })
      this.setState({infoLoaded: true})
    })
  }
}
