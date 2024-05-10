Para criar uma migração após alterar as entidades, execute o comando abaixo:

```bash
dotnet ef migrations add NomeDaMigração -c ErisStoreDbContext -o .\Data\Migrations\ -s ..\API\
```

Para atualizar o banco de dados com as migrações, execute o comando abaixo:

```bash
dotnet ef database update -c ErisStoreDbContext -s ..\API\
```

Para reverter a última migração, execute o comando abaixo:

```bash
dotnet ef migrations remove -c ErisStoreDbContext -s ..\API\
```

Para reverter todas as migrações, execute o comando abaixo:

```bash
dotnet ef database update 0 -c ErisStoreDbContext -s ..\API\
```

Para adicionar um novo contexto, execute o comando abaixo:
utilizando postgres
```bash
dotnet ef dbcontext scaffold "Host=localhost;Database=protechanimesdb;Username=postgres;Password=postgres" Npgsql.EntityFrameworkCore.PostgreSQL -c ErisStoreDbContext -o Entities -f
```
-c é o nome do contexto 

-o é o caminho onde os arquivos serão gerados

-f é para forçar a sobrescrita dos arquivos
