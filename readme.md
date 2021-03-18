
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



### Execute migrations

```bash
dotnet ef database -v update  --startup-project src/Web.API
```

### Generate SQL Scripts

