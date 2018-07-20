import React, { Component, PropTypes } from 'react';
import { Navbar, Nav, NavItem, Button } from 'react-bootstrap';
import { connect } from 'react-redux';
import {Link} from 'react-router-dom';
import { fetchLoginStateAsync, requestLogoutAsync } from '../actions/auth';
import { LinkContainer } from 'react-router-bootstrap';

const Menu = () => {
    return (
                <Nav navbar>
                    <LinkContainer to={'/page'}>
                    <Button>hoge</Button>
                    </LinkContainer>
                </Nav>
    )
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
(Menu)