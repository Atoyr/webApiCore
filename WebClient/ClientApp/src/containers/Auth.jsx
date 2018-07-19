import React, { Component, PropTypes } from 'react';
import { Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import { fetchLoginStateAsync, executeLogin} from '../actions/auth';

class Auth extends Component{
    constructor(props) {
        super(props);
        props.fetchLoginStateAsync();
    }
    componentWillMount(){
        console.log(this.props);
    }
    render() {
        return (
            this.props.auth.isLoggedin ? 
            this.props.children : 
            this.props.auth.isPreoared ?
            <Redirect to={'/login'} /> :
            <p>loading </p>)
    }
}

const mapStateToProps = ({auth}) =>({
   auth: auth 
})
function mapDispatchToProps(dispatch) {
    return {
        fetchLoginStateAsync: () => 
          dispatch(fetchLoginStateAsync())
    }
}

export default connect(mapStateToProps,mapDispatchToProps)(Auth);