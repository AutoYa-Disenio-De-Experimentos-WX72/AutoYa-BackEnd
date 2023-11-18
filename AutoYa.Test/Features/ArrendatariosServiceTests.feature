Feature: ArrendatariosServiceTests
	As a arrendatario
	I want to add my information to AutoYa's system
	In order to make it available for applications.	

	Background: 
		Given the Endpoint http://localhost:5267/api/v1/arrendatarios is available
	
	@arrendatario-adding
	Scenario: Add Arrendatario with unique Email
		
		When a Post Request for arrendatario is sent
			| Nombres | Apellidos | FechaNacimiento          | Telefono  | Correo            | AntecedentesPenalesPdf | Contrasenia |
			| Erick   | Urbi      | 2023-11-18T16:07:53.406Z | 123456789 | erick@hotmail.com | misAntecedentes        | password    |
   
		Then a Response is received with Status 200
		
		And an Arrendatario Resource is included in Response body
		  	|Id		| Nombres | Apellidos | FechaNacimiento | Telefono                 | Correo    | AntecedentesPenalesPdf | Contrasenia     |
			| 1     | Erick     | Urbi            | 2023-11-18T16:07:53.406Z | 123456789 | erick@hotmail.com      | misAntecedentes | password |
   
	@arrendatario-adding
	Scenario: Add Arrendatario with existing Email
		
		Given An Arrendatario is already stored
		  |Id | Nombres   | Apellidos    | FechaNacimiento          | Telefono  | Correo              | AntecedentesPenalesPdf  | Contrasenia  |
		  | 1 | Gabriel   | Alvarez      | 2023-11-18T16:07:53.406Z | 987654321 | gabriel@hotmail.com | misAntecedentes2        | password2    |
    
		When a Post Request for arrendatario is sent
		  | Nombres   | Apellidos 		| FechaNacimiento 		   | Telefono  | Correo   			    | AntecedentesPenalesPdf | Contrasenia |
		  | Gabriel   | Alvarez         | 2023-11-18T16:07:53.406Z | 987654321 | gabriel@hotmail.com    | misAntecedentes2 		 | password2   |
    
		Then a Response is received with Status 400
		
		And An Error Message for arrendatario is returned with value "Ya existe un arrendatario registrado con el correo electrónico gabriel@hotmail.com."