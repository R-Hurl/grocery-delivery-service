FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GroceryDeliveryOrdersConsumer/GroceryDeliveryOrdersConsumer.csproj", "background-service/"]
RUN dotnet restore "background-service/GroceryDeliveryOrdersConsumer.csproj"
COPY . .
WORKDIR "/src/background-service"
RUN dotnet build "GroceryDeliveryOrdersConsumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroceryDeliveryOrdersConsumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroceryDeliveryOrdersConsumer.dll"]