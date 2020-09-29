#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CQRS.API/CQRS.API.csproj", "CQRS.API/"]
RUN dotnet restore "CQRS.API/CQRS.API.csproj"
COPY . .
WORKDIR "/src/CQRS.API"
RUN dotnet build "CQRS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRS.API.dll"]