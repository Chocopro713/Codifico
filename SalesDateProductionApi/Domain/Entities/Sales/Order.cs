//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="Order.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

using Domain.Entities.HR;

namespace Domain.Entities.Sales;

/// <summary>
/// Representa una orden en el sistema de ventas.
/// </summary>
public class Order
{
    /// <summary>
    /// Identificador único de la orden.
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Identificador del cliente que realizó la orden. Puede ser nulo si la orden no está asociada a ningún cliente.
    /// </summary>
    public int? CustId { get; set; }

    /// <summary>
    /// Identificador del empleado que gestionó la orden.
    /// </summary>
    public int EmpId { get; set; }

    /// <summary>
    /// Fecha en que se realizó la orden.
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Fecha en que se requiere que la orden sea entregada.
    /// </summary>
    public DateTime RequiredDate { get; set; }

    /// <summary>
    /// Fecha en que la orden fue enviada. Puede ser nula si la orden aún no ha sido enviada.
    /// </summary>
    public DateTime? ShippedDate { get; set; }

    /// <summary>
    /// Identificador del transportista encargado de enviar la orden.
    /// </summary>
    public int ShipperId { get; set; }

    /// <summary>
    /// Costo del flete para el envío de la orden.
    /// </summary>
    public decimal Freight { get; set; }

    /// <summary>
    /// Nombre del destinatario del envío.
    /// </summary>
    public string ShipName { get; set; }

    /// <summary>
    /// Dirección de envío de la orden.
    /// </summary>
    public string ShipAddress { get; set; }

    /// <summary>
    /// Ciudad donde se debe enviar la orden.
    /// </summary>
    public string ShipCity { get; set; }

    /// <summary>
    /// Región o estado donde se debe enviar la orden.
    /// </summary>
    public string ShipRegion { get; set; }

    /// <summary>
    /// Código postal del destino de la orden.
    /// </summary>
    public string ShipPostalCode { get; set; }

    /// <summary>
    /// País de destino de la orden.
    /// </summary>
    public string ShipCountry { get; set; }

    /// <summary>
    /// Relación con el cliente que realizó la orden.
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    /// Relación con el empleado que gestionó la orden.
    /// </summary>
    public Employee Employee { get; set; }

    /// <summary>
    /// Relación con el transportista que envía la orden.
    /// </summary>
    public Shipper Shipper { get; set; }

    /// <summary>
    /// Relación con los detalles de la orden.
    /// </summary>
    /// <remarks>
    /// Esta colección representa los detalles de cada producto incluido en la orden. Cada detalle de la orden está asociado con la orden.
    /// </remarks>
    public ICollection<OrderDetail> OrderDetails { get; set; }

}