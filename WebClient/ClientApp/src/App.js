import React from 'react';
import { Route, Switch} from 'react-router';
import Auth from './containers/Auth';
import Login from './containers/Login';
import Index from './containers/Index';
import Page from './containers/Page';
import Header from './containers/Header';
import Menu from './containers/Menu';
import Signup from './containers/Signup';

export default () => (
  <Switch>
    <Route exact path='/login' component={Login} />
    <Route exact path='/signup' component={Signup} />
    <Auth>
      <Header />
      <Menu />
      <Switch>
        <Route exact path='/' component={Index} />
        <Route exact path='/page'component={Page} />
      </Switch>
    </Auth>
  </Switch>
);
