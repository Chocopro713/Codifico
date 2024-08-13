//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ShipperController.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------


namespace Api.Controllers.Shippers;

using Application.Handlers.Employees.Queries.Employees;
using Base;
using Contracts.Employees.Response;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using MediatR;

// Define la ruta base que se usará para acceder a los métodos de este controlador.
[Route("[controller]")]
public class ShipperController : ApiController
{
    /// <summary>
    /// Define una variable para el servicio de mediador de MediatR.
    /// </summary>
    private readonly ISender _mediator;

    /// <summary>
    /// Constructor que inyecta dependencias necesarias para el controlador
    /// </summary>
    /// <param name="mediator"></param>
    public ShipperController(
        ISender mediator)
    {
        // Asigna el mediador inyectado a la variable local.
        _mediator = mediator;
    }

    /// <summary>
    /// Define un método HTTP GET para obtener los transportistas
    /// </summary>
    /// <returns>Una respuesta HTTP que contiene todos los transportistas</returns>
    [HttpGet("get-all-shippers")]
    public async Task<IActionResult> GetAllShippers()
    {
        try
        {
            // Crea una nueva instancia de la consulta.
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