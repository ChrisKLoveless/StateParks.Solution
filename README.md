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

8.  Within the production directory ```StateParksApi```, create two new files: `appsettings.json` and `appsettings.Development.json`.

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
  }
}
```

10. Create the database: change directory to ```StateParksApi```, and run ```dotnet ef migrations add Initial``` and then run ```dotnet ef database update``` in your shell.

11. While in the ```StateParksApi``` directory use ```$ dotnet build``` to build the program.

12. While in the ```StateParksApi``` directory use ```$ dotnet watch run``` to run the program in the browser with a watcher and Swagger UI. Or use ```$ dotnet run``` and test endpoints in [Postman](https://www.postman.com/).

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

#### Optional Query String Parameters for GET Requests

| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- |
| Name    | String      | not required | Returns State or Park with a matching name. |
| Id        | Int      | not required | Returns State or Park with a matching id value. |

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

When making a PUT request to `http://localhost:5000/api/states/{id}` or `http://localhost:5000/api/parks/{id}`, you need to include a **body**. Here's an example body in JSON:

```json
{
  "StateId": 5,
  "Name": "Montana",
}
```
## Known Bugs

* If any bugs are found please email a brief description to: ```chriskloveless@gmail.com```

## License
Copyright (c) 2022 Chris Loveless
_[MIT](https://choosealicense.com/licenses/mit/)_