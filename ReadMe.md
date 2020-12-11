# .NetCore REST API Development Using Clean Architecture

## Project Setup In VSCode

Follow the steps below:

1. Create an empty project folder called **Blog**.
2. Create a solution inside the project folder. 
```c#
dotnet new sln
```
3. Create an **Api** project layer from root folder.
```c#
dotnet new webapi -o Blog.Api
```
4. Create a **Application** project layer from root folder.
```c#
dotnet new classlib -o Blog.Application
```
5. Create a **Domain** project layer from root folder.
```c#
dotnet new classlib -o Blog.Domain
```
6. Create an  **Infrastructure** project layer from root folder.
```c#
dotnet new classlib -o Blog.Infrastructure
```
7. Add three project layers to **Blog.sln** from root folder
```c#
dotnet sln Blog.sln add .\Blog.Api\Blog.Api.csproj .\Blog.Core\Blog.Core.csproj .\Blog.Infrastructure\Blog.Infrastructure.csproj
```
8. Link the **Application**, **Domain** and **Infrastructure** project layers to **Api** project.
 If you are in root project folder, use the following command.
```c#
dotnet add .\Blog.Api\Blog.Api.csproj reference .\Blog.Application\Blog.Application.csproj .\Blog.Domain\Blog.Domain.csproj .\Blog.Infrastructure\Blog.Infrastructure.csproj
```
9. Link the **Domain** layer to **Infrastructure** layer.
```c#
dotnet add .\Blog.Infrastructure\Blog.Infrastructure.csproj reference .\Blog.Domain\Blog.Domain.csproj
```
10. Link the **Infrastructure** layer **Domain** to  layer.
```c#
dotnet add .\Blog.Domain\Blog.Domain.csproj reference .\Blog.Infrastructure\Blog.Infrastructure.csproj
```

11. Run the project from root project folder.
```c#
dotnet run --project .\Blog.Api
```
12. To enable hot reload for development purpose use following command from root project folder.
```c#
dotnet watch  --project .\Blog.Api run
```
13. Add `.gitignore` file in root project folder.
```c#
dotnet new gitignore
```
[https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-application-layer-implementation-web-api]