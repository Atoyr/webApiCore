import { delay } from 'redux-saga';
import { put, call, select, takeEvery} from 'redux-saga/effects';

import {
    REQUEST_LOGIN_ASYNC, 
    successLogin, 
    failLogin, 
    failRefreshToken, 
    successRefreshToken, 
    REQUEST_REFRESH_TOKEN_ASYNC, 
    FETCH_LOGIN_STATE_ASYNC, 
    successFetchLoginState,
    failFetchLoginState,
    executeLogin} from '../actions/auth';
import { getToken } from '../api/auth';

function* runRequestLoginAsync(action){
    yield put(executeLogin());
    console.log(action);
    const user = {
        username : action.payload.username,
        password : action.payload.password
    };
    const res = yield call(getToken,user);
    if (res.ok) {
        yield put(successLogin(res.body));
    }
    else {
        yield put(failLogin(res));
    }
}
export function* handleRequestLoginAsync(action){
    yield takeEvery(REQUEST_LOGIN_ASYNC,runRequestLoginAsync);
}

function* runRequestRefreshTokenAsync(action){
    const refreshToken = yield select(state => state.auth.refreshToken);
    const method = 'POST';
    const headers = {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    };
    const body = JSON.stringify(refreshToken);
    const uri = 'api/token/refresh_tokne';
    const res = yield fetch(uri,{method,headers,body})
    if (res.ok) {
        yield put(successRefreshToken(res));
    }
    else {
        yield put(failRefreshToken(res.status));
    }
}
export function* handleRequestRefreshTokenAsync(action){
    yield takeEvery(REQUEST_REFRESH_TOKEN_ASYNC,runRequestRefreshTokenAsync);
}
function* runRequestFetchLoginStateAsync(action){
    yield put(executeLogin());
    console.log(action)
    const jwt = localStorage.getItem('jwt');
    const refreshToken = localStorage.getItem('refreshToken');
    if (jwt && refreshToken) {
        yield put(successFetchLoginState({token:jwt,refreshToken:refreshToken}));
    }
    else {
        yield put(failFetchLoginState());
    }
}
export function* handleFetchLoginStateAsync(action){
    yield takeEvery(FETCH_LOGIN_STATE_ASYNC,runRequestFetchLoginStateAsync);
}