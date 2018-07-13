import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';

class GuestOnly extends React.Component {
  static contextTypes = {
  }

  componentWillMount() {
    this.guestWillTransfer(this.props, this.context.router);
  }

  componentWillUpdate(nextProps) {
    this.guestWillTransfer(nextProps, this.context.router);
  }

  guestWillTransfer(props, router) {
    if (!props.auth.isLoggedIn) {
      router.replace('/login');
    }
  }

  render() {
    return <div>{this.props.children}</div>;
  }
}
function select({ auth }) {
  return { auth };
}

export default connect(select)(GuestOnly);