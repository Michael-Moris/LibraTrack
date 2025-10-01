# 📚 LibraTrack

A **Library Management System** built with **ASP.NET Core 9** and **Entity Framework Core**.  
It helps libraries manage **books, authors, categories, members, loans, and fines** efficiently.

---

## 🚀 Features
- 📖 Manage Books (CRUD with categories and authors)
- 👥 Manage Members (registration, status: Active/Suspended)
- 📂 Categories & Authors management
- 📅 Borrow & Return system with due dates
- 💰 Automatic Fine calculation for overdue/damaged books
- 🔍 Search books by title, author, or category
- 🗃 Database Seeding from JSON (Authors, Books, Categories, Members)

---

## 🛠️ Tech Stack
- **Backend:** ASP.NET Core 9, EF Core
- **Database:** SQL Server
- **ORM:** Entity Framework Core (Code-First + Migrations)
- **Seeding:** JSON Seeder & `LibraryDbContextSeed`
- **Helpers:** LoanManagement for borrowing/returning logic

---

## 📂 Project Structure
```
LibraTrack/
│
├── Configurations/ # Entity configs (Fluent API)
├── Context/ # DbContext & Seed
├── Helper/ # JsonSeeder & LoanManagement
├── Models/ # Entities + Enums
├── Migrations/ # EF Core migrations
└── Program.cs
```

---

## ⚡ Getting Started

### 1️⃣ Clone the Repo
```bash
git clone https://github.com/Michael-Moris/LibraTrack.git
cd LibraTrack
```

### 2️⃣ Open the Project
Open the solution in Visual Studio or VS Code.

Make sure you have .NET 9 SDK and SQL Server installed.

### 3️⃣ Apply Database Migrations
```bash
# Using .NET CLI
dotnet ef database update

# Or inside Visual Studio Package Manager Console
Update-Database
```

### 4️⃣ Seed & Test the Project
>... The project includes JSON seeding for Authors, Books, Categories, and Members.

>... To test features (borrowing, returning, fines, etc.), uncomment or add code in Program.cs and run.

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!
Feel free to fork the project and submit a pull request.
