Feature: VehiculosServiceTests
As a arrendatario
I want to add my vehicule's information to AutoYa's system
In order to make it available for applications.

    Background: 
        Given the Endpoint http://localhost:5267/api/v1/vehiculos is available
    
    @vehiculo-adding
    Scenario: Add vehiculo
    
        When a Post Request for vehiculo is sent
          | Marca  | Modelo | VelocidadMax | Consumo | Dimensiones | Peso | Clase | Transmision | Tiempo | TipoTiempo | CostoAlquiler | LugarRecojo | UrlImagen | ContratoAlquilerPdf | EstadoRenta | propietarioId | arrendatarioId | alquilerId |
          | Toyota | Camry  | 200          | 8       | Medium      | 1500 | Sedan | Automatica  | 5      | Día        | 50            | Lima        | image.jpg | contrato.pdf        | Disponible  | 1             | null              | null          |

        Then a Response for vehiculo is received with Status 200
    
        And a vehiculo Resource is included in Response body
          | Id | Marca | Modelo | VelocidadMax | Consumo | Dimensiones | Peso | Clase | Transmision | Tiempo | TipoTiempo | CostoAlquiler | LugarRecojo | UrlImagen | ContratoAlquilerPdf | EstadoRenta | propietario.id | propietario.nombres | propietario.apellidos | propietario.fechaNacimiento | propietario.telefono | propietario.correo | propietario.contrasenia | arrendatario | alquiler |
          | 1  | Toyota | Camry  | 200          | 8       | Medium      | 1500 | Sedan | Automatica  | 5      | Día        | 50            | Lima        | image.jpg | contrato.pdf        | Disponible  |  1 | "Erick" | "Urbi" | "2023-11-18T11:07:53.406" | 123456789 | "erick@hotmail.com" | "password" | null | null |