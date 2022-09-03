# Preview:
https://authapi-vfernandes.herokuapp.com/swagger
# Todo
 - Refresh token
 - Create roles for users
 - Unit tests




# AppSettings Sample
Change the configurations, for DbProvider possible values are SQLServer and PostgreSQL. \
Remember of create a appsettings.Production.json and a appsettings.Development.json
```json
{
    "JWT": {
      "Key" :  "afsdkjasjf5434234dlxswafsdklk434orqiwupadav313453123317u-34oew3234irroqwiffv48mfs"
    },
    "DbProvider":"SQLServer", 
    "ConnectionStrings": {
      "SqlServer": "Data Source=localhost;Initial Catalog=JWTAuthentication;Integrated Security=True;",
      "PostgreSQL": "Host=YourServer;Pooling=true;Database=YourDatabase;User Id=YourUser;Password=YourPassword;"
  
    },
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
      }
    }
  }
```
# Migrations
## Update database
It's necessary to apply the migrations to create the tables in your database. \
For SqlServer, change the DbProvider in appsettings for SQLServer and run:
```shell
dotnet ef database update  --project JWTAuthentication  --context SqlServerDbContext
```
For PostgreSQL, change the DbProvider in appsettings for PostgreSQL and run:
```shell
dotnet ef database update --project JWTAuthentication --context PostgreSQLDbContext 
```
## If you make any changes in the models
Create a new Migration for PostgreSQL:
```shell
dotnet ef migrations add YourMigrationName --project JWTAuthentication  --context PostgreSQLDbContext --output-dir Migrations/PostgreSqlMigrations --verbose
```
Create a new Migration for SqlServer:
```shell
dotnet ef migrations add YourMigrationName --project JWTAuthentication  --context SqlServerDbContext --output-dir Migrations/SqlServerlMigrations --verbose
```



 # Run in your machine
 - Install .NET 6 : https://dotnet.microsoft.com/en-us/download
 - Run an instance of SQL SERVER. https://www.microsoft.com/pt-br/sql-server/sql-server-downloads
 - Create an appsettings.Development.json and add (Here you can configure as you wish, but by default this should work):
 ```json
    "ConnectionStrings": {
        "DefaultConnection": "Data Source=localhost;Initial Catalog=JWTAuthentication;Integrated Security=True;"
    }
```
- Run the command :
```shell
dotnet ef database update
```
- Run the command 
```shell
dotnet run --project JWTAuthentication
```

# Publish to heroku
First we need a way to host a database server to use it in the project.\
You can create one for free using: https://www.elephantsql.com/\
If using a PostgreSQL server like the one before, you only need to create an appsettings.Production.json (use the appsettings sample) and change the PostgreSQL with your credentials.\
For other databases you need to configure the Program.cs.\
You will need to install docker:\
https://www.docker.com/products/docker-desktop/ \
And also the heroku CLI:\
https://devcenter.heroku.com/articles/heroku-cli \
Create an app in heroku and save its name, for example if your app url is : https://authapi-vfernandes.herokuapp.com/ it's name will be auth-api-vfernandes.\
Now run:
```shell
docker build -t auth-api .
```
Login to heroku:
```shell
heroku login 
```
Then login to it's container:
```shell
heroku container:login
```
Push the container to heroku:
```shell
heroku container:push web -a yourHerokuAppName
```
Publish it:
```shell
heroku container:release web -a yourHerokuAppName
```


