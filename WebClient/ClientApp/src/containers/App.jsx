import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import {Route, Switch, Redirect} from 'react-router-dom';
import { fetchLoginStateAsync } from '../actions/auth';
import Loading from '../components/Loading';

class App extends Component {
  componentWillMount() {
//    this.props.dispatch(fetchLoginStateAsync());
  }

  handleLogout() {
  }

  render() {
    return
    {
    }
  }
}

function select({ auth }) {
  return { auth };
}

export default connect(select)(App);