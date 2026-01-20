# Docker - Instrucciones de Uso

## Prerrequisitos
- Docker Desktop instalado
- Docker Compose instalado

## Estructura de la Aplicación Dockerizada

La aplicación consta de 3 servicios:
1. **sqlserver**: Base de datos SQL Server 2022
2. **api**: API Backend (.NET 8)
3. **client**: Cliente Blazor WebAssembly (servido por nginx)

## Construcción y Ejecución

### Opción 1: Iniciar todos los servicios
```bash
docker-compose up --build
```

### Opción 2: Iniciar en segundo plano
```bash
docker-compose up -d --build
```

### Detener los servicios
```bash
docker-compose down
```

### Detener y eliminar volúmenes (borra la base de datos)
```bash
docker-compose down -v
```

## Acceso a los Servicios

- **Cliente Blazor**: http://localhost:8080
- **API**: http://localhost:5000
- **Swagger UI**: http://localhost:5000/swagger
- **SQL Server**: localhost:1433
  - Usuario: `sa`
  - Contraseña: `YourStrong@Passw0rd`

## Configuración de la Base de Datos

### Crear la base de datos (primera vez)

1. Conectarse al contenedor de SQL Server:
```bash
docker exec -it sqlserver_biblioteca /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourStrong@Passw0rd
```

2. Crear la base de datos:
```sql
CREATE DATABASE BDBIBLIOTECA;
GO
USE BDBIBLIOTECA;
GO
```

### Aplicar migraciones (si usas Entity Framework)

Desde el directorio del proyecto API:
```bash
dotnet ef database update
```

O desde el contenedor:
```bash
docker exec -it blazor_api dotnet ef database update
```

## Variables de Entorno

Puedes personalizar las siguientes variables en el archivo `docker-compose.yml`:

- **SQL Server**:
  - `SA_PASSWORD`: Contraseña del usuario sa
  - `MSSQL_PID`: Edición de SQL Server (Express, Developer, etc.)

- **API**:
  - `ASPNETCORE_ENVIRONMENT`: Entorno (Development, Production)
  - `ConnectionStrings__DefaultConnection`: Cadena de conexión a la base de datos

## Desarrollo Local

Para desarrollo local sin Docker, puedes usar:
```bash
# Iniciar solo la base de datos
docker-compose up sqlserver -d

# Ejecutar la API localmente
cd BlazorAppAlejandroChR.API
dotnet run

# Ejecutar el cliente localmente
cd BlazorAppAlejandroChR.Client
dotnet run
```

## Logs

Ver logs de un servicio específico:
```bash
docker-compose logs -f api
docker-compose logs -f client
docker-compose logs -f sqlserver
```

## Solución de Problemas

### La API no puede conectarse a SQL Server
- Asegúrate de que el contenedor de SQL Server esté saludable: `docker-compose ps`
- Verifica los logs: `docker-compose logs sqlserver`

### El cliente no puede conectarse a la API
- Verifica que la URL de la API en el cliente apunte a `http://localhost:5000`
- Revisa los logs de la API: `docker-compose logs api`

### Cambiar la contraseña de SQL Server
1. Modifica `SA_PASSWORD` en `docker-compose.yml`
2. Modifica `ConnectionStrings__DefaultConnection` en `docker-compose.yml`
3. Reconstruye: `docker-compose down -v && docker-compose up --build`

## Notas de Seguridad

⚠️ **IMPORTANTE**: La contraseña de SQL Server (`YourStrong@Passw0rd`) es solo para desarrollo. 
Para producción:
- Usa variables de entorno desde archivos `.env`
- Usa secretos de Docker/Kubernetes
- Nunca subas contraseñas al repositorio

## Personalización

### Cambiar puertos

Edita el archivo `docker-compose.yml`:
```yaml
ports:
  - "PUERTO_HOST:PUERTO_CONTENEDOR"
```

### Usar una base de datos externa

Modifica la variable de entorno `ConnectionStrings__DefaultConnection` en el servicio `api` del `docker-compose.yml`.
