FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY . ./src
WORKDIR /src/

RUN dotnet build -c Release -o output

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

COPY --from=build /src/output .

ENTRYPOINT ["dotnet", "MercadoEletronico.Aplication.dll" ]