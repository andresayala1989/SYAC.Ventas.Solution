El back se encuentra en: C:\Users\User01\source\repos\SYAC.Ventas.Solution

				GIT: https://github.com/andresayala1989/SYAC.Ventas.Solution.git

El front se encuentra en: C:\Users\User01\Ventas\VentasUI

La BD se llama ventas ubicada en (Local) Tambien en el escritorio se deja script completo de la BD


Dando respuesta a los requerimientos solicitados doy un breve resumen de lo realizado.

Desarrollar un sistema de información que permita la creación y edición de ORDENES DE PEDIDO por cliente.

Se desarrollo el sistema en dos proyectos el web en Angular y el de escritorio en WPF

• Cada orden de pedido estará relacionada a un único cliente y deberá contener por lo menos un producto a despachar.

Teniendo en cuenta este requerimiento se construyo la BD con estas condiciones

• Los pedidos podrán manejar los estados “Registrado” (Con posibilidad de edición), “Confirmado” o “Anulado” (Cierre de Pedido).

De acuerdo a esto cada vez que se cree o modifique un pedido en la aplicación de escritorio cambiara al estado Registrado y Anulado o Confirmado se realiza desde 
la aplicación de Angular

• Los datos mínimos para el registro de ordenes de pedido son los siguientes:
o Cliente (Identificación, Nombre, Dirección) Actualmente estan almacenados en BDs
o Fecha de Registro : Se crea al momento de realizar la creacion de la orden
o Estado :  Se define independiente a los estados de la orden un estado tanto para la orden como para el detalle
o Dirección de Entrega : la dirección que se almacena en este campo se almacena de los datos del cliente con su dirección
o Prioridad (Se establece una regla para determinar la prioridad del pedido con base en el monto del mismo; Baja: <= $500, Media: > $500 y <=1000, Alta: >1000)
tambien realizado las condiciones para evular la prioridad 
o Lista de Productos:
▪ Producto (Código, Nombre)
▪ Valor Unitario
▪ Cantidad
▪ Valor Parcial - Estos campos tambien se almacenan al momento de crear o modificar
o Valor Total Pedido
Se almacena en la tabla de orden

La solución contara con dos componentes de presentación (UI Windows / Web). 
• El componente Windows (WinForms o WPF), se encargará de la administración (Creación/Edición) de la lista de ORDENES DE PEDIDOS registrados (tablas de clientes y productos podrán ser pobladas directamente sobre la base de datos de ser necesario).

Como se establecio se crearon clientes y productos directamente en BD, la aplicaci{on de escritorio se encuentra en WPF y realiza lo solicitado

• El Componente Web (Angular 11.x) se encargará de VISUALIZAR la lista de pedidos registrados y permitir al usuario la confirmación o anulación de los mismos (Cambio de estado).

Permite ver el resumen de la orden y cambiar el estado de anulado o confirmado

• Para la comunicación entre el componente Web y Base de Datos (BackEnd), se debe desarrollar un componente API (RestFul) en C# .NET Core que exponga los métodos necesarios para alcanzar la visualización deseada desde el FrontEnd.

Para el consumo de la solicitudes en Angular se creo un API RestFull que le envia la información necesaria como tambien las modificaciones 

• La comunicación de la capa de lógica de negocio y base de datos será definida por el desarrollador (Siéntase libre de usar un componente ORM si lo considera necesario).

para este caso debido a la experiencia se desarrollo con EntityFramework

---

Establecer la documentación necesaria para ejecutar la solución construida e información que considere de interés a través de un archivo README.txt

Se deja documentada la respuesta a los requerimientos ademas de las ubicaciones donde se encuentra el codigo fuente

• La solución contará con un sistema de versionamiento de código, por lo tanto, si construye un repositorio Git de acceso público (GitHub, BitBucket, etc) establecer el acceso al repositorio a través del archivo README.txt

Se encuentra tambien en GIT

• Se evaluará la implementación de principios SOLID en el código proporcionado, Temas de Clean Code serán tenidos en cuenta en la valoración de la prueba.

Para este caso se implemento Sigleton e Inyección de dependencias para el manejo del entity

• La separación de responsabilidades a través de capas y reúso de las mismas es de importancia.

Teniendo en cuenta la expeiencia se realiza en multiples capas 

• Test de Pruebas API UnitTest y/o JS Test tipo Jest construidos para la evaluación de métodos sumarian valor a la prueba.

No se realiza

• De ser necesario, proporcionar Script SQL para la construcción de la base de datos diseñada.

El script de la BD se encuentra en el escritorio

• Se valorará el nivel de normalización de base de datos logrado.


Se crean las respectivas tablas con su respectiva normalización y procedimientos almacenados

