import {createAction} from 'redux-actions';

export const REQUEST_CREATE_USER_ASYNC = 'REQUEST_CREATE_USER_ASYNC';
export const requestCreateUserAsync = createAction(REQUEST_CREATE_USER_ASYNC);
export const SUCCESS_CREATE_USER = 'SUCCESS_LOGIN';
export const successCreateUser = createAction(SUCCESS_CREATE_USER);
export const FAIL_CREATE_USER = 'FAIL_LOGIN';
export const failCreateUser = createAction(FAIL_CREATE_USER);