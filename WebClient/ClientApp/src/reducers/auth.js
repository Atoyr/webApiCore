import { handleActions } from 'redux-actions';
import decode from 'jwt-claims';
import { changeClaim, clearClaim } from '../actions/claim';

var inisialState = {
    token:'',
    refreshToken:'',
    isLoggedin: false,
    isFetching: false,
    isPrepared: false
}
var preparedState = {
    token:'',
    refreshToken:'',
    isLoggedin: false,
    isFetching: false,
    isPrepared: true
}

const successLogin = (state,action) => {
        console.log(state);
        console.log(action);
        console.log(decode(action.payload.token))
        localStorage.setItem('jwt', action.payload.token);
        localStorage.setItem('refreshToken', action.payload.refreshToken);
        changeClaim(action.payload.token);
        return Object.assign({},state,{isLoggedin:true, token:action.payload.token, refreshToken:action.payload.refreshToken, isFetching: false, isPrepared:true});
}
const failLogin = (state,action) => {
        console.log(state);
        console.log(action);
        clearClaim();
        return preparedState;
}
export default handleActions({
    SUCCESS_LOGIN : (state,action) => 
        successLogin(state, action),
    FAIL_LOGIN : (state,action) => 
        failLogin(state,action),
    SUCCESS_REFRESH_TOKEN : (state, action) => 
        successLogin(state, action),
    FAIL_REFRESH_TOKEN : (state, action) => 
        failLogin(state,action),
    SUCCESS_FETCH_LOGIN_STATE : (state,action) => 
        successLogin(state, action),
    FAIL_FETCH_LOGIN_STATE : (state,action) => 
        failLogin(state,action),
    EXECUTE_LOGIN : (state,action) => {
        console.log(state);
        console.log(action);
        return Object.assign({},state,{isFetching: true});
    },
    SUCCESS_LOGOUT : (state,action) => {
        console.log(state);
        console.log(action);
        return Object.assign({},state,{isLoggedin:false, token:'', refreshToken:'',isFetching: false, isPrepared:true});
    }
},inisialState);