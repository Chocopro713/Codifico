//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="OrderDetail.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Domain.Entities.Sales;

using Domain.Entities.Production;

/// <summary>
/// Representa un detalle de una orden en el sistema de ventas.
/// </summary>
public class OrderDetail
{
    /// <summary>
    /// Identificador de la orden a la que pertenece el detalle.
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Identificador del producto incluido en el detalle de la orden.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Precio unitario del producto en el momento de la orden.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Cantidad del producto incluida en el detalle de la orden.
    /// </summary>
    public short Quantity { get; set; }

    /// <summary>
    /// Descuento aplicado al producto en el detalle de la orden.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Relación con la orden a la que pertenece este detalle.
    /// </summary>
    public virtual Order Order { get; set; }

    /// <summary>
    /// Relación con el producto que está incluido en el detalle de la orden.
    /// </summary>
    public virtual Product Product { get; set; }
}