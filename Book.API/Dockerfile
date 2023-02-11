#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Book.API/Book.API.csproj", "Book.API/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Book.Application/Book.Application.csproj", "Book.Application/"]
COPY ["Book.Domain/Book.Domain.csproj", "Book.Domain/"]
COPY ["Book.Infrastructure/Book.Infrastructure.csproj", "Book.Infrastructure/"]
RUN dotnet restore "Book.API/Book.API.csproj"
COPY . .
WORKDIR "/src/Book.API"
RUN dotnet build "Book.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Book.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Book.API.dll"]