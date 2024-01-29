FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet build "eCinema/eCinema.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eCinema/eCinema.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5192
ENV ASPNETCORE_URLS=http://+:5192

ENTRYPOINT ["dotnet", "eCinema.dll"]