//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="Supplier.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Domain.Entities.Production;

/// <summary>
/// Representa un proveedor en el sistema de producción.
/// </summary>
public class Supplier
{
    /// <summary>
    /// Identificador único del proveedor.
    /// </summary>
    public int SupplierId { get; set; }

    /// <summary>
    /// Nombre de la empresa del proveedor.
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// Nombre del contacto principal en la empresa del proveedor.
    /// </summary>
    public string ContactName { get; set; }

    /// <summary>
    /// Título del contacto principal en la empresa del proveedor.
    /// </summary>
    public string ContactTitle { get; set; }

    /// <summary>
    /// Dirección de la empresa del proveedor.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Ciudad donde se encuentra la empresa del proveedor.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Región o estado donde se encuentra la empresa del proveedor.
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Código postal de la dirección de la empresa del proveedor.
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// País donde se encuentra la empresa del proveedor.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Número de teléfono de la empresa del proveedor.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Número de fax de la empresa del proveedor.
    /// </summary>
    public string Fax { get; set; }

    /// <summary>
    /// Relación con los productos suministrados por el proveedor.
    /// </summary>
    /// <remarks>
    /// Esta colección representa todos los productos que el proveedor suministra. Cada producto en esta colección está asociado con el proveedor.
    /// </remarks>
    public virtual ICollection<Product> Products { get; set; }
}