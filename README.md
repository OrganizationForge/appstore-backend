# Configuracion inicial para correr la API

- Bajar el repo
- Abrir con Visual Studio
- Obtener el nombre de la BD local o IP/URL a usar
  ![image](https://github.com/OrganizationForge/BackLibrary/assets/53581829/b9b11f91-81a8-4182-892e-7ec355abb0f4)
  
  ![image](https://github.com/OrganizationForge/BackLibrary/assets/53581829/6543f562-ea07-4eb9-9b82-72a4ef77f635)

- Modificar el archivo appSettings.development.json para poner la BD en el connectionString
  ![image](https://github.com/OrganizationForge/BackLibrary/assets/53581829/8c9c7663-f0c9-4c9d-9206-6144d467e81a)
  
## Migracion y actualizacion de Identity
- Debemos generar las tablas de la BD a partir del modelo y de las Migrations del proyecto Identity y Persistence.
  Para esto ingresamos en la consola de administracion de Nugget
  ![image](https://github.com/OrganizationForge/BackLibrary/assets/53581829/83fd401a-4cfd-464e-aaf2-e567a739839b)

- Dentro de la consola, seleccionamos el proyecto Identity y ejecutamos el siguiente comando:

  Comando para Visual Studio
  ```
  Update-database -Context IdentityContext
  ```
  Comando para Visual Studio Code (VsCode)
  ```
  dotnet ef database-update --Context IdentityContext
  ```
  ![image](https://github.com/OrganizationForge/BackLibrary/assets/53581829/86592e2c-4921-447f-b361-59e2204c575f)

  Al ejecutar el comando usando el flag -Context <Context>, le decimos que nos genere una base utilizando un dbContext especifico. 
  Luego nos genera las tablas en la Base como podemos ver:
  ![image](https://github.com/OrganizationForge/BackLibrary/assets/53581829/1028a622-8926-465e-ac4e-cf58856d75e9)

## Migracion y actualizacion de Persistence
- Ahora seleccionamos el proyecto de Persistence y ejecutamos el siguiente comando:

  Comando para Visual Studio
  ```
  Update-database -Context ApplicationDbContext
  ```
  Comando para Visual Studio Code (VsCode)
  ```
  dotnet ef database-update --Context ApplicationDbContext
  ```
  ![image](https://github.com/OrganizationForge/BackLibrary/assets/53581829/c51d8f32-97b4-4c0c-8dbb-09a02f3fa88e)

  Al ejecutar el comando nos genera las tablas del modelo de Persistence:

  ![image](https://github.com/OrganizationForge/BackLibrary/assets/53581829/ca2a8441-1de8-4527-bb6a-97411eb45ed5)

## Ejecucion API

- Luego solo resta Configurar el proyecto WebApi como proyecto de inicio y ejecutarlo.
- El proyecto tiene configurado varias SEEDS, que crean datos iniciales en la base tanto para los usuarios en modelo Identity como para algunas clases en el modelo de Persistence.

  ![image](https://github.com/OrganizationForge/BackLibrary/assets/53581829/15bf6685-ad93-448d-8796-facff1a623bd)

  





