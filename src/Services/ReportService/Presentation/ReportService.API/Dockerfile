#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/ReportService/Presentation/ReportService.API/ReportService.API.csproj", "src/Services/ReportService/Presentation/ReportService.API/"]
COPY ["src/Services/ReportService/Infrastructure/ReportService.Infrastructure/ReportService.Infrastructure.csproj", "src/Services/ReportService/Infrastructure/ReportService.Infrastructure/"]
COPY ["src/Services/ReportService/Core/ReportService.Application/ReportService.Application.csproj", "src/Services/ReportService/Core/ReportService.Application/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.Base/EventBus.Base.csproj", "src/BuildingBlocks/EventBus/EventBus.Base/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.Factory/EventBus.Factory.csproj", "src/BuildingBlocks/EventBus/EventBus.Factory/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.RabbitMQ/EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/EventBus.RabbitMQ/"]
COPY ["src/Services/ReportService/Core/ReportService.Domain/ReportService.Domain.csproj", "src/Services/ReportService/Core/ReportService.Domain/"]
COPY ["src/Services/ReportService/Infrastructure/ReportService.Persistence/ReportService.Persistence.csproj", "src/Services/ReportService/Infrastructure/ReportService.Persistence/"]
RUN dotnet restore "src/Services/ReportService/Presentation/ReportService.API/ReportService.API.csproj"
COPY . .
WORKDIR "/src/src/Services/ReportService/Presentation/ReportService.API"
RUN dotnet build "ReportService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReportService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReportService.API.dll"]
