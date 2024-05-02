Feature: Actualizacion de datos del usuario
  Scenario: Correcta actualizacion de datos
    Given que el usuario navega por la seccion "Perfil"
    When ingrese a la opcion "Actualizar Datos"
    And complete de ingresar toda la informacion solicitada
    And acciona el boton "Actualizar"
    Then se mostraran los datos actualizados en su perfil
  Scenario: Fallida actualizacion de datos
    Given que el usuario navega por la seccion "Perfil"
    When ingrese a la opcion "Actualizar Datos"
    And ingrese parcialmente la informacion solicitada
    And acciona el boton "Actualizar"
    Then no se actualizaran los cambios
  Scenario: Ingreso accidental a la opcion de actualizacion de datos
    Given que el usuario navega por la seccion "Perfil"
    When ingrese a la opcion "Actualizar Datos"
    And acciona el boton "Cancelar"
    Then no se actualizaran los cambios