# jwt_api_boilerplate
.NET Core API with JWT Authentication

------------------------------------------------------------------------------------
### In order to use it with postman:
- Set an application environment with a variable called "authToken"
- Set a test script when login into the api:
```js
let res = pm.response.json();
pm.environment.set('authToken', res.access_token)
```
- Set a bearer token whenever we want to make a request after loging in
