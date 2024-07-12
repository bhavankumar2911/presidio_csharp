# ATM System

## Table of Contents

1. [Introduction](#introduction)
2. [Technologies Used](#technologies-used)
3. [Functionalities](#functionalities)
   - [Withdraw](#withdraw)
   - [Deposit](#deposit)
   - [View Transaction History](#view-transaction-history)
   - [Check Balance](#check-balance)
4. [Contribution]

## Introduction

This project is an ATM system that allows users to perform basic banking operations such as withdrawing money, depositing money, viewing transaction history, and checking their balance. The frontend is built using HTML, CSS, and JavaScript, while the backend is developed using ASP.NET.

## Technologies Used

- _Frontend_: HTML, CSS, JavaScript
- _Backend_: ASP.NET
- _Database_: SQL Server

## Functionalities

### Withdraw

- _Inputs_: ATM Name, ATM Card Number, PIN, Withdrawal Amount
- _Conditions_:
  - The customer balance should be greater than the withdrawal amount.
  - Maximum withdrawal amount per transaction is 10,000.

### Deposit

- _Inputs_: ATM Card Number, PIN, Deposit Amount
- _Conditions_:
  - Maximum deposit amount per transaction is 10,000.

### View Transaction History

- _Inputs_: ATM Card Number, PIN

### Check Balance

- _Inputs_: ATM Card Number, PIN

### Contributors

- _BHAVAN KUMAR_: Worked on the frontend implementation of deposit,get balance responsiveness and integrating APIs.
- _SUBHASHINI S V_: Worked on the frontend implementation of withdrawl and responsiveness and integrating APIs.
- _SENADHIAN_: Designed the database schema, implemented repository, service layer(withdraw) and error handling for backend.
- _PAVITHRA_: Implemented the prerequisites setup for application, controller(withdraw, deposit) and service layer(deposit) for backend
- _ASWATHI S_: Implemented the transaction history feature, converting the application to docker image.
