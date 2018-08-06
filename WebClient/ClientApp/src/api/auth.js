export async function executeGetToken(user){
    const uri = 'api/token';
    const option =
    {
        method: 'POST',
        mode: 'cors',
        redirect: 'follow',
        body: JSON.stringify(user),
        headers: new Headers({
            'Content-Type': 'application/json',
            Accept: 'application/json',
        })
    }
    return fetch(uri,option)
    .then(res => {
        const responseBodyPromise = res.json()
        if(!res.Ok){
            return ({ ok: res.ok })
        }
        return responseBodyPromise.then(body => ({ body: body, ok: res.ok }))
    });
}
export async function executeValidateToken(token){
    const uri = 'api/token/validate_token';
    const option =
    {
        method: 'POST',
        mode: 'cors',
        redirect: 'follow',
        headers: new Headers({
            'Content-Type': 'application/json',
            Accept: 'application/json',
            Authorization: `Bearer ${token}`
        })
    }
    return fetch(uri,option)
    .then(res => ({ok:res.ok}))
}

export async function executeRefreshToken(token, refreshToken){
    const uri = 'api/token/refresh_token';
    const option =
    {
        method: 'POST',
        mode: 'cors',
        redirect: 'follow',
        headers: new Headers({
            'Content-Type': 'application/json',
            Accept: 'application/json',
            Authorization: `Bearer ${token}`
        }),
        body: JSON.stringify(refreshToken)
    }
    console.log(option)
    return fetch(uri,option)
    .then(res => {
        const responseBodyPromise = res.json()
        return responseBodyPromise.then(body => ({ body: body, ok: res.ok }))
    });
}