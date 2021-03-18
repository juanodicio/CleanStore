# CleanStore


## Code Coverage

First, add the following dependencies to your test project
```xml
<ItemGroup>
    <PackageReference Include="coverlet.msbuild" Version="3.0.3" />
    <PackageReference Include="coverlet.collector" Version="1.3.0" />
</ItemGroup>
```

Install ReportGenerator as a global tool
```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```


Run tests and generate report in cobertura format
```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:Exclude="[xunit*]\*" /p:CoverletOutput="./TestResults/"
```

Use cobertura report to generate HTML report
```bash
reportgenerator "-reports:tests/Application.UnitTests/TestResults/coverage.cobertura.xml" "-targetdir:coverage-reports/html" -reporttypes:HTML;
```


## Database Migrations


### Create migrations
To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

* `--project src/Infrastructure` (optional if in this folder)
* `--startup-project src/Web.API`
* `--output-dir Persistence/Migrations`

For example, to add a new migration from the root folder:

```bash
dotnet ef migrations add "Initial" --project src/Infrastructure --startup-project src/Web.API --output-dir Persistence/Migrations
```

### List Migrations

```bash
dotnet ef migrations list  --startup-project src/Web.API 
```


### Update your database to the latest migration

```bash
dotnet ef database update  --startup-project src/Web.API
```

### Updates your database to a given migration

```bash
dotnet ef database update Initial  --startup-project src/Web.API 
```

### Generate SQL Scripts from

Generate SQL Script from "Initial" migration but without including "Initial"
```bash
dotnet ef migrations script Initial --startup-project src/Web.API
```

Generate SQL Script from "ProdDesc" (excluding) to "ProdStock" (including) 
```bash
dotnet ef migrations script ProdDesc ProdStock  --startup-project src/Web.API 
```

Idempotent SQL Script
```bash
dotnet ef migrations script Initial --idempotent --startup-project src/Web.API
```