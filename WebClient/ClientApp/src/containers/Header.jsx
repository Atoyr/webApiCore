import React, { Component, PropTypes } from 'react';
import { Navbar, Nav, NavItem, Button ,MenuItem, NavDropdown} from 'react-bootstrap';
import { connect } from 'react-redux';
import {Link} from 'react-router-dom';
import { fetchLoginStateAsync, requestLogoutAsync } from '../actions/auth';
import { LinkContainer } from 'react-router-bootstrap';

const Header = ({requestLogoutAsync}) => {
    return (
        <Navbar inverse fixedTop>
            <Navbar.Header>
                <Navbar.Brand>
                    <Link to="/">My Apps</Link>
                </Navbar.Brand>
            </Navbar.Header>
            <Nav pullRight>
                <NavDropdown title="setting">
                    <MenuItem onClick={requestLogoutAsync}>
                    Logout
                    </MenuItem>
                </NavDropdown>
            </Nav>
        </Navbar>)
}

const mapStateToProps = ({auth}) =>({
   auth: auth 
})
function mapDispatchToProps(dispatch) {
    return {
        requestLogoutAsync : (value) => {
          console.log(value);
          dispatch(requestLogoutAsync());
        }
    }
}
export default connect(
    mapStateToProps,
    mapDispatchToProps
)
(Header)