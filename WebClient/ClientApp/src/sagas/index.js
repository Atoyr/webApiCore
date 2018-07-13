import { put, call,fork } from "redux-saga/effects";
import { handleRequestLoginAsync } from "./authSaga";

export default function* rootSaga() {
    yield fork(handleRequestLoginAsync)
}