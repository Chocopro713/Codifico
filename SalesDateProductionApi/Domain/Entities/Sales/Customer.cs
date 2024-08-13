//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="Customer.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Domain.Entities.Sales;

/// <summary>
/// Representa a un cliente en el sistema de ventas.
/// </summary>
public class Customer
{
    /// <summary>
    /// Identificador único del cliente.
    /// </summary>
    public int CustId { get; set; }

    /// <summary>
    /// Nombre de la empresa del cliente.
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// Nombre del contacto principal en la empresa del cliente.
    /// </summary>
    public string ContactName { get; set; }

    /// <summary>
    /// Título del contacto principal en la empresa del cliente.
    /// </summary>
    public string ContactTitle { get; set; }

    /// <summary>
    /// Dirección de la empresa del cliente.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Ciudad donde se encuentra la empresa del cliente.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Región o estado donde se encuentra la empresa del cliente.
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Código postal de la dirección de la empresa del cliente.
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// País donde se encuentra la empresa del cliente.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Número de teléfono de la empresa del cliente.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Número de fax de la empresa del cliente.
    /// </summary>
    public string Fax { get; set; }

    /// <summary>
    /// Relación con las órdenes realizadas por el cliente.
    /// </summary>
    /// <remarks>
    /// Esta colección representa todas las órdenes que el cliente ha realizado. Cada orden en esta colección está asociada con el cliente.
    /// </remarks>
    public virtual ICollection<Order> Orders { get; set; }
}