#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EC.CRM.Backend.API/EC.CRM.Backend.API.csproj", "EC.CRM.Backend.API/"]
RUN dotnet restore "./EC.CRM.Backend.API/./EC.CRM.Backend.API.csproj"
COPY . .
WORKDIR "/src/EC.CRM.Backend.API"
RUN dotnet build "./EC.CRM.Backend.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EC.CRM.Backend.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EC.CRM.Backend.API.dll"]