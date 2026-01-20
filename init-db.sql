-- Script de inicialización de base de datos
-- Este script se ejecuta automáticamente cuando se crea el contenedor de SQL Server

USE master;
GO

-- Crear la base de datos si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BDBIBLIOTECA')
BEGIN
    CREATE DATABASE BDBIBLIOTECA;
    PRINT 'Base de datos BDBIBLIOTECA creada exitosamente';
END
ELSE
BEGIN
    PRINT 'La base de datos BDBIBLIOTECA ya existe';
END
GO

USE BDBIBLIOTECA;
GO

PRINT 'Base de datos lista para usar';
GO
