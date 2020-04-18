# Blazor server app with authentication, but without using EntityFramework

### This is based off the Visual studio generated app, but with the following changes

1. Does not use EntityFramework. The user store is trivial and allows anyone to login, this is just a test application
2. Logins are allowed as long as user name and password match. For example, UserName: admin Password admin
3. If the user name starts with admin then the role "admin" is added to the current user 
4. The fetch data functionality is hidden if the user does not have the "admin" role 
5. You have to login before any of the UI is accessible

