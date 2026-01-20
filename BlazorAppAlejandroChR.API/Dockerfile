# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos de proyecto
COPY ["BlazorAppAlejandroChR.API/BlazorAppAlejandroChR.API.csproj", "BlazorAppAlejandroChR.API/"]
COPY ["BlazorAppAlejandroChR.Entities/BlazorAppAlejandroChR.Entities.csproj", "BlazorAppAlejandroChR.Entities/"]

# Restaurar dependencias
RUN dotnet restore "BlazorAppAlejandroChR.API/BlazorAppAlejandroChR.API.csproj"

# Copiar el resto del código
COPY . .
WORKDIR "/src/BlazorAppAlejandroChR.API"

# Build de la aplicación
RUN dotnet build "BlazorAppAlejandroChR.API.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "BlazorAppAlejandroChR.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final - runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorAppAlejandroChR.API.dll"]
