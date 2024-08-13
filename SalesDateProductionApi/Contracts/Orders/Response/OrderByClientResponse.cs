//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="OrderByClientResponse.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Contracts.Orders.Response;

/// <summary>
/// Representa la respuesta de los detalles de una orden específica asociada a un cliente.
/// </summary>
/// <param name="OrderId">Identificador único de la orden.</param>
/// <param name="RequiredDate">Fecha en la que se requiere que la orden sea completada o entregada.</param>
/// <param name="ShippedDate">Fecha en la que la orden fue enviada. Puede ser nula si la orden aún no ha sido enviada.</param>
/// <param name="ShipName">Nombre del destinatario de la orden.</param>
/// <param name="ShipAddress">Dirección de envío de la orden.</param>
/// <param name="ShipCity">Ciudad a la que se envía la orden.</param>
public record OrderByClientResponse(
    int OrderId,
    DateTime RequiredDate,
    DateTime? ShippedDate,
    string ShipName,
    string ShipAddress,
    string ShipCity
);
