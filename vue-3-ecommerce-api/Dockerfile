#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["vue-3-ecommerce-api/vue-3-ecommerce-api.csproj", "vue-3-ecommerce-api/"]
RUN dotnet restore "vue-3-ecommerce-api/vue-3-ecommerce-api.csproj"
COPY . .
WORKDIR "/src/vue-3-ecommerce-api"
RUN dotnet build "vue-3-ecommerce-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "vue-3-ecommerce-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "vue-3-ecommerce-api.dll"]