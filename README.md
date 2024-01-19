# Configuracion inicial para correr la API

- Bajar el repo
  ```
  git clone https://github.com/OrganizationForge/apps-backend.git
  ```
- Abrir con Visual Studio
- Obtener el nombre de la BD local o IP/URL a usar
  
  ![image](https://github.com/OrganizationForge/apps-backend/assets/53581829/d759601c-e09e-456c-a9c3-d0536fa37742)

- Modificar el archivo appSettings.development.json para poner la BD en el connectionString
  
  ![image](https://github.com/OrganizationForge/apps-backend/assets/53581829/96e006ad-22ca-4ad1-aa3c-4a039095c539)

  ![image](https://github.com/OrganizationForge/apps-backend/assets/53581829/9c988e2c-ec7d-40f1-b12e-805f5d6be7ee)

## Migracion y actualizacion de Identity
- Debemos generar las tablas de la BD a partir del modelo y de las Migrations del proyecto Identity y Persistence.
  Para esto ingresamos en la consola de administracion de Nugget
  
  ![image](https://github.com/OrganizationForge/apps-backend/assets/53581829/e9a83388-eb57-4184-9126-82573606bec6)

- Dentro de la consola, seleccionamos el proyecto Identity y ejecutamos el siguiente comando:

  Comando para Visual Studio
  ```
  Update-database -Context IdentityContext
  ```
  Comando para Visual Studio Code (VsCode)
  ```
  dotnet ef database-update --Context IdentityContext
  ```
  ![image](https://github.com/OrganizationForge/apps-backend/assets/53581829/56a8bf27-9f2a-4305-aea7-350c2d74dbe2)

  Al ejecutar el comando usando el flag -Context <Context>, le decimos que nos genere una base utilizando un dbContext especifico. 
  Luego nos genera las tablas en la Base como podemos ver:
  
  ![image](https://github.com/OrganizationForge/apps-backend/assets/53581829/da4392db-079e-46a3-ae95-49f7af4bd8e4)

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
  ![image](https://github.com/OrganizationForge/apps-backend/assets/53581829/0392f68f-6b37-40ce-958e-746b9a146c70)

  Al ejecutar el comando nos genera las tablas del modelo de Persistence:

  ![image](https://github.com/OrganizationForge/apps-backend/assets/53581829/f2a5c30a-efc8-4cf4-8548-f75b4ee6eb27)

## Ejecucion API

- Luego solo resta Configurar el proyecto WebApi como proyecto de inicio y ejecutarlo.
- El proyecto tiene configurado varias SEEDS, que crean datos iniciales en la base tanto para los usuarios en modelo Identity como para algunas clases en el modelo de Persistence.

![image](https://github.com/OrganizationForge/apps-backend/assets/53581829/d10bd6ca-61cb-414f-827b-a654eec67882)

  





