Feature: Usuario crea una publicacion de un vehiculo
  Scenario: Creacion exitosa de la publicacion
    Given que el usuario navega por la seccion "Registrar"
    When complete de ingresar toda la informacion solicitada
    And acciona el boton "Registar"
    Then se mostrara una notificacion del correcto guardado de datos
  Scenario: Creacion erronea de la publicacion
    Given que el usuario navega por la seccion "Registrar"
    When complete parcialmente la informacion solicitada
    And acciona el boton "Registar"
    Then se mostrara una notificacion especificando un error al registrar