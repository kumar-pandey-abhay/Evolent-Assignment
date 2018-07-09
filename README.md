# Evolent-Assignment

Web Api for Contact information.

Token based authentication used

web api application for accessing the functions.

to generate the tokens localhost/port/token

to access the Get All Contact: http://localhost:54761/api/contact/GetAll (Showing only active status contact)

to access add: api/contact/AddContact

JSON 
 "FirstName": "Shubham",
 
 "LastName": "Jain",
 "Email": "sj@test.com",
 
 "PhoneNumber": "4564564",

to access update : api/contact/UpdateContact
 "Id":1,
 "FirstName": "Shubham",
 
 "LastName": "Jain",
 "Email": "sj@test.com",
 
 "PhoneNumber": "4564564",

to access update status api/contact/UpdateStatus
 "Id":1,
 "Suatus":false



Followed Onion architecture.
Projects in the Solution

WebApi	
Service: have logic for the database operation exposed to the Web api
Repository: Have generic repository that take care of all the entity add update operation exposed to the services
Entities: Have the entity modal (Used Fluent apli for entity creation)
Common: Have common business model classes an common code for application




