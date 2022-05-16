# Book Store

A RESTful API example implemented using .NET 6.0

## Build

```
$ dotnet build
```

## Build container image

```
docker build -t book-store-api .
```

## Run App (in container)
```
$ docker run -p 80:80 book-store-api sh -c /code/publish/BookStore.Api
```

## Run Integration Tests (within docker compose network)
```
$ docker exec test-runner dotnet test --no-restore --output /code/artifacts/bin/Release/net6.0/linux-musl-x64
```