# 🏥 Hospital Management System (ASP.NET MVC)

This is a simple Hospital Management System built using **ASP.NET MVC**. It allows the management of **Patients** and their associated **Appointments** using a ViewModel-centric approach with dynamic add/delete functionality in the UI.

---

## 🚀 Features

- **CRUD operations** for patients
- Manage **appointments dynamically** during create/edit actions
- ViewModel support (`PatientVM`) to simplify and structure data passing between View and Controller
- Appointment list add/delete handled with `Operation` string
- Entity Framework used for database operations

---

## 📁 Project Structure

- `ViewModel/PatientVM.cs`  
  Contains the ViewModel for patients, including transformation logic between the model and view model.

- `Controllers/PatientsController.cs`  
  Handles all patient-related actions including Create, Read, Update, and Delete. Also includes dynamic appointment list operations.

---

## 💡 How It Works

### Patient Creation
- On Create: Adds/removes appointments on-the-fly using the `Operation` field (e.g., `Add`, `Delete-0`).
- Converts `PatientVM` to `Patient` before saving.

### Patient Editing
- Deletes existing patient and re-saves updated patient with new appointments.
- Ensures appointment consistency.

---

## 🛠️ Tech Stack

- **ASP.NET MVC 5**
- **Entity Framework 6**
- **C#**
- **Razor Views**

---
