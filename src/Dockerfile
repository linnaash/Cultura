FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["Cultura_New/Cultura_New/Cultura_New.csproj","Cultura_New/"]
COPY ["Cultura_New/BusinessLogic/BusinessLogic.csproj","BusinessLogic/"]
COPY ["Cultura_New/Domain/Domain.csproj","Domain/"]
COPY ["Cultura_New/DataAccess/DataAccess.csproj","DataAccess/"]
RUN dotnet restore "Cultura_New/Cultura_New.csproj"

COPY . .
FROM build  AS publish
RUN dotnet publish "Cultura_New/Cultura_New/Cultura_New.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","Cultura_New.dll"]
