Feature: Permitir o denegar el alquiler del vehiculo
  Scenario: 
    Given que el usuario tenga peticiones sobre alquiler de su vehiculo
    And navegue por la seccion "Alquiler"
    When accione en el boton "Ver solicitud" de una publicacion
    And accione el boton "Aceptar"
    Then se actualizara la pagina, cambiando el estado de solicitud del vehiculo
  Scenario:
    Given que el usuario tenga peticiones sobre alquiler de su vehiculo
    And navegue por la seccion "Alquiler"
    When accione en el boton "Ver solicitud" de una publicacion
    And accione el boton "Declinar"
    Then se actualizara la pagina, cambiando el estado de solicitud del vehiculo