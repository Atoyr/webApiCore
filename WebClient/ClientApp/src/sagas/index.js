import { put, call,fork } from "redux-saga/effects";
import { handleRequestLoginAsync, handleRequestRefreshTokenAsync, handleFetchLoginStateAsync } from "./authSaga";

export default function* rootSaga() {
    yield fork(handleRequestLoginAsync),
    yield fork(handleRequestRefreshTokenAsync),
    yield fork(handleFetchLoginStateAsync)
}