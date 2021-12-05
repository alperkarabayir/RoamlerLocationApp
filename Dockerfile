FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RoamlerLocationSearch.Api/RoamlerLocationSearch.Api.csproj", "RoamlerLocationSearch.Api/"]
COPY ["RoamlerLocationSearch.Core/RoamlerLocationSearch.Core.csproj", "RoamlerLocationSearch.Core/"]
COPY ["RoamlerLocationSearch.Data/RoamlerLocationSearch.Data.csproj", "RoamlerLocationSearch.Data/"]
COPY ["RoamlerLocationSearch.Services/RoamlerLocationSearch.Services.csproj", "RoamlerLocationSearch.Services/"]
RUN dotnet restore "RoamlerLocationSearch.Api/RoamlerLocationSearch.Api.csproj"
COPY . .
WORKDIR "/src/RoamlerLocationSearch.Api"
RUN dotnet build "RoamlerLocationSearch.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RoamlerLocationSearch.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "RoamlerLocationSearch.Api.dll"]