<h1>DigitalWare DaVinci Diego ApplyTest</h1>
<h4>DigitalWare DaVinci Apply Test By Diego Arenas Tangarife</h4>
<hr>
<h3>Descripción</h3>
<p>Proyecto creado con .NET 5, usando el modelo de arquitectura de n-tier (n-capas) y modelo estructural MVC para el API. Usando Entity Framework Core como ORM para acceder a la base de datos, la cual está alojada en un motor MS SQL Server. Se usó el patrón de disañe <i>repositorio</i> para establecer las responsabilidades en cada controlador y/o servicios de lógica de negocio, además para facilitar el cambio de acceso a datos sin afectar lo actualmente implementado. Se buscó aplicar los mejores estándares de código limpio y buenas prácticas de desarollo.</p>
<p>Se usó la característica de Entity framework core <i>Database First</i>, partiendo del modelo de datos creado previmente (Es un modelo relacional).</p>
<h4><a href="http://lotesik756-001-site1.ftempurl.com/swagger/index.html" target"_blank" >Live Demo</a></h4>
<hr>

<h3>Intrucciones</h3>
<ol>
  <li>Se debe descargar y ejecutar el script para la creación de la <b>base de datos</b>, dando clic <a href="https://drive.google.com/file/d/14PDiytIMUYvsZFDavdstXaHvwqiAE6vm/view?usp=sharing" target"_blank" >Aquí</a>
  </li>
  <li>Cambiar el string de conexión (de ser necesario) en el archivo appSettings.json </li>
  <li><i>(Opcional)</i> Si desea restaurar la base de datos con <b>datos de prueba</b>, de clic <a href="https://drive.google.com/file/d/1iPEyTzAmcPSWNL5uXX8tZ1zUGWlONhdC/view?usp=sharing" target"_blank" >Aquí</a></li>
  <li>Para crear datos de prueba se expone el endpoint <code><a href="http://lotesik756-001-site1.ftempurl.com/swagger/index.html" target"_blank" >ExperimentalData</a></code> con los métodos de creación de clientes, productos y facturas de prueba
  <br>
    <img src="https://user-images.githubusercontent.com/42014718/113944396-0f406b00-97ca-11eb-9489-973dd111b949.png" title="Api" alt="Api" />
  </li>
  <li>Se debe descargar y ejecutar el script para obtener los resultados de los ejercicios propuestos, dando clic <a href="https://drive.google.com/file/d/1jN5J7DQEHCsHoN-KP3RQ66eOM6qPvyhY/view?usp=sharing" target"_blank" >Aquí</a><br>
  Se obtendrá algo como lo siguiente:<br>
    <img src="https://user-images.githubusercontent.com/42014718/113943367-2bdba380-97c8-11eb-9be3-d01d330a20ca.png" title="Ejercicio 1" alt="Ejercicio 1" />
  </li>Se expone un <b>API</b> que tiene los métodos CRUD para <i>Productos</i> y <i>Facturas</i>, además de exponer métodos que retornan los resultados del ejercicio anterior. Para acceder a la API, de clic <a href="http://lotesik756-001-site1.ftempurl.com/swagger/index.html" target"_blank" >Aquí</a>
  <br>
  Un ejemplo de ejecución sería: <br>
  <img src="https://user-images.githubusercontent.com/42014718/113936836-fd58cb00-97bd-11eb-8d8c-08365a697c55.gif" title="Ejercicio 1" alt="Ejercicio 1" />
  </li>
</ol>
