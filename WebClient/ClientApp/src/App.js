import React from 'react';
import { Route, Switch} from 'react-router';
import Auth from './containers/Auth';
import Login from './containers/Login';
import Index from './containers/Index';

export default () => (
  <Switch>
    <Route exact path='/login' component={Login} />
    <Auth>
      <p>hogehoge</p>
      <Switch>
        <Route exact path='/' component={Index} />
      </Switch>
    </Auth>
  </Switch>
);
