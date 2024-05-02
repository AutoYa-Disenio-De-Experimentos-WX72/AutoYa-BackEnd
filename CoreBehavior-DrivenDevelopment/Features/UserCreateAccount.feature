Feature: Creacion de una cuenta 
  Scenario: Creacion exitosa de la cuenta
    Given que el usuario ingresa a la aplicacion
    When presione el boton "Crear Cuenta"
    And complete toda la informacion solicitada
    And acciona el boton "Registrar"
    Then se mostrara un mensaje indicando la correcta operacion
  Scenario: Creacion fallida de la cuenta
    Scenario: Ingreso de datos parcial
      Given que el usuario ingresa a la aplicacion
      When presione el boton "Crear Cuenta"
      And complete de forma parcial la informacion solicitada
      And acciona el boton "Registrar"
      Then se mostrara un mensaje indicando la fallida operacion
    Scenario: Ingreso de datos repetidos
      Given que el usuario ingresa a la aplicacion
      When presione el boton "Crear Cuenta"
      And complete toda la informacion solicitada repitiendo datos ya existentes
      And acciona el boton "Registrar"
      Then se mostrara un mensaje indicando la fallida operacion