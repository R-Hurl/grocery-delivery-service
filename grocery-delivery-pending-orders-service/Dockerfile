FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

EXPOSE 80
EXPOSE 443

# Copy .csproj and .sln files and restore dependencies as distinct layers
COPY *.sln .
COPY PendingOrdersService/*.csproj ./PendingOrdersService/
RUN dotnet restore

# Copy everything else and build app
COPY PendingOrdersService/. ./PendingOrdersService/
WORKDIR /app/PendingOrdersService
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS=https://+:443
WORKDIR /app
COPY --from=build /app/PendingOrdersService/out ./
ENTRYPOINT ["dotnet", "PendingOrdersService.dll"]