//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ShippersQueryHandler.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Handlers.Shippers.Queries.Shippers;

// Importa los servicios necesarios, contratos y utilidades para el manejo de errores.
using Application.Services.Shippers;
using Contracts.Shippers.Response;
using ErrorOr;

/// <summary>
/// Manejador responsable de ejecutar consultas para obtener todos los transportistas.
/// </summary>
public class ShippersQueryHandler
{
    // Servicio responsable de realizar las consultas de datos de transportistas.
    private readonly ShipperQueryService _shipperQueryService;

    /// <summary>
    /// Inicializa una nueva instancia del ShippersQueryHandler con un servicio de consulta de transportistas.
    /// </summary>
    /// <param name="shipperQueryService">Servicio utilizado para acceder a los datos de los transportistas.</param>
    public ShippersQueryHandler(ShipperQueryService shipperQueryService)
    {
        _shipperQueryService = shipperQueryService;
    }

    /// <summary>
    /// Maneja la solicitud para obtener todos los transportistas.
    /// </summary>
    /// <param name="query">El objeto de consulta, que en este caso no lleva parámetros adicionales ya que recupera todos los transportistas.</param>
    /// <param name="cancellationToken">Token de cancelación para cancelar la operación si es necesario.</param>
    /// <returns>Una tarea asíncrona que, al completarse, devuelve una lista de respuestas de transportistas o un error.</returns>
    public async Task<ErrorOr<List<ShipperResponse>>> Handle(ShippersQuery query, CancellationToken cancellationToken)
    {
        try
        {
            // Ejecuta la consulta para recuperar todos los transportistas usando el servicio inyectado.
            List<ShipperResponse> results = await _shipperQueryService.GetAllShippersAsync();

            // Verifica si se encontraron transportistas. Si no hay ninguno, devuelve un error de no encontrado.
            if (results.Count == 0)
                return Error.NotFound("Shippers.NotFound", "Shippers not found.");

            // Si se encontraron transportistas, devuelve la lista de estos.
            return results;
        }
        catch (Exception ex)
        {
            // Devuelve un error genérico de base de datos con detalles de la excepción.
            return Error.Failure("Database.Error", $"An error occurred while accessing the database: {ex.Message}");
        }
    }
}
