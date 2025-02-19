a new project

## How to run locally

### 1. Set local hostname for Keycloak
The ASP.NET Core services use the Keycloak base endpoint to redirect users to login as well as authenticating access tokens internally. So the endpoint needs to be accessible from both the docker network and host machine at the same time. In order to achieve this, you need to edit the /etc/hosts file to add a hostname with the name of the keycloak container pointing to localhost:

```
127.0.0.1   keycloak
```
