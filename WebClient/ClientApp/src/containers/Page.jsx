import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import { fetchLoginStateAsync } from '../actions/auth';

class Page extends Component {
  componentWillMount() {
    this.props.fetchLoginStateAsync();
  }

  render() {
    return <p>hello Page </p>
  }
}

const mapStateToProps = ({auth}) =>({
   auth: auth 
})
function mapDispatchToProps(dispatch) {
    return {
        fetchLoginStateAsync : (value) => {
          console.log(value);
          dispatch(fetchLoginStateAsync());
        }
    }
}
export default connect(
    mapStateToProps,
    mapDispatchToProps
)
(Page)