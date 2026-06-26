# KEP

A Windows Forms application for basic citizen request management in a Citizen Service Center (KEP). The application stores requests in a local SQLite database and supports creating, viewing, searching, deleting, updating, and exporting requests to text files.

## Features

- Create a new citizen request with ID, full name, email, phone number, date of birth, request type, and address.
- View all submitted requests in a table.
- Search for requests by citizen full name.
- Delete existing requests.
- Edit request details through an update form.
- Export a selected request to an `Aitima_<FullName>.txt` file.
- Automatically create the SQLite database `aitimatadb.db` on startup if it does not already exist.

## Technologies

- C#
- Windows Forms
- .NET Framework 4.7.2
- SQLite
- Entity Framework 6
- NuGet `packages.config`

## Requirements

- Windows
- Visual Studio 2019 or newer with the .NET desktop development workload
- .NET Framework 4.7.2 Developer Pack
- NuGet package restore enabled in Visual Studio

## Setup and Run

1. Clone the repository:

   ```powershell
   git clone <repository-url>
   cd KEP
   ```

2. Open `KEP.sln` in Visual Studio.

3. Restore NuGet packages if they are not restored automatically:

   ```powershell
   nuget restore KEP.sln
   ```

4. Build and run the project from Visual Studio.

On first launch, the application automatically creates the `aitimatadb.db` database in the application output directory.

## Project Structure

```text
KEP/
├── KEP.sln
├── KEP/
│   ├── Program.cs
│   ├── DatabaseHelper.cs
│   ├── Class1.cs
│   ├── Class2.cs
│   ├── Form1.cs
│   ├── Form2.cs
│   ├── Form3.cs
│   ├── App.config
│   └── packages.config
└── README.md
```

## GitHub Notes

The repository does not include `bin/`, `obj/`, `.vs/`, or `packages/` folders. These are local Visual Studio files, build outputs, or NuGet packages, and they can be regenerated with package restore and build.

The local SQLite database and exported request text files are also ignored through `.gitignore`, so personal or test data is not committed to the repository.
