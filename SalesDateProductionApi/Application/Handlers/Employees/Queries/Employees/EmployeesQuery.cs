//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="EmployeesQuery.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

// Importa las dependencias necesarias para el manejo de la respuesta y para integrar con MediatR.
using Contracts.Employees.Response;
using ErrorOr;
using MediatR;

// Define el espacio de nombres adecuado para organizar el código relacionado con consultas de empleados dentro del dominio de empleados.
namespace Application.Handlers.Employees.Queries.Employees;

// Define un record en C# que representa una consulta de tipo IRequest implementada por MediatR.
// Este record, EmployeesQuery, no necesita parámetros en su constructor y se utiliza para solicitar una lista de EmployeeResponse.
public record EmployeesQuery() : IRequest<ErrorOr<List<EmployeeResponse>>>;