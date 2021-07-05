FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /

EXPOSE 80
EXPOSE 443

COPY . .

WORKDIR /src/backend-challenge-api
RUN dotnet restore "backend-challenge-api.csproj"
RUN dotnet build "backend-challenge-api.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "backend-challenge-api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend-challenge-api.csproj.dll"]