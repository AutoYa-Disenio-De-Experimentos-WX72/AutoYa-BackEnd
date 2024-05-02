Feature: Usuario elimana un publicacion sobre su vehiculo
  Scenario: Correcta eliminacion de la publicacion
    Given que el usuario tenga una publicacion registrada
    And navegue por la seccion "Alquileres"
    When accione el boton "Eliminar publicacion"
    Then se eliminara la publicacion del usuario
  Scenario: Ausencia de la publicacion
    Given que el usuario no tenga una publicacion registrada
    When navegue por la seccion "Alquileres"
    Then se mostrara un texto informando que no tiene publicaciones que eliminar