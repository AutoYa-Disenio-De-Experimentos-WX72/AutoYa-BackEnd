Feature: Creacion de un registro de mantenimiento
  Scenario: Correcto registro
    Given que el usuario navega por la seccion "Mantenimiento"
    When complete la informacion solicitada en el formulario
    And acciona el boton "Enviar"
    Then se mostrara una notificacion de la correcta operacion
  Scenario: Registro fallido
    Given que el usuario navega por la seccion "Mantenimiento"
    When no complete la informacion solicitada en el formulario
    And acciona el boton "Enviar"
    Then no se registrara aquella informacion
    