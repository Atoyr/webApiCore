import React from 'react';
import { Route , IndexRoute} from 'react-router';
import UserOnly from './containers/auth/UserOnly';
import GuestOnly from './containers/auth/GuestOnly';
import DashBoard from './components/DashBoard';
import Login from './containers/auth/Login';
import Index from './containers/Index';

export default () => (
    <Route exact path='/' component={Login} >
      <Route component={UserOnly}>
        <Route component={Index} />
      </Route>
      <Route component={GuestOnly}>
        <Route path ="/login" component={Login} />
      </Route>
    </Route>
);
