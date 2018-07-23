import decode from 'jwt-claims';

export function　jwt({dispatch, getstate}) {
    retunr next => action => {
        if (typeof action === 'function') {
            getstate().auth && getstate().auth.token){
                var exp = decode(getstate().auth.token).exp;
                if (exp && (moment(exp) - moment(Date.now()) < 5000)) {

                    // make sure we are not already refreshing the token
                    if (!getState().auth.freshTokenPromise) {
                        return refreshToken().then(() => next(action));
                    } else {
                        return getState().auth.freshTokenPromise.then(() => next(action));
                    }
                }
            }
        }
        return next(action);
    }
}