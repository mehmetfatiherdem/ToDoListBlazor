# Blazor ToDo List App 
A todo app made with .NET, Blazor and MSSQL Server(localdb).

To Run The Project
1- Clone the repo
```sh
git clone https://github.com/mehmetfatiherdem/ToDoListBlazor.git
cd ToDoListBlazor
```
2- Open the sln file with Visual Studio or Rider

3- Install [Automapper](https://www.nuget.org/packages/AutoMapper/12.0.1), [AutoMapper.Extensions.Microsoft.DependencyInjection](https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/12.0.0), [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/7.0.4), [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/7.0.4) and [Microsoft.EntityFrameworkCore.SqlServer ](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/7.0.4) NuGet Packages.

4- Open Package Manager Console
```sh
cd ToDoList
dotnet ef database update
```

5- Run the Project
