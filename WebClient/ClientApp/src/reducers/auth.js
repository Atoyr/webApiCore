import { handleActions } from 'redux-actions';

var inisialState = {
    token:'',
    refreshToken:'',
    isLoggedin: false,
    isFetching: false,
    isPrepared: false
}

export default handleActions({
    SUCCESS_LOGIN : (state,action) => {
        console.log(state);
        console.log(action);
        localStorage.setItem('jwt', action.payload.token);
        localStorage.setItem('refreshToken', action.payload.refreshToken);
        return Object.assign({},state,{isLoggedin:true,token:'',refreshToken:'',isFetching: false, isPrepared:true});
    },
    FAIL_LOGIN : (state,action) => {
        console.log(state);
        console.log(action);
        return inisialState;
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
        return inisialState;
    },
    SUCCESS_FETCH_LOGIN_STATE : (state,action) => {
        console.log(state);
        console.log(action);
        return Object.assign({},state,{isLoggedin:true,token:action.payload.token,refreshToken:'',isFetching: false, isPrepared:true});
    },
    FAIL_FETCH_LOGIN_STATE : (state,action) => {
        console.log(state);
        console.log(action);
        return inisialState;
    },
    EXECUTE_LOGIN : (state,action) => {
        console.log(state);
        console.log(action);
        return Object.assign({},state,{isFetching: true});
    }
},inisialState);