import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import "./signin.css";
import { requestLoginAsync, fetchLoginStateAsync } from '../actions/auth';
import {Form, Button, FormControl} from 'react-bootstrap';
import { Redirect } from 'react-router-dom';

const usernameStyle = {
  marginbottom: '-1px',
  borderbottomrightradius: '0',
  borderbottomleftradius: '0'
}

class Login extends Component {
    componentWillMount(){
        console.log(this.props);
        this.props.fetchLoginStateAsync();
    }
    constructor(props){
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleSubmit(e) {
        e.preventDefault();
        console.log(e);
        const target = e.target;
        this.props.requestLoginAsync({mail: target.mail.value.trim(), password:target.password.value.trim() })
    }

    render() {
        return (
            this.props.auth.isLoggedin ?
            ( <Redirect to={'/'} />)
            :(
            <Form className='form-signin' onSubmit={this.handleSubmit} >
                <h1 >Please sign in</h1>
                <FormControl type="text" id="mail" placeholder="Mail" required />
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
    ));
    }
}

const mapStateToProps = ({auth}) =>({
   auth: auth 
})
function mapDispatchToProps(dispatch) {
    return {
        requestLoginAsync : (value) => dispatch(requestLoginAsync({mail:value.mail,password: value.password})),
        fetchLoginStateAsync: () => dispatch(fetchLoginStateAsync())
    }
}

export default connect(mapStateToProps,mapDispatchToProps)(Login);