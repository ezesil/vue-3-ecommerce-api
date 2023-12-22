
# Etapa de construcción del frontend Vue.js
FROM node:18 AS build_vue
COPY ./vueapp/package.json ./app/vueapp/
COPY ./vueapp/package-lock.json ./app/vueapp/
WORKDIR /app/vueapp
RUN npm install
WORKDIR /
COPY ./vueapp/ ./app/vueapp/
WORKDIR /app/vueapp
RUN npm run build

# Etapa de construcción del backend .NET Core
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build_dotnet
WORKDIR /app/apiweb
COPY apiweb/*.csproj ./
RUN dotnet restore
COPY apiweb/ .
RUN dotnet publish -c Release -o out

# Etapa final, combinación de ambas aplicaciones en una imagen
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
EXPOSE 8080
WORKDIR /app

# Configuración de Nginx para servir frontend y redirigir a backend
RUN apt-get update && apt-get install -y nginx && apt-get install nano -y nano && apt-get install curl -y curl && apt-get install systemctl -y systemctl && apt-get install sudo -y sudo
RUN rm -rf /etc/nginx/nginx.conf
COPY apiweb/nginx/nginx.conf /etc/nginx/nginx.conf

COPY --from=build_dotnet /app/apiweb/out .
COPY --from=build_vue /app/vueapp/dist vueapp

COPY apiweb/nginx/start.sh ./start.sh
RUN chmod +x start.sh





