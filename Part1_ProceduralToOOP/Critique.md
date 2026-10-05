# Critique of the Procedural C++ Order System

## 1. Global Variables
The program stores all customers, products, orders, and order lines in global variables.
Any function can access and modify this data directly, which makes the program difficult to control and maintain.

## 2. Parallel Arrays
Customer data is split across multiple arrays such as `customerIds`, `customerNames`, `customerEmails`, and `customerCities`.
All arrays must always use the same index for the same customer. If they become out of sync, the data will be incorrect.

## 3. No Classes
There are no classes for Customer, Product, Order, or OrderLine.
The data and the operations related to it are separated into different functions instead of being grouped together.

## 4. Functions Directly Modify Shared Data
Functions such as `addLineToOrder()` directly modify global arrays such as `productStock`, `orderLineCounts`, and `lineQuantities`.
This makes the code tightly dependent on how the data is stored.