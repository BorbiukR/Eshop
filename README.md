# Eshop with 3 roles
The application simulates the work of an online store.

1. Provides the following roles and functionality:

1.1. The role of the "Guest". Features:
- view the list of goods;
- search for goods by name;
- registration of the user's burn record;
- Login to the online store with an account.

1.2. The role of "Registered user". Features:
- view the list of goods;
- search for goods by name;
- creation of a new order;
- ordering or cancellation;
- view the history of orders and the status of their delivery;
- setting the status of the order "Received";
- change of personal information;
- sign out of your account.

1.3.Role "Administrator". Features:
- view the list of goods;
- search for goods by name;
- creation of a new order;
- ordering;
- view and change personal information of users;
- adding a new product (name, category, description, cost);
- change of information about the product;
- change of refractive status;
- sign out of your account.

2. When creating a new order, the status "New" is automatically set.
All other statuses are set manually by the administrator: “Canceled
administrator "," Payment received "," Sent "," Received ",
"Completed." In addition to "Canceled by the user" - set by the user
to "Received".

3. Incorrect user actions are provided

- Implemented Multilayered architecture (DAL + BLL + Web API)
