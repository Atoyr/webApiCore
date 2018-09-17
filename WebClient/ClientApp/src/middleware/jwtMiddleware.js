import decode from 'jwt-claims';

export const jwt = store => next => action => async() => {
    if (typeof action === 'function') {
        if(getstate().auth && getstate().auth.token && !auth.isFetching) {
            
            if (exp && (moment(exp) - moment(Date.now()) < 5000)) {
                // make sure we are not already refreshing the token
                if (!getState().auth.freshTokenPromise) {
                    return await refreshToken().then(() => next(action));
                } else {
                    return getState().auth.freshTokenPromise.then(() => next(action));
                }
            }
        }
    }
    return next(action);
}