### Estágio 1 - Obter o source e gerar o Build ###
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS dotnet-builder
WORKDIR /app
COPY . /app
RUN dotnet restore NiceTruck.Web/NiceTruck.Web.csproj
RUN dotnet publish NiceTruck.Web/NiceTruck.Web.csproj -c Release -o /app/publish

### Estágio 2 - Subir a aplicação através dos binários ###
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=dotnet-builder /app/publish .
ENTRYPOINT ["dotnet", "NiceTruck.Web.dll"]