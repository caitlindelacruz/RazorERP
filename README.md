USER MANAGEMENT

Requirements:
- Admin should be able to list all users and perform CRUD
- User should only be able to list npn admin users


Endpoints:
1. POST api/login
    - login to get token to be able to use the endpoints

2. POST api/users (For admin role only)
    - create user

3. GET api/users/{id} (For admin role only)
    - get user with the given id

4. GET api/users (For admin role only)
    - list all users regardless of roles

5. GET api/users/non-admin
    - list all users with user role only

4. PUT api/users/{id} (For admin role only)
    - update user

5. DELETE api/users/{id} (For admin role only)
    - delete user with the given id

Database:
Run the script.sql located in the root folder
Database already has seeded users:

email: admin@company.com pw: Admin123. role: Admin

email: user@company.com pw: User123. role: User

email: guest@company.com pw: Guest123. role: User

To use endpoints:
1. Login with email and password
2. The login endpoint will return a token, use this token to authorize (upper right corner)
   Note: Add bearer before the token. Value should be: Bearer {token}




