//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="CustomerController.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Api.Controllers.Customers;

using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Handlers.Customers.Queries.NextOrderDate;
using Contracts.Customers.Response;
using Microsoft.AspNetCore.Cors;

/// <summary>
/// Controlador para la gestión de clientes.
/// </summary>
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    /// <summary>
    /// Define una variable para el servicio de mediador de MediatR.
    /// </summary>
    private readonly ISender _mediator;

    /// <summary>
    /// Constructor que inyecta dependencias necesarias para el controlador.
    /// </summary>
    /// <param name="mediator"></param>
    public CustomerController(ISender mediator)
    {
        // Asigna el mediador inyectado a la variable local.
        _mediator = mediator;
    }
    
    /// <summary>
    /// Obtiene la fecha de la próxima orden.
    /// </summary>
    /// <returns>Una respuesta HTTP que contiene la información de la próxima orden para el cliente.</returns>
    [HttpGet("next-order-date")]
    public async Task<IActionResult> GetNextOrderDate()
    {
        try
        {
            // Crear una consulta para obtener la próxima fecha de orden
            NODQuery query = new();
            
            // Enviar la consulta utilizando MediatR y esperar la respuesta
            ErrorOr<List<NextOrderDateResponse>> result = await _mediator.Send(query);

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