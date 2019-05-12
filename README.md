# Ushin Services (ushinsvc)
11 May 2019
Jose Durazo

This is a clean .NET Core app starting with the webapi template.
Also adds the JsonApiDotNetCore package.
The app is Dockerized.
No Ushin related services are present at this time.
To build: docker build -t ushinsvc .
To run: docker run -d -p 8080:80 --name ushinsvc ushinsvc
To test: load http://localhost:80/api/values
No Ushin schema is behind this, but it successfully returns ["value1", "value2"].

This is meant to be just a clean starting point from which the real services can be implemented.

The initial goal is to implement services that support CRUD operations on Users and Nodes for the  U4U Application.
