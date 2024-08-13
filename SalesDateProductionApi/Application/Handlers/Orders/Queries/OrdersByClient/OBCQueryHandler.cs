//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="OBCQueryHandler.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Handlers.Orders.Queries.OrdersByClient;

// Importa las dependencias necesarias para la ejecución de la consulta.
using Application.Services.Orders;
using Contracts.Orders.Response;
using ErrorOr;
using MediatR;

/// <summary>
/// Maneja las consultas para obtener todas las órdenes asociadas a un cliente específico.
/// </summary>
public class OBCQueryHandler : IRequestHandler<OBCQuery, ErrorOr<List<OrderByClientResponse>>>
{
    // Servicio que provee la lógica para acceder a las órdenes en la base de datos.
    private readonly OrderQueryService _orderQueryService;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="OBCQueryHandler"/> con un servicio para consultar órdenes.
    /// </summary>
    /// <param name="orderQueryService">El servicio que proporciona acceso a las órdenes en la base de datos.</param>
    public OBCQueryHandler(OrderQueryService orderQueryService)
    {
        _orderQueryService = orderQueryService;
    }

    /// <summary>
    /// Maneja la consulta para obtener las órdenes de un cliente específico.
    /// </summary>
    /// <param name="query">Consulta que contiene el ID del cliente del cual obtener las órdenes.</param>
    /// <param name="cancellationToken">Token de cancelación que permite cancelar la operación.</param>
    /// <returns>Una lista de respuestas de órdenes para el cliente o un error si no se encuentran órdenes o hay un problema en la base de datos.</returns>
    public async Task<ErrorOr<List<OrderByClientResponse>>> Handle(OBCQuery query, CancellationToken cancellationToken)
    {
        try
        {
            // Solicita al servicio de consultas de órdenes que recupere todas las órdenes asociadas al ID del cliente proporcionado.
            List<OrderByClientResponse> results = await _orderQueryService.GetOrdersByClient(query.custId);

            // Verifica si la consulta devolvió algún resultado.
            if (results.Count == 0)
                // Devuelve un error indicando que no se encontraron órdenes para el cliente.
                return Error.NotFound("Orders.NotFound", "Orders not found.");

            // Si se encontraron resultados, devuelve la lista de respuestas de órdenes.
            return results;
        }
        catch (Exception ex)
        {
            // Devuelve un error general indicando un problema con la base de datos.
            return Error.Failure("Database.Error", $"An error occurred while accessing the database: {ex.Message}");
        }
    }
}
