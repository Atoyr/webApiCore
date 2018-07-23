import {createAction} from 'redux-actions';

export const CHANGE_CLAIM = 'CHANGE_CLAIM';
export const changeClaim = createAction(CHANGE_CLAIM);
export const CLEAR_CLAIM = 'CLEAR_CLAIM';
export const clearClaim = createAction(CLEAR_CLAIM);