#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Library.API/Library.API.csproj", "Library.API/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Library.Application/Library.Application.csproj", "Library.Application/"]
COPY ["Library.Domain/Library.Domain.csproj", "Library.Domain/"]
COPY ["Library.Infrastructure/Library.Infrastructure.csproj", "Library.Infrastructure/"]
RUN dotnet restore "Library.API/Library.API.csproj"
COPY . .
WORKDIR "/src/Library.API"
RUN dotnet build "Library.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Library.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library.API.dll"]