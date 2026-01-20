#!/bin/bash

# Iniciar SQL Server en segundo plano
/opt/mssql/bin/sqlservr &

# Esperar a que SQL Server esté listo
echo "Esperando a que SQL Server esté listo..."
sleep 30s

# Ejecutar el script de inicialización
echo "Ejecutando script de inicialización de base de datos..."
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -C -i /docker-entrypoint-initdb.d/init-db.sql

echo "Inicialización completada"

# Mantener el proceso en primer plano
wait
