//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ProductResponse.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Contracts.Products.Response;

/// <summary>
/// Representa la información de respuesta de un producto.
/// </summary>
/// <param name="ProductId">Identificador único del producto.</param>
/// <param name="ProductName">Nombre del producto.</param>
public record ProductResponse(
    int ProductId,
    string ProductName
);