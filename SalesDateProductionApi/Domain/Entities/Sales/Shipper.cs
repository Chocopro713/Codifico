//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="Shipper.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Domain.Entities.Sales;

/// <summary>
/// Representa un transportista en el sistema de ventas.
/// </summary>
public class Shipper
{
    /// <summary>
    /// Identificador único del transportista.
    /// </summary>
    public int ShipperId { get; set; }

    /// <summary>
    /// Nombre de la empresa del transportista.
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// Número de teléfono del transportista.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Relación con las órdenes enviadas por el transportista.
    /// </summary>
    public virtual ICollection<Order> Orders { get; set; }
}