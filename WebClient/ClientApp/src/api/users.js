export async function executeCreateUser(user){
    const uri = 'api/users/create_user';
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