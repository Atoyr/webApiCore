import { takeEvery, delay } from 'redux-saga';
import { put, call, select } from 'redux-saga/effects';

import {REQUEST_LOGIN_ASYNC, requestLoginAsync, successLogin, failLogin, failRefreshToken, successRefreshToken, REQUEST_REFRESH_TOKEN_ASYNC, FETCH_LOGIN_STATE_ASYNC, fetchLoginStateAsync} from '../actions/auth';

function* runRequestLoginAsync(action){
    const user = {
        username : action.payload.username,
        password : action.payload.password
    };
    const method = 'POST';
    const headers = {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    };
    const body = JSON.stringify(user);
    const uri = 'api/token';
    console.log(user);
    const res = yield fetch(uri,{headers:headers,body:body,method:method})
    console.log(res);
    if (res.ok) {
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

}
export function* handleFetchLoginStateAsync(action){
    yield takeEvery(FETCH_LOGIN_STATE_ASYNC,runRequestFetchLoginStateAsync);
}