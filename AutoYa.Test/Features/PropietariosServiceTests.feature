Feature: PropietariosServiceTests
As a propietario
I want to add my information to AutoYa's system
In order to make it available for applications.

    Background: 
        Given the Endpoint http://localhost:5267/api/v1/propietarios is available
	
    @propietario-adding
    Scenario: Add propietario with unique Email
		
        When a Post Request for propietario is sent
          | Nombres | Apellidos | FechaNacimiento          | Telefono  | Correo            | Contrasenia |
          | Erick   | Urbi      | 2023-11-18T16:07:53.406Z | 123456789 | erick@hotmail.com | password    |
   
        Then a Response for propietario is received with Status 200
		
        And an propietario Resource is included in Response body
          |Id | Nombres | Apellidos | FechaNacimiento          | Telefono  | Correo            | Contrasenia |
          | 1 | Erick   | Urbi      | 2023-11-18T16:07:53.406Z | 123456789 | erick@hotmail.com | password    |
   
    @propietario-adding
    Scenario: Add propietario with existing Email
		
        Given An propietario is already stored
          |Id | Nombres | Apellidos | FechaNacimiento          | Telefono  | Correo              | Contrasenia |
          | 1 | Gabriel | Alvarez   | 2023-11-18T16:07:53.406Z | 987654321 | gabriel@hotmail.com | password2   |
    
        When a Post Request for propietario is sent
          | Nombres | Apellidos | FechaNacimiento          | Telefono  | Correo              | Contrasenia |
          | Gabriel | Alvarez   | 2023-11-18T16:07:53.406Z | 987654321 | gabriel@hotmail.com | password2   |
    
        Then a Response for propietario is received with Status 400
		
        And An Error Message for propietario is returned with value "Ya existe un propietario registrado con el correo electrónico gabriel@hotmail.com."