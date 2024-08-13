//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="OrderQueryService.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------


namespace Application.Services.Orders;

using Application.Interfaces;
using Contracts.Orders.Response;

public class OrderQueryService
{
    // Variable privada para almacenar la referencia al ejecutor de consultas SQL.
    private readonly IDirectSQLQueryExecutor _sqlExecutor;

    // Constructor que inyecta la dependencia del ejecutor de consultas SQL.
    public OrderQueryService(IDirectSQLQueryExecutor sqlExecutor)
    {
        _sqlExecutor = sqlExecutor; // Asigna el ejecutor inyectado a la variable local.
    }

    /// <summary>
    /// Recupera todas las órdenes asociadas a un cliente específico de la base de datos de forma asincrónica.
    /// </summary>
    /// <param name="custId">El identificador del cliente para el cual se recuperarán las órdenes.</param>
    /// <returns>Una lista de objetos OrderByClientResponse que contienen información detallada sobre cada orden.</returns>
    public async Task<List<OrderByClientResponse>> GetOrdersByClient(int custId)
    {
        // Define la consulta SQL para obtener detalles de las órdenes asociadas al ID del cliente.
        string sql = @"
            SELECT
                OrderId,
                RequiredDate,
                ShippedDate,
                ShipName,
                ShipAddress,
                ShipCity
            FROM
                StoreSample.Sales.Orders
            WHERE
                custid = @CustomerId";

        // Crea un diccionario para almacenar los parámetros de la consulta SQL.
        // En este caso, solo se utiliza el identificador del cliente.
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@CustomerId", custId }
        };

        // Ejecuta la consulta SQL y mapea el resultado a una lista de objetos OrderByClientResponse.
        // Utiliza un executor SQL para ejecutar la consulta de forma asincrónica.
        // El mapeo se realiza mediante una función lambda que crea nuevos objetos OrderByClientResponse
        // a partir de los datos obtenidos en cada fila del resultado de la consulta.
        return await _sqlExecutor.ExecuteQueryAsync(sql, parameters, reader => new OrderByClientResponse
        (
            OrderId: reader.GetInt32(reader.GetOrdinal("OrderId")),
            RequiredDate: reader.GetDateTime(reader.GetOrdinal("RequiredDate")),
            ShippedDate: reader.IsDBNull(reader.GetOrdinal("ShippedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ShippedDate")),
            ShipName: reader.GetString(reader.GetOrdinal("ShipName")),
            ShipAddress: reader.GetString(reader.GetOrdinal("ShipAddress")),
            ShipCity: reader.GetString(reader.GetOrdinal("ShipCity"))
        ));
    }
}
