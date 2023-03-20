# Gesinv

## Instalación Base de Datos

1 - Instalan los siguientes paquetes:  
    -- Microsoft.EntityFrameworkCore 6.0.13  
    -- Microsoft.EntityFrameworkCore.SqlServer 6.0.13  
    -- Microsoft.EntityFrameworkCore.Tools 6.0.13  
2 - Colocan la solucion DAL como predeterminada y abren la terminal de nuget  
3 - Ejecutan el comando Update-Database  
4 - Listo ya tiene la tienen la BD ya creada en su SQL Server  
### Opcional  
5 - Vamos a la carpeta Docs del programa y ubicamos el archivo llamado Insert-Data.sql   
6 - Vamos a nuestra DbInventario en nuestro SQL Server, creamos una nueva Query y pegamos el contenido de Insert-Data.sql  
7 - Ejecutamos y listo tendriamos data de prueba en nuestra BD  


**Nota: Recuerden que los paquetes nuget no vienen en el repositorio instalar sus respectivos paquetes para trabajar.** 

## Base de datos

### Visualizar el diagrama del proyecto
Aqui tienen el link de una plataforma de esquemas en la que esta guardada:  
https://dbdiagram.io/d/63e14625296d97641d7ed573  

Para editarlo tiene que copiar el codigo que esta ubicado en **Docs/DBDiagrama.txt** y crear un nuevo diagrama en la plataforma. Una vez finalizado los cambios consultar con el grupo y apartir de lo concluido se realizara la respectiva actualizacion.  
**Gracias por colaborar :)**  