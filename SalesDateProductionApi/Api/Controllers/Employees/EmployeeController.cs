//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="EmployeeController.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------


namespace Api.Controllers.Employees;

using Application.Handlers.Employees.Queries.Employees;
using MediatR;
using Base;
using Contracts.Employees.Response;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controlador para la gestión de empleados.
/// </summary>
[Route("[controller]")]
public class EmployeeController : ApiController
{
    /// <summary>
    /// Define una variable para el servicio de mediador de MediatR.
    /// </summary>
    private readonly ISender _mediator;

    /// <summary>
    /// Constructor que inyecta dependencias necesarias para el controlador.
    /// </summary>
    /// <param name="mediator"></param>
    public EmployeeController(
        ISender mediator)
    {
        // Asigna el mediador inyectado a la variable local.
        _mediator = mediator;
    }

    /// <summary>
    /// Obtiene todos los empleados
    /// </summary>
    /// <returns>Una respuesta HTTP que contiene la información de todos los empleados</returns>
    [HttpGet("get-all-employees")]
    public async Task<IActionResult> GetAllEmployees()
    {
        try
        {
            // Crear una nueva instancia de la consulta para obtener todos los empleados
            EmployeesQuery query = new();

            // Enviar la consulta utilizando MediatR y esperar la respuesta
            ErrorOr<List<EmployeeResponse>> result = await _mediator.Send(query);

            // Devolver la respuesta al cliente en función del resultado de la consulta
            return result.Match(
                result => Ok(result),
                errors => Problem(string.Join("; ", errors.Select(e => e.Description))));
        }
        catch (Exception e)
        {
            // Manejar excepciones y devolver un mensaje de error con el estado HTTP 500
            return Problem(e.Message);
        }
    }
}