# 📚 Sistema de Gestión Bibliotecaria

![.NET](https://img.shields.io/badge/.NET-512BD4?logo=.net&logoColor=white&style=for-the-badge) ![Blazor](https://img.shields.io/badge/Blazor-512BD4?logo=blazor&logoColor=white&style=for-the-badge) ![C# ](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white&style=for-the-badge)

Este proyecto es una solución integral para la gestión de bibliotecas, desarrollada con **.NET Core** y **Blazor WebAssembly**. Permite administrar eficientemente el inventario de libros, autores, tipos de libros, usuarios, y facilita el control de préstamos y devoluciones. Proporciona una experiencia de usuario dinámica a través de su interfaz web y un robusto backend RESTful.

## ✨ Características Principales

*   **Gestión de Libros:** Añade, edita, elimina y visualiza información detallada de los libros en tu biblioteca.
*   **Gestión de Autores:** Administra los datos de los autores asociados a los libros.
*   **Gestión de Tipos de Libro:** Categoriza los libros para una mejor organización y búsqueda.
*   **Gestión de Usuarios:** Registra y administra a los usuarios que interactúan con el sistema bibliotecario.
*   **Gestión de Préstamos y Reservas:** Controla el estado de los libros (disponible, prestado, reservado) y gestiona el historial de préstamos y reservas.
*   **Interfaz de Usuario Intuitiva:** Desarrollada con Blazor WebAssembly para una experiencia de usuario moderna, rica y dinámica.
*   **API RESTful:** Un backend robusto con ASP.NET Core Web API que maneja la lógica de negocio y la persistencia de datos.

## 📋 Requisitos Previos

Asegúrate de tener instalado lo siguiente para compilar y ejecutar el proyecto:

*   [.NET SDK 8.0 o superior](https://dotnet.microsoft.com/download)
*   Un entorno de desarrollo integrado (IDE) como [Visual Studio](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)
*   (Opcional) Un sistema de gestión de bases de datos compatible con Entity Framework Core (ej. SQL Server, PostgreSQL, SQLite).

## 🛠️ Instrucciones de Instalación

Sigue estos pasos para poner en marcha el proyecto en tu entorno local:

1.  **Clonar el repositorio:**

    ```bash
    git clone https://github.com/tu-usuario/SistemaDeGestionBibliotecaria.git
    cd SistemaDeGestionBibliotecaria
    ```

2.  **Restaurar dependencias:**

    Abre una terminal en la raíz del proyecto (`SistemaDeGestionBibliotecaria`) y ejecuta:

    ```bash
    dotnet restore
    ```

3.  **Configurar la base de datos:**

    *   Asegúrate de que tu cadena de conexión a la base de datos esté configurada correctamente en `BlazorAppAlejandroChR.API/appsettings.json`.
    *   Aplica las migraciones de Entity Framework Core para crear o actualizar tu base de datos (si aplica):

        ```bash
        cd BlazorAppAlejandroChR.API
        dotnet ef database update
        ```

4.  **Ejecutar el proyecto:**

    Puedes ejecutar ambos proyectos (API y Cliente) simultáneamente si estás usando Visual Studio, o desde la línea de comandos en terminales separadas:

    ```bash
    # 🖥️ En una terminal para el backend (API)
    cd BlazorAppAlejandroChR.API
    dotnet run

    # 🌐 En otra terminal para el frontend (Cliente Blazor)
    cd BlazorAppAlejandroChR.Client
    dotnet run
    ```

    El cliente Blazor se ejecutará en un puerto específico (generalmente `https://localhost:7xxx`) y la API en otro (`https://localhost:5xxx`).

## 🚀 Guía de Uso

Una vez que la aplicación esté en funcionamiento:

1.  **Accede a la aplicación:** Abre tu navegador web y navega a la URL donde se está ejecutando el proyecto cliente (ej. `https://localhost:7xxx`).
2.  **Navega por las secciones:** Utiliza el menú de navegación lateral o superior para acceder a las diferentes funcionalidades:
    *   **Libros:** Para explorar, añadir, editar o eliminar libros.
    *   **Autores:** Para gestionar la información de los autores.
    *   **Tipos de Libro:** Para configurar y administrar las categorías de libros.
    *   **Usuarios:** Para la administración de cuentas de usuario.
    *   **Préstamos/Reservas:** Para registrar y controlar los préstamos y las reservas de libros.
3.  **Interactúa con los formularios:** Utiliza los formularios intuitivos para añadir nuevos registros, editar los existentes o realizar búsquedas.
4.  **Realiza búsquedas:** Aprovecha las funcionalidades de búsqueda (si implementadas) para encontrar rápidamente la información deseada.

## 📂 Estructura del Proyecto

El proyecto está organizado en una arquitectura de múltiples proyectos para una clara separación de responsabilidades:
```
Proyecto-.Net/
├── BlazorAppAlejandroChR.API/         # ⚙️ Proyecto de la API RESTful (Backend)
│   ├── Controllers/                   # Controladores para las operaciones CRUD
│   ├── Models/                        # Modelos de datos (Entidades de la BD) y DbContext
│   ├── Properties/                    # Configuraciones del proyecto
│   └── Program.cs                     # Punto de entrada de la aplicación API
├── BlazorAppAlejandroChR.Client/      # 🌐 Proyecto de la aplicación Blazor WebAssembly (Frontend)
│   ├── Components/                    # Componentes reutilizables de Blazor (.razor)
│   ├── Layout/                        # Diseño principal de la aplicación
│   ├── Pages/                         # Páginas principales de la aplicación (.razor)
│   ├── Services/                      # Servicios para consumir la API
│   ├── wwwroot/                       # Archivos estáticos (CSS, JS, imágenes, index.html)
│   └── Program.cs                     # Punto de entrada de la aplicación cliente
├── BlazorAppAlejandroChR.Entities/    # 🧩 Proyecto de librerías de clases compartidas (DTOs, Entidades)
│   └── (Clases CLS)                   # Clases que representan DTOs o entidades compartidas
└── BlazorAppAlejandroChR.sln          # ➡️ Archivo de solución de Visual Studio
```

## 💻 Tecnologías Utilizadas

Este proyecto hace uso de las siguientes tecnologías y frameworks modernos:

*   **Backend:**
    *   **.NET 8.0:** La plataforma principal para el desarrollo de aplicaciones.
    *   **ASP.NET Core Web API:** Para construir servicios RESTful robustos y escalables.
    *   **C# :** El lenguaje de programación principal para toda la lógica del lado del servidor.
    *   **Entity Framework Core:** Un ORM potente para la interacción con la base de datos, facilitando la gestión de datos.
*   **Frontend:**
    *   **Blazor WebAssembly:** Un framework de Microsoft que permite construir Single Page Applications (SPA) interactivas utilizando C# directamente en el navegador.
    *   **C# :** El lenguaje de programación utilizado para la lógica del lado del cliente.
    *   **HTML5, CSS3, JavaScript:** Tecnologías web estándar para la estructura, estilo y funcionalidad complementaria de la interfaz de usuario.