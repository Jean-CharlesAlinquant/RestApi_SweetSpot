# InstaPay

Steps to setup the project.

## Create a solution file

```
dotnet new sln -o InstaPayApp
```

## src and tests directories

```
mkdir src
mkdir tests
```

## Create the Web API project

```
cd src
dotnet new webapi -o InstaPay.Api
```

## Create standard files

```
cd ..
dotnet new editorconfig
dotnet new globaljson
dotnet new gitignore
```

## Add the Web API project to the solution:

```
dotnet sln add **/**.csproj
```

## Add folders to API project

- Controllers
- Domain
- Persistence
- Services
