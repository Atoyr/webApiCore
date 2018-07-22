import { handleActions } from 'redux-actions';
import decode from 'jwt-claims';
import { successFetchLoginState } from '../actions/auth';

var initialState = {
    iss:'',
    sub:'',
    aud:[],
    exp:'0',
    nbf:'0',
    iat:'0',
    jti:'',
}

export default handleActions({
    CHANGE_CLAIM : (state,action) => {
        return initialState;
    }
})