Feature: Alquiler de un vehiculo 
  Scenario: Correcta peticion de alquiler
    Given que el usuario navega por la seccion "Buscar Autos"
    When complete toda la informacion solicitada
    And acciones el boton "Calcular"
    And accione el boton "Solicitar Alquiler"
    Then se redirigira a la seccion "Alquiler" mostrando su solicitud
  Scenario: Fallida peticion de alquiler
    Given que el usuario navega por la seccion "Buscar Autos"
    When no complete los campos con la informacion solicitada
    Then no se hara la accion de solicitar el alquiler
    