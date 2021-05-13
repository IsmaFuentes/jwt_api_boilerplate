# jwt_api_boilerplate
.NET Core API with JWT Authentication

------------------------------------------------------------------------------------
### In order to use it with postman:
- Set an application environment with a variable called "authToken"

- Pass the auth params inside the request body and set a test script to store the token:

![alt text](https://github.com/IsmaFuentes/jwt_api_boilerplate/blob/master/images/login.PNG)

```js
let res = pm.response.json();
pm.environment.set('authToken', res.access_token)
```

- Set a bearer token whenever we want to make a request after loging in

![alt text](https://github.com/IsmaFuentes/jwt_api_boilerplate/blob/master/images/authorized.PNG)
