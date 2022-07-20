FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy .csproj and .sln files and restore dependencies as distinct layers
COPY *.sln .
COPY GroceryDeliveryOrdersConsumer/*.csproj ./GroceryDeliveryOrdersConsumer/
RUN dotnet restore

# Copy everything else and build app
COPY GroceryDeliveryOrdersConsumer/. ./GroceryDeliveryOrdersConsumer/
WORKDIR /app/GroceryDeliveryOrdersConsumer
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/GroceryDeliveryOrdersConsumer/out ./
ENTRYPOINT ["dotnet", "GroceryDeliveryOrdersConsumer.dll"]