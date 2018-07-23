import { handleActions } from 'redux-actions';
import decode from 'jwt-claims';

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
        const claim = decode(action.payload);
        return Object.assign({},state,claim);
    },
    CLEAR_CLAIM : (state,action) => {
        return initialState;
    }
},initialState);