Feature: Visualizacion del estado de las publicaciones
  Scenario: Correcta visualizacion del estado de las publicaciones
    Given que el usuario tenga publicaciones registradas
    When navegue por la seccion "Alquiler"
    Then se mostrara el status de cada publicacion de acuerdo a los estados definidos
  Scenario: Incorrecta visualizacion del estado de las publicaciones
    Given que el usuario no tenga publicaciones registradas
    When navegue por la seccion "Alquiler"
    Then se mostrara un texto especificando que no posee informacion al respecto