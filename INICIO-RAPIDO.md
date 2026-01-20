# 🐳 Inicio Rápido - Aplicación Dockerizada

## ✅ ¡La aplicación está dockerizada!

### Comandos Principales

#### 1️⃣ Iniciar la aplicación
```bash
docker-compose up -d
```

#### 2️⃣ Crear la base de datos (primera vez)
```bash
docker exec sqlserver_biblioteca /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P YourStrong@Passw0rd -C -i /docker-entrypoint-initdb.d/init-db.sql
```

#### 3️⃣ Acceder a los servicios
- **Cliente Blazor**: http://localhost:8080
- **API/Swagger**: http://localhost:5000/swagger
- **SQL Server**: localhost:1433 (sa / YourStrong@Passw0rd)

#### 4️⃣ Ver logs
```bash
# Todos los servicios
docker-compose logs -f

# Solo API
docker-compose logs -f api

# Solo Cliente
docker-compose logs -f client

# Solo SQL Server
docker-compose logs -f sqlserver
```

#### 5️⃣ Detener la aplicación
```bash
docker-compose down
```

#### 6️⃣ Reconstruir después de cambios en el código
```bash
docker-compose up -d --build
```

### 📝 Aplicar Migraciones de Entity Framework

Si tienes migraciones de EF Core pendientes:

```bash
# Opción 1: Desde tu máquina local (conectándote al SQL Server en Docker)
cd BlazorAppAlejandroChR.API
dotnet ef database update

# Opción 2: Desde dentro del contenedor de la API
docker exec -it blazor_api dotnet ef database update
```

### 🔧 Comandos Útiles

```bash
# Ver el estado de los contenedores
docker-compose ps

# Reiniciar un servicio específico
docker-compose restart api

# Ver el uso de recursos
docker stats

# Conectarse a SQL Server
docker exec -it sqlserver_biblioteca /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P YourStrong@Passw0rd -C

# Eliminar todo (incluida la base de datos)
docker-compose down -v
```

### 🎯 Estado Actual

✅ API funcionando en http://localhost:5000  
✅ Cliente funcionando en http://localhost:8080  
✅ SQL Server funcionando en localhost:1433  
✅ Base de datos BDBIBLIOTECA creada  

### 📚 Documentación Completa

Para más detalles, consulta [DOCKER-README.md](DOCKER-README.md)
