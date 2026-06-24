# DVLD - Driving & Vehicle License Department

A desktop application for managing driving licenses and related services using a 3-Tier Architecture approach.

## Overview

DVLD (Driving & Vehicle License Department) is a Windows Forms application that simulates the workflow of a real driving license department. The system manages people, users, driving license applications, tests, licenses, international licenses, and detained licenses.

The project is built using:

* C#
* Windows Forms
* SQL Server
* ADO.NET
* 3-Tier Architecture

---

## Architecture

The solution follows a 3-Tier Architecture:

### Presentation Layer

Responsible for the user interface and user interactions.

### Business Layer

Contains business rules, validations, and application logic.

### Data Access Layer

Handles communication with SQL Server using ADO.NET.

---

## Features

### People Management

* Add new person
* Update person information
* Delete person
* Search by National Number
* View people list

### Users Management

* Create users
* Update users
* Delete users
* User permissions
* Login system

### Driving License Applications

* New driving license application
* Retake test application
* License renewal application
* Replacement for lost license
* Replacement for damaged license
* International license application
* Release detained license application

### Tests Management

* Vision Test
* Written Test
* Practical Driving Test
* Schedule appointments
* Record test results

### Licenses Management

* Issue driving license
* Renew license
* Replace lost license
* Replace damaged license
* Search licenses
* View license history

### International Licenses

* Issue international license
* Track international licenses

### Detained Licenses

* Detain license
* Release detained license
* Track detention history

---

## Database

Main entities:

* Countries
* People
* Users
* ApplicationTypes
* Applications
* LocalDrivingLicenseApplications
* LicenseClasses
* TestTypes
* TestAppointments
* Tests
* Drivers
* Licenses
* InternationalLicenses
* DetainedLicenses

---

## Technologies Used

| Technology   | Purpose                 |
| ------------ | ----------------------- |
| C#           | Application Development |
| WinForms     | User Interface          |
| SQL Server   | Database                |
| ADO.NET      | Database Connectivity   |
| Git & GitHub | Version Control         |

---

## Project Structure

```text
src/
│
├── DVLD.sln
│
├── DVLD_Presentation_Layer
│
├── DVLD_Business_Layer
│
└── DVLD_DataAccess_Layer
```

---

## Screenshots

Screenshots will be added after implementing the system modules.

---

## Future Improvements

* Reporting System
* Dashboard and Statistics
* Role-Based Permissions
* Logging and Auditing
* Export to PDF
* Backup and Restore Database

---

## Author

Abdo Walid

---

## License

This project is developed for learning purposes and educational practice.
