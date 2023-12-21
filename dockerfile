
# Etapa de construcci�n del frontend Vue.js
FROM node:18 AS build_vue
WORKDIR /app/vueapp
COPY vueapp/package*.json ./
RUN npm install
COPY vueapp/ .
RUN npm run build

# Etapa de construcci�n del backend .NET Core
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build_dotnet
WORKDIR /app/apiweb
COPY apiweb/*.csproj ./
RUN dotnet restore
COPY apiweb/ .
RUN dotnet publish -c Release -o out

# Etapa final, combinaci�n de ambas aplicaciones en una imagen
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build_dotnet /app/apiweb/out apiweb
COPY --from=build_vue /app/vueapp/dist vueapp

# Configuraci�n de Nginx para servir frontend y redirigir a backend
RUN apt-get update && apt-get install -y nginx
RUN rm -rf /etc/nginx/nginx.conf
COPY apiweb/nginx/nginx.conf /etc/nginx/nginx.conf

# Configuraci�n de Nginx
EXPOSE 8081
CMD service nginx start && dotnet /app/apiweb/apiweb.dll && tail -f /dev/null