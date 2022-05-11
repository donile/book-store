FROM mcr.microsoft.com/dotnet/sdk:6.0.300-alpine3.15 AS builder
WORKDIR /code
COPY BookStore.sln BookStore.sln
COPY Directory.Build.props Directory.Build.props
COPY ./src/BookStore.Api/BookStore.Api.csproj ./src/BookStore.Api/BookStore.Api.csproj 
COPY ./test/BookStore.Api.Tests.Integration/BookStore.Api.Tests.Integration.csproj ./test/BookStore.Api.Tests.Integration/BookStore.Api.Tests.Integration.csproj
RUN dotnet restore
COPY ./src ./src
COPY ./test ./test
RUN dotnet build --no-restore
