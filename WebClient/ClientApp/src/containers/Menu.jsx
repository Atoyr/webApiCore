import React, { Component, PropTypes } from 'react';
import { Navbar, Nav, NavItem,NavDropdown, MenuItem, Button, Glyphicon } from 'react-bootstrap';
import { connect } from 'react-redux';
import {Link} from 'react-router-dom';
import { fetchLoginStateAsync, requestLogoutAsync } from '../actions/auth';
import { LinkContainer, Collapse } from 'react-router-bootstrap';
import ListItem from '../components/ListItem';
import './menu.css';

const styleCreator = ({isHidden}) => {
    const width = isHidden ? '100px' : '260px'
    return {
    fontSize: '15px',
    paddingTop: '0px',
    width: width,
    height: '100%',
    position: 'fixed',
    color: '#033560',
    background: '#fff',
    textAlign: 'center'
    }
}
const Menu = () => {
    let visibility = false;
    return (
        <aside id='sidebar' style={styleCreator({isHidden:false})}>
            <nav id="global-nav">
                <ul>
                    <li><a href="#">Home</a></li>
                    <li className="sub-menu">
                        <a href="#" className="sub-menu-head">About</a>
                        {!visibility && <ul className="sub-menu-nav">
                            <li><a href="#">About 1</a></li>
                            <li><a href="#">About 2</a></li>
                            <li><a href="#">About 3</a></li>
                        </ul>}  
                    </li>
                    <li className="sub-menu">
                        <a href="#" className="sub-menu-head">Products</a>
                        <ul className="sub-menu-nav">
                            <li><a href="#">Product 1</a></li>
                            <li><a href="#">Product 2</a></li>
                            <li><a href="#">Product 3</a></li>
                        </ul>
                    </li>
                    <li><a href="#">Link</a></li>
                    <li><a href="#">Contact</a></li>
                </ul>
            </nav>
        </aside>
    )
}

const mapStateToProps = ({ auth }) => ({
    auth: auth
})
function mapDispatchToProps(dispatch) {
    return {
        requestLogoutAsync: (value) => {
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