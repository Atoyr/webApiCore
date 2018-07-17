import { delay } from 'redux-saga';
import { put, call, select, takeEvery} from 'redux-saga/effects';

import {
    REQUEST_LOGIN_ASYNC, 
    requestLoginAsync, 
    successLogin, 
    failLogin, 
    failRefreshToken, 
    successRefreshToken, 
    REQUEST_REFRESH_TOKEN_ASYNC, 
    FETCH_LOGIN_STATE_ASYNC, 
    successFetchLoginState,
    failFetchLoginState} from '../actions/auth';

function* runRequestLoginAsync(action){
    console.log(action);
    const user = {
        username : 'hogehoge',//action.payload.username,
        password : 'fugufugu'//action.payload.password
    };
    const uri = 'api/token';
    const option = 
    {
        method: 'POST',
        mode: 'cors',
        redirect: 'follow',
        body: JSON.stringify(user),
        headers: new Headers({
            'Content-Type': 'application/json',
            Accept: 'application/json',
        })
    }
    const res = yield fetch(uri,option)
    if (res.ok) {
        localStorage.setItem('jwt', res);
        yield put(successLogin(res));
    }
    else {
        yield put(failLogin(res.status));
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
    const jwt = localStorage.getItem('jwt');

    if (jwt) {
        yield put(successFetchLoginState());
    }
    else {
        yield put(failFetchLoginState());
    }
}
export function* handleFetchLoginStateAsync(action){
    yield takeEvery(FETCH_LOGIN_STATE_ASYNC,runRequestFetchLoginStateAsync);
}