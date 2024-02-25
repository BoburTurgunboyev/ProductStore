# ProductStore
This project is built on Windows 11 OS.

## Prerequisite
- [.NET SDK 7.0](https://dotnet.microsoft.com/download)
- [SQL SERVER](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

## Getting started
1. Cloning the repository
   ``https://github.com/BoburTurgunboyev/app.git``

2. Navigate to the project folder:

   `` cd your-project-name ``
3.  Write on the terminal this code first
   `` dotnet-build
      dotnet restore ``

4. Database setup:
   - Create a SQL Server database for the project.
   - Update  the project's appsetting.json file according to your DB configuration (login, password)
     ``   {
         "ConnectionStrings": {
                "DefaultConnection": "Data Source=(localdb)\\ProjectModels;Initial Catalog=TestDb;Integrated Security=True;"
                 },
            // other settings...
          }  ``
5. Run migrations:
   `` add-migration  "InitialMigration"
   ``
6. Run the Application
   `` dotnet run ``

7.  ... other steps can continue user's themself

## Acknowledgements
  Mentioning any libraries, changes or tools is always welcome.
