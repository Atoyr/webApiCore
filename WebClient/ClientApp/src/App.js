import React from 'react';
import { Route, Switch} from 'react-router';
import App from './containers/App';
import Auth from './containers/Auth';
import Login from './containers/auth/Login';
import Index from './containers/Index';

export default () => (
  <Switch>
    <Route exact path='/login' component={Login} />
    <Auth>
      <Switch>
        <Route exact path='/' component={Index} />
      </Switch>
    </Auth>
  </Switch>
);
