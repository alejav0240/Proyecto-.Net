# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos de proyecto
COPY ["BlazorAppAlejandroChR.Client/BlazorAppAlejandroChR.Client.csproj", "BlazorAppAlejandroChR.Client/"]
COPY ["BlazorAppAlejandroChR.Entities/BlazorAppAlejandroChR.Entities.csproj", "BlazorAppAlejandroChR.Entities/"]

# Restaurar dependencias
RUN dotnet restore "BlazorAppAlejandroChR.Client/BlazorAppAlejandroChR.Client.csproj"

# Copiar el resto del código
COPY . .
WORKDIR "/src/BlazorAppAlejandroChR.Client"

# Build y publicación de Blazor WebAssembly
RUN dotnet publish "BlazorAppAlejandroChR.Client.csproj" -c Release -o /app/publish

# Etapa final - usar nginx para servir los archivos estáticos
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Copiar los archivos publicados
COPY --from=build /app/publish/wwwroot .

# Copiar configuración personalizada de nginx
COPY BlazorAppAlejandroChR.Client/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
