#------------------------------------------------------------------------------------------------------------------------
#
# USAGE:        This Dockerfile builds the sample for hosting application inside of Kubernetes Cluster.
#
# NOTE:         Please run commands from root of the solution.
#
# BUILD:        docker build --rm -f "Console.Di/Dockerfile" -t app:Console.Di .
#
#
# NOTE:        See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#------------------------------------------------------------------------------------------------------------------------

FROM mcr.microsoft.com/dotnet/runtime:6.0-bullseye-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
COPY ["Console.Di/Console.Di.csproj", "Console.Di/"]
RUN dotnet restore "Console.Di/Console.Di.csproj"
COPY . .
WORKDIR "/src/Console.Di"
RUN dotnet build "Console.Di.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Console.Di.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Console.Di.dll"]
