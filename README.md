#### Migrate
Утилита миграции БД.

Создание миграции
```shell
dotnet ef migrations add NameOfNewMigration --project src\Store.Migrations --context ResourceContext
```
Обновление схемы БД
```shell
dotnet ef database update --project src/Store.Migrations --context ResourceContext
```
Удаление миграции
```shell
dotnet ef database remove NameOfMigration --project src/Store.Migrations --context ResourceContext
-- NameOfMigration если не указывать, удаляет последнюю миграцию.
```
