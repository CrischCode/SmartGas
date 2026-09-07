FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SmartGas.Api.csproj", "."]
COPY . .
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /appEXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SmartGas.Api.dll"]