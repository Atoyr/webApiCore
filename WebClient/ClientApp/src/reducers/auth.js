import { handleActions } from 'redux-actions';

var inisialState = {
    isLoggedin:false,
    token:'',
    refreshToken:''
}

export default handleActions({
    SUCCESS_LOGIN : (state,action) => {
        console.log(state);
        console.log(action);
        return {isLoggedin:true,token:action.payload};
    },
    FAIL_LOGIN : (state,action) => {
        return inisialState;
    },
    SUCCESS_REFRESH_TOKEN : (state, action) => {
        return {isLoggedin:true,token:action.payload};
    },
    FAIL_REFRESH_TOKEN : (state, action) => {
        return inisialState;
    }
},inisialState);