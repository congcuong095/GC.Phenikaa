# Requirements
- .Net 8.0

------------
# Base installation
- install dotnet tool: dotnet tool restore
- Run husky: dotnet husky install

-------------------------


- run before commit : dotnet csharpier .

migration
- add migration (cd to Infrastructure.DBAgent.Postgre): dotnet ef migrations add v1 --startup-project ..\..\4.API\API\API.csproj
- update db (cd to Infrastructure.DBAgent.Postgre): dotnet ef database update --startup-project ..\..\4.API\API\API.csproj