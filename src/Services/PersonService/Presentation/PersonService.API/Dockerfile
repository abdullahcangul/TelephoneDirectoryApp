#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/PersonService/Presentation/PersonService.API/PersonService.API.csproj", "src/Services/PersonService/Presentation/PersonService.API/"]
COPY ["src/Services/PersonService/Infrastructure/PersonService.Infrastructure/PersonService.Infrastructure.csproj", "src/Services/PersonService/Infrastructure/PersonService.Infrastructure/"]
COPY ["src/Services/PersonService/Core/PersonService.Application/PersonService.Application.csproj", "src/Services/PersonService/Core/PersonService.Application/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.Factory/EventBus.Factory.csproj", "src/BuildingBlocks/EventBus/EventBus.Factory/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.Base/EventBus.Base.csproj", "src/BuildingBlocks/EventBus/EventBus.Base/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.RabbitMQ/EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/EventBus.RabbitMQ/"]
COPY ["src/Services/PersonService/Core/PersonService.Domain/PersonService.Domain.csproj", "src/Services/PersonService/Core/PersonService.Domain/"]
COPY ["src/Services/PersonService/Infrastructure/PersonService.Persistence/PersonService.Persistence.csproj", "src/Services/PersonService/Infrastructure/PersonService.Persistence/"]
RUN dotnet restore "src/Services/PersonService/Presentation/PersonService.API/PersonService.API.csproj"
COPY . .
WORKDIR "/src/src/Services/PersonService/Presentation/PersonService.API"
RUN dotnet build "PersonService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonService.API.dll"]
