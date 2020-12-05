#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["console.di/console.di.csproj", "console.di/"]
RUN dotnet restore "console.di/console.di.csproj"
COPY . .
WORKDIR "/src/console.di"
RUN dotnet build "console.di.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "console.di.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "console.di.dll"]