//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="EmployeeResponse.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Contracts.Employees.Response;

/// <summary>
/// Representa la respuesta de datos de un empleado.
/// </summary>
/// <param name="EmpId">Identificador único del empleado.</param>
/// <param name="FullName">Nombre completo del empleado.</param>
public record EmployeeResponse (
    int EmpId,
    string FullName
    );