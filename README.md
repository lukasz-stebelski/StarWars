# StarWars

1. Please download, restore missing nuget Packages and compile.
2. Target DB is defined in **appsettings.json** file. If needed change the target DB in all of them.
3. Run initial migrations to create sample DB as requested on the task:

*dotnet ef database update --project StarWars.Model*

4. For API needs start **StarWars.WebAPI** project.
5. For Web needs start **StarWars.Web** project.
