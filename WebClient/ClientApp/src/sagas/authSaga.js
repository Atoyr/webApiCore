import { takeEvery, delay } from 'redux-saga';
import { put, call, select } from 'redux-saga/effects';

import {REQUEST_LOGIN_ASYNC, requestLoginAsync} from '../actions/auth';
function* runRequestLoginAsync(action){
    yield put(requestLoginAsync(action));
}
export function* handleRequestLoginAsync(action){
    yield takeEvery(REQUEST_LOGIN_ASYNC,runRequestLoginAsync);
}