# Hahn.ApplicatonProcess.Application
 
## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (version 16.5.4 or later)
* [.NET Core SDK 3](https://dotnet.microsoft.com/download/dotnet-core/3.1) (SDK 3.1.301)
* [Node.js](https://nodejs.org/en/) (version 12.3.1 or later) with npm (version 6.14.4 or later)

* for Linux it might be necessary to install the libwkhtmltox library (https://wkhtmltopdf.org/downloads.html)
* for PDF generation from MS Word files is might be necessary to install LibreOffice

### Setup for development
Follow these steps to get your development environment set up:

  0. Database connection is set in appsettings.json. Alternatively, you can set environment variable HahnApplicatonProcessConnectionString with value `Server=localhost\\MSSQLSERVER02;Database=HahnApplicationProcessDb;Trusted_Connection=True;`. 
     In production use proper user and password.
     Under Windows, go to computer advanced settings, `Environment variables` and add environment variable. Under Linux, use CLI `export` command do add that environment variable.
  1. Clone the repository
  2. Build the solution by running:
     dotnet build
  3. It is not necessary to run dotnet restore as dotnet build or dotnet run will do that 
  4. If necessary, publish the solution by running:
     dotnet publish Hahn.ApplicatonProcess.Application\Hahn.ApplicatonProcess.December2020.Api.csproj -c Release -o "output directory"

  5. Next, within the `Hahn.ApplicatonProcess.December2020.Api.Web` directory, launch the front end by running:
     npm install && npm run build
     npm run start

  6. During the deployment process, you must specify some configuration parameters for backend.
     You can provide them by modifying the appsettings.json file or through environment variables.
     
     If you decided to modify appsettings.json file:
     Replace "ConnectionStrings" parameter with valid database connection string.

     If you decided to use environment variables:
     Provide valid database connection string through "InfoBonConnectionString__PGSQL" environment variable.

  7. Once the front end has started, launch the back end API by running:
     dotnet Hahn.ApplicatonProcess.December2020.Api.dll

  8. Launch [https://localhost:4200/](http://localhost:4200/) in your browser to view the Web UI
  
  10. Launch [https://localhost:44300/api] in your browser to view the API
  Launch [https://localhost:44300/api](https://localhost:44300/swagger/v1/swagger.json) in your browser to view the API Swagger UI tool.

### Database migrations
In order to add a database migration, in Visual Studio open Package Manager Console run:
```
Add-Migration -Context HahnApplicationProcessDbContext -s Hahn.ApplicatonProcess.Application -p Hahn.ApplicatonProcess.December2020.Persistence <MigrationName>
```

If you prefer command line then go to solution root and run:
```
dotnet ef migrations add -c HahnApplicationProcessDbContext -s Hahn.ApplicatonProcess.Application -p Hahn.ApplicatonProcess.December2020.Persistence <MigrationName>
```

To update the database, in Visual Studio open Package Manager Console, select Hahn.ApplicatonProcess.December2020.Persistence as default project, then run:
```
Update-Database -Context HahnApplicationProcessDbContext -s Hahn.ApplicatonProcess.Application -p Hahn.ApplicatonProcess.December2020.Persistence
```

If you prefer command line then go to solution root and run:
```
dotnet ef database update -c HahnApplicationProcessDbContext -s Hahn.ApplicatonProcess.Application -p Hahn.ApplicatonProcess.December2020.Persistence
```

## Technologies
* .NET Core 3.1
* .NET Standart 2.1
* Entity Framework Core 5.0.2
* Automapper for automated mapping of objects
* Autofac for services registration (along with Microsoft's dependency injection container)
* MediatR for CQRS pattern request/handler/response
* Serilog 2.10.0


# Development
Under Linux, in case you encounter errors like 
```
"the configured user limit (128) on the number of inotify instances has been reached"
```

then use the following commands to deal with it (requires sudo):
```
echo fs.inotify.max_user_watches=524288 | sudo tee -a /etc/sysctl.conf && sudo sysctl -p
echo fs.inotify.max_user_instances=524288 | sudo tee -a /etc/sysctl.conf && sudo sysctl -p
```

If you encounter difficulties setting up PostgreSQL under Linux, see https://itsfoss.com/install-postgresql-ubuntu/.

Under Linux, in case you want a batch update of libraries, you can use https://github.com/dotnet-outdated/dotnet-outdated tool

If batch update of WebUI project libs is required, run
```
sudo npm i -g npm-check-updates
ncu
ncu �u
npm i
```



## Back-end

THe Hahn.ApplicatonProcess.December2020.Api project controlles should not contain any logic and only call the Application through requests.
The Application is where project logic is contained.
The Application calls database context only through requests, thus being loosely coupled with database.

