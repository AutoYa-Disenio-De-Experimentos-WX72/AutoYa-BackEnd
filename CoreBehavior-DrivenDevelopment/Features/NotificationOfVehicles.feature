Feature: Notificaciones sobre vehiculos solicitados para alquiler
  Scenario: Recepcion exitosa de la notificacion
    Given que el usuario tenga una publicacion registrada
    And otro usuario opto por alquilar su vehiculo
    When el usuario navegue por la seccion de "Notificaciones"
    Then se mostrar recuadros dando informacion del estado de su publicacion
  Scenario: Ninguna recepcion de notificaciones por parte de sus publicaciones
    Given no tenga ninguna publicacion registrada
    When el usuario navegue por la seccion de "Notificaciones"
    Then se mostrara un texto informando que no tiene notificaciones disponibles