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
    executeLogin,
    successLogout,
    REQUEST_LOGOUT_ASYNC,
    requestRefreshTokenAsync} from '../actions/auth';
import { executeGetToken, executeValidateToken , executeRefreshToken} from '../api/auth';

function* runRequestLoginAsync(action){
    yield put(executeLogin());
    const user = {
        mail : action.payload.mail,
        password : action.payload.password
    };
    const res = yield call(executeGetToken,user);
    console.log(res)
    if (res.ok) {
        yield put(successLogin(res.body));
    }
    else {
        console.log(res)
        yield put(failLogin(res));
    }
}
export function* handleRequestLoginAsync(action){
    yield takeEvery(REQUEST_LOGIN_ASYNC,runRequestLoginAsync);
}

function* runRequestRefreshTokenAsync(action){
    const token = yield select(state => state.auth.token);
    const refreshToken = yield select(state => state.auth.refreshToken);
    const res = yield call(executeRefreshToken, token, refreshToken);
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
    console.log(jwt);
    console.log(refreshToken);
    if (jwt) {
        if (refreshToken) {
            yield put(requestRefreshTokenAsync({token: jwt, refreshToken: refreshToken}));
            yield put(successFetchLoginState({ token: jwt, refreshToken: refreshToken }));
        } else{
            const res = yield call(executeValidateToken, jwt);
            if (res.ok) {
                yield put(successFetchLoginState({ token: jwt, refreshToken: refreshToken }));
            } else {
                yield put(failFetchLoginState());
            }
        }
    }
    else {
        yield put(failFetchLoginState());
    }
}
export function* handleFetchLoginStateAsync(action) {
    yield takeEvery(FETCH_LOGIN_STATE_ASYNC, runRequestFetchLoginStateAsync);
}
function* runRequestLogoutAsync(action) {
    console.log(action)
    localStorage.removeItem('jwt');
    localStorage.removeItem('refreshToken');
    yield put(successLogout());
}
export function* handleRequestLogoutAsync(action) {
    yield takeEvery(REQUEST_LOGOUT_ASYNC, runRequestLogoutAsync);
}