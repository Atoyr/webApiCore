export function getToken(user){
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
        return responseBodyPromise.then(body => ({ body: body, ok: res.ok }))
    });
}