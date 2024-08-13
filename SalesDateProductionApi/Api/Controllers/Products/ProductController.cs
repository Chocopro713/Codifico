//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ProductController.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Api.Controllers.Products;

using Application.Handlers.Products.Queries.Products;
using Base;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Contracts.Products.Response;

// Define la ruta base que se usará para acceder a los métodos de este controlador.
[Route("[controller]")]
public class ProductController : ApiController
{
    /// <summary>
    /// Define una variable para el servicio de mediador de MediatR.
    /// </summary>
    private readonly ISender _mediator;

    /// <summary>
    /// Constructor que inyecta dependencias necesarias para el controlador
    /// </summary>
    /// <param name="mediator"></param>
    public ProductController(
        ISender mediator)
    {
        // Asigna el mediador inyectado a la variable local.
        _mediator = mediator;
    }

    /// <summary>
    /// Define un método HTTP GET para obtener los productos.
    /// </summary>
    /// <returns>Una respuesta HTTP que contiene todos los productos</returns>
    [HttpGet("get-all-products")]
    public async Task<IActionResult> GetAllShippers()
    {
        try
        {
            // Crea una nueva instancia de la consulta.
            ProductQuery query = new();

            // Enviar la consulta utilizando MediatR y esperar la respuesta
            ErrorOr<List<ProductResponse>> result = await _mediator.Send(query);

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