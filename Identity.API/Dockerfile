#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Identity.API/Identity.API.csproj", "Identity.API/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Identity.Application/Identity.Application.csproj", "Identity.Application/"]
COPY ["Identity.Domain/Identity.Domain.csproj", "Identity.Domain/"]
COPY ["Identity.Infrastructure/Identity.Infrastructure.csproj", "Identity.Infrastructure/"]
RUN dotnet restore "Identity.API/Identity.API.csproj"
COPY . .
WORKDIR "/src/Identity.API"
RUN dotnet build "Identity.API.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet run "Identity.API.csproj" -c Release -o /app/publish /p:UseAppHost=false  --urls=http://localhost:5002/

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS http://[::]:5001

ENTRYPOINT ["dotnet", "Identity.API.dll"]