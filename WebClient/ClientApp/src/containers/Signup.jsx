import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import { requestCreateUserAsync } from '../actions/users'
import { fetchLoginStateAsync } from '../actions/auth';
import "./signin.css";
import {Form, Button, FormControl} from 'react-bootstrap';

class Signup extends Component {
  constructor(props) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  handleSubmit(e) {
    e.preventDefault();
    console.log(e);
    const target = e.target;
    this.props.requestCreateUserAsync({ 
      mail: target.mail.value.trim(),
      password: target.password.value.trim(),
      name: target.name.value.trim(),
      code: target.code.value.trim() })
  }

  render() {
    return (
    <Form className='form-signin' onSubmit={this.handleSubmit} >
      <h1 >Please sign up</h1>
      <FormControl type="text" id="mail" placeholder="Mail" required />
      <FormControl type="text" id="code" placeholder="Usercode" />
      <FormControl type="text" id="name" placeholder="Username" />
      <FormControl type="password" id="password" placeholder="Password" required />
        <Button type="submit" bsStyle="primary" block >Sign in</Button>
      <p >&copy; 2017-2018</p>
    </Form>)
  }
}

const mapStateToProps = ({auth}) =>({
   auth: auth 
})
function mapDispatchToProps(dispatch) {
    return {
        requestCreateUserAsync : (value) => {
          console.log(value);
          dispatch(requestCreateUserAsync(value));
        },
        fetchLoginStateAsync: () => dispatch(fetchLoginStateAsync())
    }
}
export default connect(
    mapStateToProps,
    mapDispatchToProps
)
(Signup)