# MVC CRUD con Login en ASP.NET Core 8.0

Este proyecto es una implementación de un sistema CRUD con autenticación mediante un login utilizando ASP.NET Core 8.0 y SQL Server. El sistema permite el acceso a una sección privada (CRUD) únicamente a usuarios autenticados, protegiendo las URLs y las secciones privadas del sistema.

## Tabla de Contenidos

- [Descripción](#descripción)
- [Instalación](#instalación)
- [Uso](#uso)
- [Créditos](#créditos)
- [Licencia](#licencia)

## Descripción

Este proyecto tiene como objetivo demostrar un sistema de autenticación de usuario utilizando el patrón MVC. Los usuarios deben iniciar sesión para acceder a las funcionalidades CRUD protegidas, que permiten la gestión de una lista de usuarios (creación, edición, visualización y eliminación).

El trabajo fue desarrollado en **Visual Studio 2022** con **.NET 8.0** y el **SQL Server Management Studio (SSMS) 20.2**. Incluye una sección de autenticación que redirige a una vista de login si el usuario no está autenticado.

## Instalación

1. **Clonar el repositorio**:
    ```bash
    git clone https://github.com/martinvargas/MVC_CRUD_VARGAS.git
    ```

2. **Configurar la base de datos**:
    - Crear la base de datos usando el script SQL proporcionado en el directorio `database` y ejecutarlo en SQL Server.

3. **Configurar la cadena de conexión**:
    - Editar el archivo `appsettings.json` para incluir tu cadena de conexión a SQL Server:
      ```json
      "ConnectionStrings": {
        "Conexion": "Server=localhost;Database=MVC_CRUD;Trusted_Connection=True;"
      }
      ```

4. **Aplicar las migraciones**:
    - Ejecutar las migraciones para crear las tablas en la base de datos:
      ```bash
      Update-Database
      ```

5. **Ejecutar la aplicación**:
    - Ejecutar la aplicación en Visual Studio o usando .NET CLI:
      ```bash
      dotnet run
      ```

## Uso

1. **Registro de Usuarios**: Los nuevos usuarios pueden registrarse en la aplicación.
2. **Login**: Los usuarios registrados pueden iniciar sesión para acceder a la sección CRUD protegida.
3. **Operaciones CRUD**: Los usuarios autenticados pueden crear, editar, ver y eliminar registros de usuarios.
4. **Protección de URLs**: Las URLs de CRUD están protegidas y solo accesibles si el usuario ha iniciado sesión.

### Video de demostración

Puedes ver el funcionamiento del sistema en el siguiente [video](https://youtu.be/Fg3n2TmjPN0).

## Créditos

Desarrollado por **Martín Vargas**, estudiante de la **Universidad de las Américas**.

## Contacto

- **Teléfono**: +593 994428772
- **Correo**: martin.vargas@udla.edu.ec

## Licencia

Este proyecto está bajo la Licencia MIT. Para más detalles, consulta el archivo [LICENSE](LICENSE).
