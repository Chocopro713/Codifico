//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="NextOrderDateResponse.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Contracts.Customers.Response;

/// <summary>
/// Representa una solicitud para obtener la fecha de la próxima orden de un cliente.
/// </summary>
/// <param name="CustomerName">El nombre del cliente.</param>
/// <param name="LastOrderDate">La fecha de la última orden realizada por el cliente.</param>
/// <param name="NextPredictedOrder">La fecha prevista para la próxima orden del cliente.</param>
public record NextOrderDateResponse(
    int CustId,
    string CustomerName,
    DateTime LastOrderDate,
    DateTime NextPredictedOrder);