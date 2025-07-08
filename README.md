# 🚗 Vehicle Tracking System

This project is a .NET 8-based microservice application designed to manage and track the real-time locations of vehicles. It follows the **Clean Architecture** principles and implements modern software development patterns such as **CQRS**, **MediatR**, **Dapper**, and **FluentValidation**.

---

## 🧰 Technologies Used

- ✅ **CQRS** (Command Query Responsibility Segregation)
- ✅ **MediatR** – For in-process messaging and command/query handling
- ✅ **FluentValidation** – For clean and structured input validation
- ✅ **Dapper** – Lightweight and high-performance ORM
- ✅ **Clean Architecture** – Modular and testable layer separation
- ✅ **.NET 8 Web API** – Modern backend web API framework

---

## 🎯 Project Features

- 🚙 Add / Update / Delete / List Vehicles
- 📍 Track and update vehicle location data
- 🧩 CQRS pattern implemented with MediatR
- ✅ Command validation via FluentValidation
- 💾 Efficient data access using Dapper
- 🧱 Fully modular architecture with the following layers:
  - **API**
  - **Application**
  - **Domain**
  - **Infrastructure**

---

## 📁 Project Structure
├── API # Controllers & API layer
├── Application # CQRS logic, DTOs, services, validation
├── Domain # Entities and business rules
├── Infrastructure # Data access, external services
├── README.md # Project documentation
