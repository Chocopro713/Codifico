//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="OrderController.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------


namespace Api.Controllers.Orders;

using Application.Handlers.Orders.Queries.OrdersByClient;
using Base;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Contracts.Orders.Response;
using Contracts.Common.StoreProcedure.Response;
using Application.Handlers.Orders.Commands.CreateOrderWithProduct;
using Contracts.Orders.Inputs;

// Define la ruta base que se usará para acceder a los métodos de este controlador.
[Route("[controller]")]
public class OrderController : ApiController
{
    /// <summary>
    /// Define una variable para el servicio de mediador de MediatR.
    /// </summary>
    private readonly ISender _mediator;

    /// <summary>
    /// Constructor que inyecta dependencias necesarias para el controlador.
    /// </summary>
    /// <param name="mediator"></param>
    public OrderController(
        ISender mediator)
    {
        // Asigna el mediador inyectado a la variable local.
        _mediator = mediator;
    }

    /// <summary>
    /// Define un método HTTP GET para obtener órdenes por ID de cliente.
    /// </summary>
    /// <param name="custid"></param>
    /// <returns>Una respuesta HTTP que contiene la información de todos las ordenes</returns>
    [HttpGet("all-order/{custid}")]
    public async Task<IActionResult> GetOrderByCustomerId(int custid)
    {
        try
        {
            // Crea una nueva instancia de la consulta con el ID del cliente.
            OBCQuery query = new(custid);

            // Envía la consulta al mediador y espera la respuesta.
            ErrorOr<List<OrderByClientResponse>> result = await _mediator.Send(query);

            // Maneja el resultado: devuelve un resultado exitoso o un problema en caso de errores.
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

    /// <summary>
    /// Define un método HTTP POST para crear una nueva orden con detalles del producto.
    /// </summary>
    /// <param name="createOrderAndDetailInput"></param>
    /// <returns>Una respuesta HTTP que contiene la un mensaje de exitoso o error</returns>
    [HttpPost("create-order-with-detail")]
    public async Task<IActionResult> CreateOrderWithProduct(CreateOrderAndDetailInput createOrderAndDetailInput)
    {
        try
        {
            // Crea una nueva instancia de la consulta con los datos de la orden y los detalles del producto.
            COWPQuery query = new(createOrderAndDetailInput);

            // Envía la consulta al mediador y espera la respuesta.
            ErrorOr<StoreProcedureResponse> result = await _mediator.Send(query);

            // Maneja el resultado: devuelve un resultado exitoso o un problema en caso de errores.
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