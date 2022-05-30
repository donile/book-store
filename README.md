# Book Store

A RESTful API example implemented using .NET 6.0

## Build

```
$ dotnet build
```


## Build container image

```
docker build -t book-store-api --target app .
```


## Run App (in container)
```
$ docker run -p 80:80 book-store-api sh -c /code/publish/BookStore.Api
```


## Run Integration Tests (within docker compose network)

```
$ docker exec test-runner dotnet test /code/artifacts/BookStore.Api.Tests.Integration/bin/Release/net6.0/BookStore.Api.Tests.Integration.dll
```


## Apply Database Migration

```
$ docker exec db-migrator evolve migrate postgresql -c "Server=postgres;Database=postgres;User Id=postgres;Password=postgres;" -l "db/migrations"
```


## Dependencies (to be added to DevContainer in the future)

[evolve (CLI)](https://evolve-db.netlify.app/getting-started/cli/)
