import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import {Navbar,Nav, NavItem, MenuItem,NavDropdown} from 'react-bootstrap';
class UserOnly extends Component {
  static contextTypes = {
  }

  componentWillMount() {
    this.guestWillTransfer(this.props, this.context.router);
  }

  componentWillUpdate(nextProps) {
    this.guestWillTransfer(nextProps, this.context.router);
  }

  guestWillTransfer(props, router) {
    if (!props.auth.isLoggedin) {
      router.replace('/login');
    }
  }

  render() {
    return 
    <div>
      <Navbar>
        <Navbar.Header>
          <Navbar.Brand>
            <a href="#home">React-Bootstrap</a>
          </Navbar.Brand>
        </Navbar.Header>
        <Nav>
          <NavItem eventKey={1} href="#">
      Link
        </NavItem>
          <NavItem eventKey={2} href="#">
      Link
        </NavItem>
          <NavDropdown eventKey={3} title="Dropdown" id="basic-nav-dropdown">
            <MenuItem eventKey={3.1}>Action</MenuItem>
            <MenuItem eventKey={3.2}>Another action</MenuItem>
            <MenuItem eventKey={3.3}>Something else here</MenuItem>
            <MenuItem divider />
            <MenuItem eventKey={3.4}>Separated link</MenuItem>
          </NavDropdown>
        </Nav>
      </Navbar>
    {this.props.children}</div>;
  }
}

const mapStateToProps = ({auth}) =>({
   auth: auth 
})
export default connect(
    mapStateToProps
)(UserOnly);