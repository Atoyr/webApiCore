import { handleActions } from 'redux-actions';

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

export default handleActions({
    SUCCESS_LOGIN : (state,action) => {
        console.log(state);
        console.log(action);
        localStorage.setItem('jwt', action.payload.token);
        localStorage.setItem('refreshToken', action.payload.refreshToken);
        return Object.assign({},state,{isLoggedin:true, token:action.payload.token, refreshToken:action.payload.refreshToken, isFetching: false, isPrepared:true});
    },
    FAIL_LOGIN : (state,action) => {
        console.log(state);
        console.log(action);
        return preparedState;
    },
    SUCCESS_REFRESH_TOKEN : (state, action) => {
        console.log(state);
        console.log(action);
        localStorage.setItem('jwt', action.payload.token);
        localStorage.setItem('refreshToken', action.payload.refreshToken);
        return Object.assign({},state,{isLoggedin:true,token:action.payload.token,refreshToken:'',isFetching: false, isPrepared:true});
    },
    FAIL_REFRESH_TOKEN : (state, action) => {
        console.log(state);
        console.log(action);
        return preparedState;
    },
    SUCCESS_FETCH_LOGIN_STATE : (state,action) => {
        console.log(state);
        console.log(action);
        return Object.assign({},state,{isLoggedin:true,token:action.payload.token,refreshToken:'',isFetching: false, isPrepared:true});
    },
    FAIL_FETCH_LOGIN_STATE : (state,action) => {
        console.log(state);
        console.log(action);
        return preparedState;
    },
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