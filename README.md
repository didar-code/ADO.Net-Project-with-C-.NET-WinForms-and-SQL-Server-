# 🏢 Property Sales Management System

A professional desktop-based property sales management application developed using **C#**, **.NET WinForms**, **ADO.NET**, and **SQL Server**.  
The system is designed to simplify property sales operations by managing client records, payment information, and generating dynamic reports for real estate businesses.

---

## 🚀 Key Features
<img width="901" height="547" alt="Ado" src="https://github.com/user-attachments/assets/0067dde8-a0a6-493f-a914-a9095603298a" />

- ✅ Add, update, and delete property sales records  
- 👤 Manage client information (name, mobile number, address, etc.)  
- 💰 Track payment methods and payment status (Paid / Unpaid)  
- 📅 Select and manage sales dates  
- 🖼 Attach client images  
- 📊 Display dynamic sales records with edit/delete functionality  
- 📈 Generate Crystal Reports:
  - Property Information Report  
  - Sales Information Report  
- 🗄 SQL Server integration with:
  - Stored Procedures  
  - Views  
- 🧩 Layered project architecture for maintainability  

---

## 🛠 Technology Stack
<img width="1599" height="854" alt="Ado_report" src="https://github.com/user-attachments/assets/c7200ad8-28c7-407e-bbc1-ec78eef154db" />

| Technology | Purpose |
|-----------|---------|
| C# | Application logic |
| .NET WinForms | Desktop UI |
| SQL Server | Database management |
| ADO.NET | Data access |
| Crystal Reports | Reporting |

---

## 🧱 Project Architecture

The project follows a layered architecture:

- **DAL (Data Access Layer)** → Handles database operations  
- **Entities** → Domain models  
- **Repositories** → Business data handling  
- **ViewModels** → UI data binding  
- **Reports** → Crystal Reports files  
- **RPTViewers** → Report display forms  

---

## 📂 Project Structure
<img width="1599" height="753" alt="Ado_code" src="https://github.com/user-attachments/assets/dd1cc842-f2c3-4706-b38c-de04a0103598" />
---
PropertySalesManagementSystem/
│
├── DAL/
│   └── SalesGateWay.cs
│
├── Entities/
│   ├── PaymentMethod.cs
│   ├── Property.cs
│   └── Sale.cs
│
├── Reports/
│   ├── PropertyInfo.rpt
│   └── RPTSalesInfo.rpt
│
├── Repositories/
│
├── RPTViewers/
│   └── FrmRptViewer.cs
│
├── ViewModels/
│
├── Form1.cs
├── Program.cs
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
   git clone (https://github.com/didar-code/ADO.Net-Project-with-C-.NET-WinForms-and-SQL-Server).git

   Open the solution

2.Double-click 1292886_PropertySales.sln in Visual Studio

3.Configure Database

4.Update connection string in AppConfig

5.Run the provided SQL script (if included) to create database and tables

6.Build & Run

7.Press F5 to build and run the application
## 📦 Run from ZIP File

If you do not want to clone the repository, you can also download and run the project from a ZIP file.

### Steps

1. Click the **Code** button on GitHub.
2. Select **Download ZIP**.
3. Extract the ZIP file to your computer.
4. Open the extracted folder.
5. Double-click the solution file:

```text
1292886_PropertySales.sln
