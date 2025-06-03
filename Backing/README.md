# ApiBacking
Api de desafio backend, de manejo básico de criptomonedas.
Tecnología usada: 
API WEB: Microsoft .NET Core 7.0, lenguaje C#, patrón MVC.
Base de datos: Microsoft SQL Server 2012
# Instalación
1. Clonar el repositorio.
2. Abrir el proyecto en Visual Studio 2022.
3. Restaurar los paquetes NuGet.
4. Configurar la cadena de conexión a la base de datos en el archivo `appsettings.json`.  
    `DefaultConnection`: `Server=<Servidor de BD>;Database=Criptos;Trusted_Connection=True; trustServerCertificate=true`
5. Entrar a Microsoft SQL Server Management Studio o Azure Data Studio, crear la base de datos con el nombre Criptos, luego
   ejecutar el script Criptos.sql para generar las entidades de la BD y agregar datos de prueba.
6. Ejecutar la aplicación desde Visual Studio
7. Estructura del proyecto, carpetas:

   Controllers: Controladores
   Models: Clases con los modelos de las tablas/entidades, usadas para mapeo de datos y/o despliegue de los mismos.
   Services: Clases de servicio, con los métodos requeridos para las operaciones CRUD y listado de datos. Se usa injeccion de dependencias.
   Repository: Clases repositorios de las entidades, define las estructuras de los metodos de los CRUD.
   Data: Contiene las clases de las entidades y la clase que define el contexto de la BD. 
   Bd: Script de base de datos y relacionados.
8. Para probarlo de forma independiente, se ejecuta y listo, para usarlo con la app que la consume, ejecutar el proyecto WebBacking 
   como el principal, luego desde VS, ejecutar una nueva instancia de ApiBacking.

 


