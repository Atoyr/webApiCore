import {createAction} from 'redux-actions';

export const REQUEST_LOGIN_ASYNC = 'REQUEST_LOGIN_ASYNC';
export const requestLoginAsync = createAction(REQUEST_LOGIN_ASYNC);
export const SUCCESS_LOGIN = 'SUCCESS_LOGIN';
export const successLogin = createAction(SUCCESS_LOGIN);
export const FAIL_LOGIN = 'FAIL_LOGIN';
export const failLogin = createAction(FAIL_LOGIN);

export const REQUEST_REFRESH_TOKEN_ASYNC = 'REQUEST_REFRESH_TOKEN_ASYNC';
export const requestRefreshTokenAsync = createAction(REQUEST_REFRESH_TOKEN_ASYNC);
export const SUCCESS_REFRESH_TOKEN = 'SUCCESS_REFRESH_TOKEN';
export const successRefreshToken = createAction(SUCCESS_REFRESH_TOKEN);
export const FAIL_REFRESH_TOKEN = 'FAIL_REFRESH_TOKEN';
export const failRefreshToken = createAction(FAIL_REFRESH_TOKEN);

export const FETCH_LOGIN_STATE_ASYNC = 'FETCH_LOGIN_STATE_ASYNC';
export const fetchLoginStateAsync = createAction(FETCH_LOGIN_STATE_ASYNC);
export const SUCCESS_FETCH_LOGIN_STATE = 'SUCCESS_FETCH_LOGIN_STATE';
export const successFetchLoginState = createAction(SUCCESS_FETCH_LOGIN_STATE);
export const FAIL_FETCH_LOGIN_STATE = 'FAIL_FETCH_LOGIN_STATE';
export const failFetchLoginState = createAction(FAIL_FETCH_LOGIN_STATE);

export const FETCHING_LOGIN = 'FETCHING_LOGIN';
export const fetchingLogin = createAction(FETCHING_LOGIN);