import React from 'react';
import { Redirect } from 'react-router-dom';
import { connect } from 'react-redux';

const Auth = ({auth, children}) => {
    return(auth.isLoggedin ? children : <Redirect to={'/login'} />)
}

const mapStateToProps = ({auth}) =>({
   auth: auth 
})
export default connect(mapStateToProps)(Auth);