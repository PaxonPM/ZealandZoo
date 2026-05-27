# Zealand Zoo Event Application

This project is an event application for Zealand Zoo.  
The application is used to show and manage events, opening hours and related information.

## Download the project

The project can be downloaded from GitHub.

### Option 1: Download as ZIP
1. Click the green **Code** button.
2. Click **Download ZIP**.
3. Extract the ZIP file.
4. Open the project folder in your IDE.

### Option 2: Clone with Git

Open a terminal and run:

```bash
git clone https://github.com/PaxonPM/ZealandZoo.git
```

Then open the project folder in your IDE.

## Set up the local database

Before running the project, a local database must be created.

1. Open your database program, for example SQL Server Management Studio.
2. Create a new local database.
3. Find the database generator text file in the project.
4. Copy the SQL from the database generator text file.
5. Run the SQL script in your local database.

The script will create the needed tables and data for the project.

## Update the database connection

After creating the local database, the database connection in the project must be updated.

1. Open the project in your IDE.
2. Find the `DBConnectionHelper` file.
3. Update the datasource / connection string so it matches your local database.

Example:

```csharp
var builder = new SqlConnectionStringBuilder
{
    DataSource = @"PAX-LAPTOP\SQLEXPRESS", 
    InitialCatalog = "dev_ZealandZoo_0_8",
    TrustServerCertificate = true,
    IntegratedSecurity = true // For Windows Auth
};
```

Where it is the `Datasource` that needs to be changed to your local server.

## Run the project

After the database has been created and the connection string has been updated:

1. Build the project.
2. Run the application from your IDE.
3. The application should now connect to the local database.

## Troubleshooting

If the application cannot connect to the database, check the following:

- The local database has been created.
- The SQL script from the database generator text file has been run.
- The database name in the connection string is correct.
- The server name in the connection string is correct.
- SQL Server is running on your computer.
