//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="Category.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Domain.Entities.Production;

/// <summary>
/// Representa una categoría de productos en el sistema de producción.
/// </summary>
public class Category
{
    /// <summary>
    /// Identificador único de la categoría.
    /// </summary>
    public int CategoryId { get;  set; }

    /// <summary>
    /// Nombre de la categoría.
    /// </summary>
    public string CategoryName { get;  set; }

    /// <summary>
    /// Descripción detallada de la categoría.
    /// </summary>
    public string Description { get;  set; }

    /// <summary>
    /// Relación con los productos asociados a la categoría.
    /// </summary>
    /// <remarks>
    /// Una categoría puede estar asociada con varios productos. Esta colección representa todos los productos que pertenecen a la categoría.
    /// </remarks>
    public virtual ICollection<Product> Products { get;  set; }
}