FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EmployeeApp.Backend.API/EmployeeApp.Backend.API.csproj", "EmployeeApp.Backend.API/"]
COPY ["EmployeeApp.Backend.AppCore/EmployeeApp.Backend.AppCore.csproj", "EmployeeApp.Backend.AppCore/"]
COPY ["EmployeeApp.Backend.Domain/EmployeeApp.Backend.Domain.csproj", "EmployeeApp.Backend.Domain/"]
COPY ["EmployeeApp.Backend.Infrastructure/EmployeeApp.Backend.Infrastructure.csproj", "EmployeeApp.Backend.Infrastructure/"]
RUN dotnet restore "EmployeeApp.Backend.API/EmployeeApp.Backend.API.csproj"
COPY . .
WORKDIR "/src/EmployeeApp.Backend.API"
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EmployeeApp.Backend.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EmployeeApp.Backend.API.dll"]
