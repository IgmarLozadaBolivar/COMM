ARG VARIANT=7.0.409-bookworm-slim-amd64
FROM mcr.microsoft.com/dotnet/sdk:${VARIANT} AS build
WORKDIR /source
EXPOSE 5033

COPY Api/*.csproj Api/
COPY Aplicacion/*.csproj Aplicacion/
COPY Dominio/*.csproj Dominio/
COPY Persistencia/*csproj Persistencia/
RUN dotnet restore Api/Api.csproj

COPY Api/ Api/
COPY Aplicacion/ Aplicacion/
COPY Dominio/ Dominio/
COPY Persistencia/ Persistencia/

FROM build AS publish
WORKDIR /source/Api
RUN dotnet publish --no-restore -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0.19-bookworm-slim-amd64
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet"]
CMD ["Api.dll", "--urls", "http://+:8080"]
