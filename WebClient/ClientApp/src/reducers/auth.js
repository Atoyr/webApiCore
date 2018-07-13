import { handleActions } from 'redux-actions';

var inisialState = {}

export default handleActions({
    SUCCESS_LOGIN : (satate,action) => {
        return action.payload;
    },
},inisialState);