import { handleActions } from 'redux-actions';

var inisialState = {
    isLoggedin:false,
    token:'',
    refreshToken:'',
    isFetching: false
}

export default handleActions({
    SUCCESS_LOGIN : (state,action) => {
        console.log(state);
        console.log(action);
        return {isLoggedin:true,token:'',refreshToken:'',isFetching: false};
    },
    FAIL_LOGIN : (state,action) => {
        console.log(state);
        console.log(action);
        return inisialState;
    },
    SUCCESS_REFRESH_TOKEN : (state, action) => {
        console.log(state);
        console.log(action);
        return {isLoggedin:true,token:action.payload.token,refreshToken:'',isFetching: false};
    },
    FAIL_REFRESH_TOKEN : (state, action) => {
        console.log(state);
        console.log(action);
        return inisialState;
    },
    SUCCESS_FETCH_STATE : (state,action) => {
        console.log(state);
        console.log(action);
        return {isLoggedin:true,token:action.payload.token,refreshToken:'',isFetching: false};
    },
    FAIL_FETCH_LOGIN_STATE : (state,action) => {
        console.log(state);
        console.log(action);
        return inisialState;
    },
    FETCHING_LOGIN : (state,action) => {
        console.log(state);
        console.log(action);
        return {isLoggedin: false,token:'',refreshToken:'',isFetching: true};
    }
},inisialState);