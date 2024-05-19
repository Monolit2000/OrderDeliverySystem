#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrderDeliverySystem.API/OrderDeliverySystem.API.csproj", "OrderDeliverySystem.API/"]
COPY ["Common/OrderDeliverySystem.CommonModule.Infrastructure/OrderDeliverySystem.CommonModule.Infrastructure.csproj", "Common/OrderDeliverySystem.CommonModule.Infrastructure/"]
COPY ["OrderDeliverySystem.CommonModule.Domain/OrderDeliverySystem.CommonModule.Domain.csproj", "OrderDeliverySystem.CommonModule.Domain/"]
COPY ["Modules/Basket/OrderDeliverySystem.Basket.Infrastructure/OrderDeliverySystem.Basket.Infrastructure.csproj", "Modules/Basket/OrderDeliverySystem.Basket.Infrastructure/"]
COPY ["Modules/UserAccess/OrderDeliverySystem.UserAccess.Infrastructure/OrderDeliverySystem.UserAccess.Infrastructure.csproj", "Modules/UserAccess/OrderDeliverySystem.UserAccess.Infrastructure/"]
COPY ["Modules/UserAccess/OrderDeliverySystem.UserAccess.Application/OrderDeliverySystem.UserAccess.Application.csproj", "Modules/UserAccess/OrderDeliverySystem.UserAccess.Application/"]
COPY ["Modules/UserAccess/OrderDeliverySystem.UserAccess.Domain/OrderDeliverySystem.UserAccess.Domain.csproj", "Modules/UserAccess/OrderDeliverySystem.UserAccess.Domain/"]
COPY ["Modules/UserAccess/OrderDeliverySystem.UserAccess.IntegrationEvents/OrderDeliverySystem.UserAccess.IntegrationEvents.csproj", "Modules/UserAccess/OrderDeliverySystem.UserAccess.IntegrationEvents/"]
COPY ["Modules/Basket/OrderDeliverySystem.Basket.Application/OrderDeliverySystem.Basket.Application.csproj", "Modules/Basket/OrderDeliverySystem.Basket.Application/"]
COPY ["Modules/Basket/OrderDeliverySystem.Basket.Domain/OrderDeliverySystem.Basket.Domain.csproj", "Modules/Basket/OrderDeliverySystem.Basket.Domain/"]
COPY ["Modules/Catalog/OrderDeliverySystem.Catalog.Infrastructure/OrderDeliverySystem.Catalog.Infrastructure.csproj", "Modules/Catalog/OrderDeliverySystem.Catalog.Infrastructure/"]
COPY ["Modules/Catalog/OrderDeliverySystem.Catalog.Application/OrderDeliverySystem.Catalog.Application.csproj", "Modules/Catalog/OrderDeliverySystem.Catalog.Application/"]
COPY ["Modules/Catalog/OrderDeliverySystem.Catalog.Domain/OrderDeliverySystem.Catalog.Domain.csproj", "Modules/Catalog/OrderDeliverySystem.Catalog.Domain/"]
COPY ["Modules/Ordering/OrderDeliverySystem.Ordering.Infrastructure/OrderDeliverySystem.Ordering.Infrastructure.csproj", "Modules/Ordering/OrderDeliverySystem.Ordering.Infrastructure/"]
COPY ["Modules/Ordering/OrderDeliverySystem.Ordering.Application/OrderDeliverySystem.Ordering.Application.csproj", "Modules/Ordering/OrderDeliverySystem.Ordering.Application/"]
COPY ["Modules/Ordering/OrderDeliverySystem.Ordering.Domain/OrderDeliverySystem.Ordering.Domain.csproj", "Modules/Ordering/OrderDeliverySystem.Ordering.Domain/"]
RUN dotnet restore "./OrderDeliverySystem.API/OrderDeliverySystem.API.csproj"
COPY . .
WORKDIR "/src/OrderDeliverySystem.API"
RUN dotnet build "./OrderDeliverySystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OrderDeliverySystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderDeliverySystem.API.dll"]