# Stage 1: Base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
ARG APP_UID=1000
USER $APP_UID
WORKDIR /app
EXPOSE 8080

# Stage 2: Build image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["ShopClickDrive.API/ShopClickDrive.API.csproj", "ShopClickDrive.API/"]
COPY ["ShopClickDrive.Application/ShopClickDrive.Application.csproj", "ShopClickDrive.Application/"]
COPY ["ShopClickDrive.Core/ShopClickDrive.Core.csproj", "ShopClickDrive.Core/"]
COPY ["ShopClickDrive.Infrastructure/ShopClickDrive.Infrastructure.csproj", "ShopClickDrive.Infrastructure/"]
COPY ["ShopClickDrive.InventoryManagement/ShopClickDrive.InventoryManagement.csproj", "ShopClickDrive.InventoryManagement/"]
COPY ["ShopClickDrive.LeadManagement/ShopClickDrive.LeadManagement.csproj", "ShopClickDrive.LeadManagement/"] # New Project

# Restore dependencies
RUN dotnet restore "ShopClickDrive.API/ShopClickDrive.API.csproj"

# Copy the entire source and build
COPY . .
WORKDIR "/src/ShopClickDrive.API"
RUN dotnet build "ShopClickDrive.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish image
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ShopClickDrive.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopClickDrive.API.dll"]