
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