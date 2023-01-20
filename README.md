# StateParks.Solution

## Contributors

* Chris Loveless

## Description
#### Epicodus Week 12 Code Review
This independent project demonstrates proficiency with building and documenting a Web API, using JSON Web Token Authentication. The user can create a jwt bearer token in order to access the api endpoints. Jwt are used to authenticate users and secure api data. The project also enables CORS with default policies in order to allow for an api call from a client-side JavaScript application. 

## Technologies Used

* _C#_
* _ASP .NET 6 Core_
* _MySQL_
* _Entity Framework Core_
* _JSON Web Tokens_
* _CORS_
* _Swashbuckle_

## How To Run This Project

## Setup/Installation Requirements

1. Install MySQL Community Server and MySQL Workbench. Follow the instructions _[here](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql/)_.

2. Install ```dotnet ef``` tool to update database: ```dotnet tool install --global dotnet-ef --version 6.0.1```

3. Clone down the git repo ```https://github.com/ChrisKLoveless/StateParks.Solution.git``` to the ```desktop``` directory.

4. Open the project with VSCode or a different source code editor.

5. In the root directory be sure to create a ```.gitignore``` file and input the following to secure your database information:
    * ```appsettings.json```
    * ```obj```
    * ```bin```

6. If you are pushing this project to a remote git repo add ```.gitignore``` to git and commit before moving on.

7. Restore required packages: change directory to ```StateParksApi``` and restore with ```$ dotnet restore```

## Database Setup

1.  Within the production directory ```StateParksApi```, create two new files: `appsettings.json` and `appsettings.Development.json`.

  * Fill in `appsettings.json` with the following code: 
  * `Be sure to replace the required fields marked with ```[]``` that must contain your database name, user id, and password.`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[DB-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    }
}
```

* Fill in `appsettings.Development.json` with the following code:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "Jwt": {
    "Issuer": "http://localhost:5000",
    "Audience": "http://localhost:5000",
    "Key": "2754aa05-9e81-44a3-83da-50f819c07563"
  }
}
```

1.  Create the database: change directory to ```StateParksApi```, and run ```dotnet ef migrations add Initial``` and then run ```dotnet ef database update``` in your shell.

2.  While in the ```StateParksApi``` directory use ```$ dotnet build``` to build the program.

3.  While in the ```StateParksApi``` directory use ```$ dotnet watch run``` to run the program in the browser with a watcher and Swagger UI. Or use ```$ dotnet run``` and test endpoints in [Postman](https://www.postman.com/).

### Available Endpoints

```
GET http://localhost:5000/api/parks/
GET http://localhost:5000/api/parks/{id}
POST http://localhost:5000/api/parks/
PUT http://localhost:5000/api/parks/{id}
DELETE http://localhost:5000/api/parks/{id}
```
```
GET http://localhost:5000/api/states/
GET http://localhost:5000/api/states/{id}
POST http://localhost:5000/api/states/
PUT http://localhost:5000/api/states/{id}
DELETE http://localhost:5000/api/states/{id}
```

Note: `{id}` is a variable, replace it with the id number of the State/Park you want to GET, PUT, or DELETE.

## JSON Web Token Authentication
The implementation of Jwt authentication is currently only attached to the GET request in the ParksController. At this time if you try to make a GET request to ```http://localhost:5000/api/parks``` you will get a 401 Unauthorized response.
In order to further secure the api you can place the data annotation ```[Authorize]``` above the desired controller or its' individual methods. Follow these steps to test out the Jwt and make a GET request to see a list of parks.

1. Open Postman and make sure the app is running with ```$ dotnet run```. Make a POST request with url: ```http://localhost:5000/security/createToken```

2. You will need to include a **body** as raw JSON data. Here is an example:
```json
{
    "Username": "chris",
    "Password": "chris123",
    "EmailAddress": "chris_admin@email.com",
    "Role": "Administrator"
}
```
3. The request should return a Jwt. Here is an example
```
"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
```
4. Make a GET request to ```http://localhost:5000/api/parks```

5. Before this request is sent, navigate to the `Authorization` tab in Postman and select Type: Bearer Token, then copy and paste the Jwt under the 'Token' field (without the quotes).


6. You can now view a list of parks in the data base that was otherwise not authorized for users without the token.   

For more information on JWT refer to this _[link](https://jwt.io/)_

#### Optional Query String Parameters for GET Requests

| Parameter | Type   | Required     | Description                                     |
| --------- | ------ | ------------ | ----------------------------------------------- |
| Name      | String | not required | Returns State or Park with a matching name.     |
| Id        | Int    | not required | Returns State or Park with a matching id value. |

GET requests to `http://localhost:5000/api/parks/`

The following query will return all parks with the name "Crater Lake":
```
GET http://localhost:5000/api/parks?name=Crater Lake
```
The following query will return all parks with the Id of 3:
```
GET http://localhost:5000/api/parks/3
```
GET requests to `http://localhost:5000/api/states/` 

The following query will return all states with the name "Oregon":
```
GET http://localhost:5000/api/states?name=Oregon
```
The following query will return all states with the Id of 1:
```
GET http://localhost:5000/api/states/1
```

#### Additional Requirements for POST Request

When making a POST request to `http://localhost:5000/api/states/` or `http://localhost:5000/api/parks/`, you need to include a **body**. Here's an example body in JSON:

```json
{
  "StateId": 5,
  "Name": "montana",
}
```

When making a PUT request to `http://localhost:5000/api/states/{id}` or `http://localhost:5000/api/parks/{id}`, you need to include a **body**. Select the raw radio button and JSON data type. Here's an example body in JSON:

```json
{
  "StateId": 5,
  "Name": "Montana",
}
```

## Cross-Origin Requests
If you would like to enable additional CORS policies and attributes go _[here](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0)_

## Known Bugs

* The Swagger UI is not enabled to send a request with the authorization token. To test the implementation of Jwt use Postman and follow the steps above.
* If any bugs are found please email a brief description to: ```chriskloveless@gmail.com```

## License
Copyright (c) 2022 Chris Loveless
_[MIT](https://choosealicense.com/licenses/mit/)_