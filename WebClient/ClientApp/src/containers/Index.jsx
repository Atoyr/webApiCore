import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';

class Index extends Component {

  render() {
    return <p>hello world </p>
  }
}

const mapStateToProps = ({auth}) =>({
   auth: auth 
})
export default connect(
    mapStateToProps
)(Index);