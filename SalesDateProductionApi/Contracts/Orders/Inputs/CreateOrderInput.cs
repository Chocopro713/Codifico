//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="CreateOrderInput.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Contracts.Orders.Inputs;

/// <summary>
/// Contiene la información necesaria para crear una nueva orden en el sistema.
/// </summary>
/// <param name="CustId">Identificador del cliente que gestiona la orden.</param>
/// <param name="EmpId">Identificador del empleado que gestiona la orden.</param>
/// <param name="ShipperId">Identificador del transportista para la entrega de la orden.</param>
/// <param name="ShipName">Nombre del destinatario de la orden.</param>
/// <param name="ShipAddress">Dirección de envío de la orden.</param>
/// <param name="ShipCity">Ciudad de destino de la orden.</param>
/// <param name="OrderDate">Fecha en que se realiza la orden.</param>
/// <param name="RequiredDate">Fecha en que se requiere la entrega de la orden.</param>
/// <param name="ShippedDate">Fecha en que se realiza el envío (puede ser nulo si aún no se ha enviado).</param>
/// <param name="Freight">Costo de transporte asociado con la orden.</param>
/// <param name="ShipCountry">País de destino de la orden.</param>
public record CreateOrderInput(
    int CustId,
    int EmpId,
    int ShipperId,
    string ShipName,
    string ShipAddress,
    string ShipCity,
    DateTime OrderDate,
    DateTime RequiredDate,
    DateTime? ShippedDate,
    decimal Freight,
    string ShipCountry
);