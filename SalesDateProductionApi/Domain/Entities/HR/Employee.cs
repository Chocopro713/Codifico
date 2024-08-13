//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ModelStateValidator.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Domain.Entities.HR;

using Domain.Entities.Sales;

/// <summary>
/// Representa un empleado en la entidad de recursos humanos.
/// </summary>
public class Employee
{
    /// <summary>
    /// Identificador único del empleado.
    /// </summary>
    public int EmpId { get; set; }

    /// <summary>
    /// Apellido del empleado.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Nombre del empleado.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Título del empleado (p.ej., "Gerente").
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Título de cortesía del empleado (p.ej., "Sr." o "Sra.").
    /// </summary>
    public string TitleOfCourtesy { get; set; }

    /// <summary>
    /// Fecha de nacimiento del empleado.
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Fecha de contratación del empleado.
    /// </summary>
    public DateTime HireDate { get; set; }

    /// <summary>
    /// Dirección del empleado.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Ciudad del empleado.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Región del empleado (p.ej., estado o provincia).
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Código postal del empleado.
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// País del empleado.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Teléfono del empleado.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Identificador del gerente del empleado (si aplica).
    /// </summary>
    public int? MgrId { get; set; }

    /// <summary>
    /// Relación de auto-referencia con el gerente del empleado.
    /// </summary>
    /// <remarks>
    /// Este campo establece una relación de jerarquía entre empleados, donde un empleado puede tener otro empleado como gerente.
    /// </remarks>
    public virtual Employee Manager { get;  set; }

    /// <summary>
    /// Relación con los pedidos realizados por el empleado.
    /// </summary>
    /// <remarks>
    /// Un empleado puede estar asociado con varios pedidos. Esta colección representa todos los pedidos realizados por el empleado.
    /// </remarks>
    public virtual ICollection<Order> Orders { get;  set; }
}