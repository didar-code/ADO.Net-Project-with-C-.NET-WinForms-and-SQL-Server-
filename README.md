# 🏢 Property Sales Management System

A professional desktop application for managing property sales, client details, payments, and generating reports. Built with **C#**, **.NET WinForms**, and **SQL Server**, this system provides an intuitive interface for real estate agents and property managers.

---

## 📌 Features

- ✅ Add, edit, and delete property sales records
- 👤 Client information management (name, mobile, etc.)
- 💰 Payment type and status tracking (Paid / Unpaid)
- 📅 Sales date selection
- 🖼️ Client image attachment support
- 📊 Dynamic sales listing with edit/delete options
- 📈 Crystal Reports integration for:
  - Property Information Report
  - Sales Information Report
- 🗄️ SQL Server backend with stored procedures and views
- 🧩 Layered architecture:
  - Data Access Layer (DAL)
  - Entities
  - Repositories
  - ViewModels
  - Reports
  - RPTViewers

---

## 🖥️ Tech Stack

| Technology       | Usage                     |
|------------------|---------------------------|
| C#               | Business logic & UI       |
| .NET WinForms    | Desktop application       |
| SQL Server       | Database                  |
| Crystal Reports  | Reporting                 |
| ADO.NET          | Data access               |

---

## 📁 Project Structure
PropertySalesManagementSystem/
│
├── App.Data/ # Data context and configurations
├── DAL/ # Data Access Layer (Gateways)
│ └── SalesGateWay.cs
├── Entities/ # Domain models
│ ├── PaymentMethod.cs
│ ├── Property.cs
│ └── Sale.cs
├── Reports/ # Crystal Reports (.rpt)
│ ├── PropertyInfo.rpt
│ └── RPTSalesInfo.rpt
├── Repositories/ # Data repositories
├── RPTViewers/ # Report viewer forms
│ └── FrmRptViewer.cs
├── ViewModels/ # View models for binding
├── AppConfig/ # Configuration files
├── Form1.cs # Main form
├── Program.cs # Application entry point
└── README.md


---

## 🚀 Getting Started

### Prerequisites

- Visual Studio (2019 or later)
- .NET Framework 4.7.2 or above
- SQL Server (Express or Developer Edition)
- Crystal Reports Runtime (for report viewing)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/PropertySalesManagementSystem.git

   Open the solution

2.Double-click 1292886_PropertySales.sln in Visual Studio

3.Configure Database

4.Update connection string in AppConfig

5.Run the provided SQL script (if included) to create database and tables

6.Build & Run

7.Press F5 to build and run the application
