# Backing
Proyecto de desafio backend y frontend, de manejo básico de criptomonedas.
Tecnología usada: 
API WEB: Microsoft .NET Core 7.0, lenguaje C#, patrón MVC.
Base de datos: Microsoft SQL Server 2012
# Instalación
1. Clonar el repositorio.
2. Abrir el proyecto en Visual Studio 2022.
3. Restaurar los paquetes NuGet.
4. Configurar la cadena de conexión a la base de datos en el archivo `appsettings.json`.  
    `DefaultConnection`: `Server=<Servidor de BD>;Database=Criptos;Trusted_Connection=True; trustServerCertificate=true`, solo proyecto    ApiBacking.
5. Entrar a Microsoft SQL Server Management Studio o Azure Data Studio, crear la base de datos con   el nombre Criptos, luego
   ejecutar el script Criptos.sql para generar las entidades de la BD y agregar datos de prueba, solo proyecto ApiBacking.
6. Colocar el proyecto WebBacking como proyecto principal, el proyecto ApiBacking se ejecuta como nueva instancia. 

Nota: Este proyecto solo es un ejemplo muy básico, que solo pretende demostrar mis capacidades y experiencia técnica en front end y back end, de una prueba técnica solicitada por una compañía de desarrollo de software, en un tiempo limite máximo de 48 horas. 