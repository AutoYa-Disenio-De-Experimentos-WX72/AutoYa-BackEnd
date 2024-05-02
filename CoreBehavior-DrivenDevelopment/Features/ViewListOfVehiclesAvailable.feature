Feature: Visualizacion de los vehiculos disponibles
  Scenario: Visualización de publicaciones exitosa
    Given que existan publicaciones registradas
    When el usuario navegue por la seccion "Buscar autos"
    Then se mostraran todos los vehiculos disponibles
  Scenario: Imposible visualizacion de publicaciones
    Given que no existan publicaciones registradas
    When el usuario navegue por la seccion "Buscar autos"
    Then no se mostrara un texto donde especifique la nula informacion respecto al tema