#  Product Management!

Apliacion .net core backend para el manejo de productos y categorias


## Clone

Lo primero es clonar el proyecto para poderlo correr de forma local.

## Migraciones
El gestor de base datos usado para la realizacion de esta tarea fue PostgresSql.

Vaya al directorio **ProductManagement.Infrastructure.Persistence** y ejecute el commando **Update-Database** si se encuentra en el Package Manager Console de Visual Studio o **dotnet ef database update** si lo haces por una consola de windows.

## Ejecución

Ejecute los proyectos **ProductManagement.WebApi** y **IdentityServer** ya con estos dos proyectos corriendo tenemos el backen sincronizado.