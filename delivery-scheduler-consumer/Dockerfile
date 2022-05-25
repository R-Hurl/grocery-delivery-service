FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy .csproj and .sln files and restore dependencies as distinct layers
COPY *.sln .
COPY DeliverySchedulerConsumer/*.csproj ./DeliverySchedulerConsumer/
RUN dotnet restore

# Copy everything else and build app
COPY DeliverySchedulerConsumer/. ./DeliverySchedulerConsumer/
WORKDIR /app/DeliverySchedulerConsumer
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/DeliverySchedulerConsumer/out ./
ENTRYPOINT ["dotnet", "DeliverySchedulerConsumer.dll"]