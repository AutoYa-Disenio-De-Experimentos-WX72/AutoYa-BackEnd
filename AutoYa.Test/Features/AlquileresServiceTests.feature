Feature: AlquilerServiceTests
As a arrendatario
I want to rent a vehicle from AutoYa's system
In order to use it for a specific period

    Background: 
        Given the Endpoint http://localhost:5267/api/v1/alquileres is available
    
    @alquiler-adding
    Scenario: Add alquiler
    
        When a Post Request for alquiler is sent
          | Estado    | FechaInicio              | FechaFin                 | CostoTotal | VehiculoId | PropietarioId | ArrendatarioId |
          | CONFIRMED | 2023-11-18T18:18:35.462Z | 2023-11-18T18:18:35.462Z | 700          | 1          | 1             | 2              |

        Then a Response for alquiler is received with Status 200
    
        And an alquiler Resource is included in Response body
          | Id | Estado    | FechaInicio              | FechaFin                 | CostoTotal | PropietarioId | ArrendatarioId | VehiculoId |
          | 1  | CONFIRMED | 2023-11-18T18:17:36.116Z | 2023-11-18T18:17:36.116Z | 700        | 1             | 2              | 1          |