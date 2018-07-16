
import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import "./signin.css";
import { requestLoginAsync } from '../../actions/auth';
import {Form} from 'react-bootstrap';
import FieldGroup from '../../components/FieldGroup';
const Login = ({auth,requestLoginAsync}) => {

    return (
      <Form onSubmit={requestLoginAsync}>
        <h1 >Please sign in</h1>
        <label >Email address</label>
        <FieldGroup type="text" id="name" placeholder="Email address" required />
        <label >Password</label>
        <input type="password" id="password" placeholder="Password" required/>
        <div >
            <label>
              <input type="checkbox" value="remember-me"/> Remember me
            </label>
        </div>
            <button type="submit">Sign in</button>
        <p >&copy; 2017-2018</p>
      </Form>
    );
}

const mapStateToProps = ({auth}) =>({
   auth: auth 
})
function mapDispatchToProps(dispatch) {
    return {
        requestLoginAsync : (value) => {
          console.log(value); 
          dispatch(requestLoginAsync({username:"hoge",password: "fugu"}))}
    }
}

export default connect(mapStateToProps,mapDispatchToProps)(Login);