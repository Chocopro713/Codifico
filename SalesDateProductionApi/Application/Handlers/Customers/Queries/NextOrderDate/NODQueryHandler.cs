//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="NODQueryHandler.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Handlers.Customers.Queries.NextOrderDate;

using Application.Services.Customers;
using Contracts.Customers.Response;
using ErrorOr;
using MediatR;

/// <summary>
/// Manejador de consultas para obtener la fecha de la próxima orden de un cliente.
/// Implementa la interfaz <see cref="IRequestHandler{TRequest,TResponse}"/> para manejar la consulta <see cref="NODQuery"/>.
/// </summary>
public class NODQueryHandler : IRequestHandler<NODQuery,ErrorOr<List<NextOrderDateResponse>>>
{
    /// <summary>
    /// Declara una variable para almacenar la referencia al servicio que se utilizará para obtener datos.
    /// </summary>
    private readonly CustomerQueryService _customerQueryService;

    /// <summary>
    /// Constructor que inyecta el CustomerQueryService para ser utilizado en la clase.
    /// </summary>
    /// <param name="customerQueryService"></param>
    public NODQueryHandler(CustomerQueryService customerQueryService)
    {
        _customerQueryService = customerQueryService;
    }

    /// <summary>
    /// Maneja la ejecución de la consulta NODQuery para obtener las próximas fechas de pedido de los clientes.
    /// </summary>
    /// <param name="query">Consulta que contiene los parámetros necesarios para la operación.</param>
    /// <param name="cancellationToken">Token de cancelación que se puede usar para propagar notificaciones de que las operaciones deberían cancelarse.</param>
    /// <returns>
    /// Una tarea que representa la operación asincrónica. 
    /// El resultado encapsula un ErrorOr que contiene una lista de NextOrderDateResponse o un error, dependiendo del resultado de la operación.
    /// </returns>
    public async Task<ErrorOr<List<NextOrderDateResponse>>> Handle(NODQuery query, CancellationToken cancellationToken)
    {
        try
        {
            // Realiza una llamada asincrónica al servicio de consulta de clientes para obtener todas las próximas fechas de pedidos.
            List<NextOrderDateResponse> results = await _customerQueryService.GetAllNextOrderDatesAsync();

            // Verifica si la lista de resultados está vacía.
            if (results.Count == 0)
                // Si no hay resultados, devuelve un objeto ErrorOr que representa un error de 'Cliente no encontrado'.
                return Error.NotFound("Customer.NotFound", "Customer not found.");

            // Si se encontraron resultados, los devuelve exitosamente.
            return results;
        }
        catch (Exception ex)
        {
            // Devuelve un error general indicando un problema de acceso a la base de datos.
            return Error.Failure("Database.Error", $"An error occurred while accessing the database: {ex.Message}");
        }
    }
}