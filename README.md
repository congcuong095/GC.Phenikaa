
- .Net 8.0
- SqlServer
- Postgre

------------
run code
- install dotnet tool: dotnet tool restore
- Run husky: dotnet husky install
             dotnet husky add pre-commit -c "dotnet husky run"
- run before commit : dotnet csharpier .

migration
- add migration (cd to Admin.Infrastructure.SqlServer): dotnet ef migrations add v1 --startup-project ..\Admin.API\Admin.API.csproj
- update db (cd to Admin.Infrastructure.SqlServer): dotnet ef database update --startup-project ..\Admin.API\Admin.API.csproj