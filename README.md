﻿# Ushin Services (ushinsvc) 21 July 2019 Jose Durazo ß This is a .NET Core app that implements CRUD operations for Nodes and Users. Also adds the JsonApiDotNetCore package. The app is Dockerized. To build: docker build -t ushinsvc . To run: docker run -d -p 8080:80 --name ushinsvc ushinsvc To test: call, for example: (GET) http://localhost:8080/api/users  (GET) http://localhost:8080/api/users/1  (POST) http://localhost:8080/api/users with a body:     {         "id": 1,         "email": "user@somewhere.com",         "password": null,         "created": "0001-01-01T00:00:00",         "modified": "0001-01-01T00:00:00"     }  (PUT) http://localhost:8080/api/users with a body in the same format as above, but ID must exist.  (DELETE) http://localhost:8080/api/users/1  (GET) http://localhost:8080/api/nodes  (GET) http://localhost:8080/api/nodes/1  (POST) http://localhost:8080/api/nodes with a body:     {         "id": 1,         "title": "The title of the node",         "category": null,         "parent_id": 0,         "created": "0001-01-01T00:00:00",         "modified": "0001-01-01T00:00:00",         "user_id": 0     }  (PUT) http://localhost:8080/api/nodes with a body in the same format as above, but ID must exist.  (DELETE) http://localhost:8080/api/nodes/1