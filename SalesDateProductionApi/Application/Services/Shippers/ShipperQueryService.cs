//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ShipperQueryService.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

// Define el espacio de nombres para organizar las funcionalidades relacionadas con los servicios de transportistas.
namespace Application.Services.Shippers;

// Importa las interfaces necesarias y las respuestas de contratos para transportistas.
using Application.Interfaces;
using Contracts.Shippers.Response;

/// <summary>
/// Servicio que proporciona operaciones relacionadas con la consulta de transportistas en la base de datos.
/// </summary>
public class ShipperQueryService
{
    // Variable privada para almacenar la referencia al ejecutor de consultas SQL.
    private readonly IDirectSQLQueryExecutor _sqlExecutor;

    /// <summary>
    /// Inicializa una nueva instancia de la clase ShipperQueryService con un ejecutor de SQL.
    /// </summary>
    /// <param name="sqlExecutor">El ejecutor de consultas SQL que se utilizará para obtener datos de la base de datos.</param>
    public ShipperQueryService(IDirectSQLQueryExecutor sqlExecutor)
    {
        _sqlExecutor = sqlExecutor; // Asigna el ejecutor inyectado a la variable local.
    }

    /// <summary>
    /// Recupera todos los transportistas de la base de datos de forma asincrónica.
    /// </summary>
    /// <returns>Una lista de objetos ShipperResponse que contienen información de todos los transportistas disponibles.</returns>
    public async Task<List<ShipperResponse>> GetAllShippersAsync()
    {
        // Define la consulta SQL para obtener el ID y el nombre de la compañía de todos los transportistas.
        string sql = @"
            SELECT
                ShipperId,
                CompanyName
            FROM
                StoreSample.Sales.Shippers";

        // Ejecuta la consulta SQL y mapea el resultado a una lista de objetos ShipperResponse.
        // Utiliza el executor SQL para realizar la consulta de manera asincrónica.
        // El mapeo se realiza mediante una función lambda que crea nuevos objetos ShipperResponse
        // a partir de los datos obtenidos en cada fila del resultado de la consulta.
        return await _sqlExecutor.ExecuteQueryAsync(sql, new Dictionary<string, object>(), reader => new ShipperResponse
        (
            ShipperId: reader.GetInt32(reader.GetOrdinal("ShipperId")), // Obtiene el ID del transportista de la fila actual del lector SQL.
            CompanyName: reader.GetString(reader.GetOrdinal("CompanyName")) // Obtiene el nombre de la compañía.
        ));
    }
}
