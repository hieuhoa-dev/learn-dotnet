# ==============================
# 1. Build stage
# ==============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj và restore trước (tối ưu cache)
COPY *.sln .
COPY LearnDotnetCore/*.csproj ./LearnDotnetCore/
RUN dotnet restore

# Copy toàn bộ và build
COPY . .
WORKDIR /src/LearnDotnetCore
RUN dotnet publish -c Release -o /app/publish

# ==============================
# 2. Runtime stage
# ==============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Thiết lập biến môi trường (ConnectionString tới SQL Server container)
ENV ConnectionStrings__DefaultConnection="Server=sqlserver;Database=MyDb;User Id=sa;Password=Your_password123;TrustServerCertificate=True;"

EXPOSE 8080
ENTRYPOINT ["dotnet", "learn_dotnet_core.dll"]
