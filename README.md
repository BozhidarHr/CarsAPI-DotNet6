<h1>Cars API</h1>

This project is a RESTful API that connects to a database and allows the execution of CRUD operations.

1. Download & install Microsoft SQL server <b>express</b> at https://www.microsoft.com/en-us/sql-server/sql-server-downloads
2. Clone the repository to Visual Studio
3. Install EF - ```dotnet tool install --global dotnet-ef```
4. Run migrations - ```dotnet ef migrations add migrations```
5. Run ```dotnet ef database update```
6. Run the server - ```dotnet run```

<b>Note! Whenever making POST requests, make sure to exclude the "id" field.</b>
