//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="Product.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

using Domain.Entities.Sales;

namespace Domain.Entities.Production;

/// <summary>
/// Representa un producto en el sistema de producción.
/// </summary>
public class Product
{
    /// <summary>
    /// Identificador único del producto.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Nombre del producto.
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Identificador del proveedor asociado al producto.
    /// </summary>
    public int SupplierId { get; set; }

    /// <summary>
    /// Identificador de la categoría a la que pertenece el producto.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Precio unitario del producto.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Indica si el producto ha sido descontinuado.
    /// </summary>
    public bool Discontinued { get; set; }

    /// <summary>
    /// Relación con el proveedor del producto.
    /// </summary>
    /// <remarks>
    /// Esta propiedad establece una relación con la entidad <see cref="Supplier"/> que representa al proveedor del producto.
    /// </remarks>
    public virtual Supplier Supplier { get; set; }

    /// <summary>
    /// Relación con la categoría a la que pertenece el producto.
    /// </summary>
    /// <remarks>
    /// Esta propiedad establece una relación con la entidad <see cref="Category"/> que clasifica el producto en una categoría específica.
    /// </remarks>
    public virtual Category Category { get; set; }

    /// <summary>
    /// Relación con los detalles de los pedidos en los que está incluido el producto.
    /// </summary>
    /// <remarks>
    /// Esta colección representa todos los detalles de los pedidos que contienen este producto. 
    /// Cada detalle de pedido especifica la cantidad y el precio del producto en el contexto de un pedido específico.
    /// </remarks>
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}