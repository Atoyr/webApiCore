import { delay } from 'redux-saga';
import { put, call, select, takeEvery} from 'redux-saga/effects';
import { REQUEST_CREATE_USER_ASYNC, successCreateUser, failCreateUser } from '../actions/users';
import { executeCreateUser } from '../api/users';


function* runRequestCreateUserAsync(action){
    console.log(action)
    const user = {
        mail : action.payload.mail,
        password : action.payload.password,
        name : action.payload.name,
        code : action.payload.code
    }
    const res = yield call(executeCreateUser,user);
    if(res.Ok){
        yield put(successCreateUser());
    }
    else {
        yield put (failCreateUser());
    }
}
export function* handleRequestCreateUserAsync(action){
    yield takeEvery(REQUEST_CREATE_USER_ASYNC,runRequestCreateUserAsync);
}