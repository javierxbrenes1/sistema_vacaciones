# Como correr este codigo local ?

1. Asegurarse que se tiene instalado dotnet v8, executar `dotnet --version` para verificarla
2. descargar el codigo fuente y ejecutar `dotnet restore` para descargar todas las dependencias.
3. Este proyecto utiliza EntityFramework para crear la base de datos y las tablas es por eso que se deben correr las migraciones para eso se debe:

  1. Actualizar el string de conexion de la base de datos que se encuentra en `appsettings.json` > `ConnectionStrings` > `SistemaVacacionesContext`, se debe ajustar para que conecte a la instancia local de Sql Server.
  2. Ejecutar `dotnet ef database update` para que las migraciones corran y se creen las tablas en la base de datos.
  3. Si esto presenta error se debe buscar en internet como ejecutar comandos de entity framework.
