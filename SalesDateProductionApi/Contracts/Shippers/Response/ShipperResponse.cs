//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ShipperResponse.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Contracts.Shippers.Response;

/// <summary>
/// Representa la información de respuesta de un transportista.
/// </summary>
/// <param name="ShipperId">Identificador único del transportista.</param>
/// <param name="CompanyName">Nombre de la compañía del transportista.</param>
public record ShipperResponse(
    int ShipperId,
    string CompanyName
);