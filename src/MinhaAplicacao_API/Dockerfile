#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MinhaAplicacao_API/MinhaAplicacao_API.csproj", "MinhaAplicacao_API/"]
RUN dotnet restore "MinhaAplicacao_API/MinhaAplicacao_API.csproj"
COPY . .
WORKDIR "/src/MinhaAplicacao_API"
RUN dotnet build "MinhaAplicacao_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinhaAplicacao_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinhaAplicacao_API.dll"]