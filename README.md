
- .Net 8.0
- SqlServer
- Postgre

------------
run code
- install dotnet tool: dotnet tool restore
- Run husky: dotnet husky install
- add migration (cd to Admin.Infrastructure.SqlServer): dotnet ef migrations add v1 --startup-project ..\Admin.API\Admin.API.csproj
- update db (cd to Admin.Infrastructure.SqlServer): dotnet ef database update --startup-project ..\Admin.API\Admin.API.csproj
- run before commit : dotnet csharpier .