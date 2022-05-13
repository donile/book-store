FROM mcr.microsoft.com/dotnet/sdk:6.0.300-alpine3.15 AS builder
WORKDIR /code
COPY BookStore.sln BookStore.sln
COPY Directory.Build.props Directory.Build.props
COPY ./src/BookStore.Api/BookStore.Api.csproj ./src/BookStore.Api/BookStore.Api.csproj 
COPY ./test/BookStore.Api.Tests.Integration/BookStore.Api.Tests.Integration.csproj ./test/BookStore.Api.Tests.Integration/BookStore.Api.Tests.Integration.csproj
RUN dotnet restore --runtime linux-musl-x64
COPY ./src ./src
COPY ./test ./test
RUN dotnet build ./src/BookStore.Api/BookStore.Api.csproj --no-restore --runtime linux-musl-x64 --self-contained true --configuration Release
RUN dotnet build ./test/BookStore.Api.Tests.Integration/BookStore.Api.Tests.Integration.csproj --no-restore --configuration Release
RUN dotnet publish ./src/BookStore.Api/BookStore.Api.csproj --no-build --runtime linux-musl-x64 --self-contained true --configuration Release

FROM mcr.microsoft.com/dotnet/runtime-deps:6.0.5-alpine3.15 AS app
WORKDIR /code
COPY --from=builder /code/artifacts/BookStore.Api/bin/Release/net6.0/linux-musl-x64/publish /code/publish
