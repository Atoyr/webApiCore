import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';

class GuestOnly extends Component {
  static contextTypes = {
  }

  componentWillMount() {
    this.guestWillTransfer(this.props);
  }

  componentWillUpdate(nextProps) {
    this.guestWillTransfer(nextProps);
  }

  guestWillTransfer(props) {
      console.log(props);
      const{history} = props;
    if (props.auth.isLoggedin) {
      console.log(props.auth);
      history.replace('/');
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