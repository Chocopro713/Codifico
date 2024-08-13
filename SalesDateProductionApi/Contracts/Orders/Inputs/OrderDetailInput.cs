//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="OrderDetailInput.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------
namespace Contracts.Orders.Inputs;

/// <summary>
/// Detalla los elementos específicos de un producto en una orden.
/// </summary>
/// <param name="ProductId">Identificador del producto ordenado.</param>
/// <param name="UnitPrice">Precio unitario del producto en la orden.</param>
/// <param name="Qty">Cantidad del producto solicitado en la orden.</param>
/// <param name="Discount">Descuento aplicado sobre el producto en la orden.</param>
public record OrderDetailInput (
    int ProductId,
    decimal UnitPrice,
    int Qty,
    decimal Discount
);