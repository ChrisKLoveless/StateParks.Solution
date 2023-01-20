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

GET requests to `http://localhost:5000/api/parks/` and `http://localhost:5000/api/states/` 


The following query will return all parks with the name "Crater Lake":
```
GET http://localhost:5000/api/parks?name=Crater Lake
```
The following query will return all parks with the Id of 3:
```
GET http://localhost:5000/api/parks/3
```
The following query will return all states with the name "Oregon":
```
GET http://localhost:5000/api/states?name=Oregon
```
The following query will return all states with the Id of 1:
```
GET http://localhost:5000/api/states/1
```
