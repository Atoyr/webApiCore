
import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import "./signin.css";
import { requestLoginAsync } from '../../actions/auth';
import {Form, Button, FormControl} from 'react-bootstrap';
import FieldGroup from '../../components/FieldGroup';

const usernameStyle = {
  marginbottom: '-1px',
  borderbottomrightradius: '0',
  borderbottomleftradius: '0'
}

class Login extends Component {
    constructor(props){
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleSubmit(e) {
        e.preventDefault();
        console.log(e);
        const target = e.target;
        this.props.requestLoginAsync({username: target.name.value.trim(), password:target.password.value.trim() })
    }

    render() {
        return (
            <Form className='form-signin' onSubmit={this.handleSubmit} >
                <h1 >Please sign in</h1>
                <FormControl type="text" id="name" placeholder="Username" required />
                <FormControl type="password" id="password" placeholder="Password" required />
                <div >
                    <label>
                        <input type="checkbox" value="remember-me" /> Remember me
                    </label>
                </div>
                {this.props.auth.isFetching ? 
                    <div className="loading" /> :
                    <Button type="submit" bsStyle="primary" block >Sign in</Button>}
                <p >&copy; 2017-2018</p>
            </Form>
    );
    }
}

const mapStateToProps = ({auth}) =>({
   auth: auth 
})
function mapDispatchToProps(dispatch) {
    return {
        requestLoginAsync : (value) => {
          console.log(value); 
          dispatch(requestLoginAsync({username:value.username,password: value.password}))}
    }
}

export default connect(mapStateToProps,mapDispatchToProps)(Login);