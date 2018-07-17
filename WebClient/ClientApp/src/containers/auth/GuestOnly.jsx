import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';

class GuestOnly extends Component {
  static contextTypes = {
  }

  componentWillMount() {
    this.guestWillTransfer(this.props, this.context.router);
  }

  componentWillUpdate(nextProps) {
    this.guestWillTransfer(nextProps, this.context.router);
  }

  guestWillTransfer(props, router) {
    if (props.auth.isLoggedin) {
      console.log(props.auth);
      router.replace('/');
    }
  }

  render() {
    return <div>{this.props.children}</div>;
  }
}

const mapStateToProps = ({auth}) =>({
   auth: auth 
})
export default connect(
    mapStateToProps
)(GuestOnly);