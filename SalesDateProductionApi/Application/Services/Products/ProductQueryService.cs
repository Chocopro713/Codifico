//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ProductQueryService.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Services.Products;

// Importa las interfaces necesarias y las respuestas de contratos para productos.
using Application.Interfaces;
using Contracts.Products.Response;

/// <summary>
/// Servicio que proporciona operaciones relacionadas con la consulta de productos en la base de datos.
/// </summary>
public class ProductQueryService
{
    // Dependencia hacia el ejecutor de consultas SQL directas.
    private readonly IDirectSQLQueryExecutor _sqlExecutor;

    /// <summary>
    /// Inicializa una nueva instancia de la clase ProductQueryService con un ejecutor de SQL.
    /// </summary>
    /// <param name="sqlExecutor">El ejecutor de consultas SQL que se utilizará para obtener datos de la base de datos.</param>
    public ProductQueryService(IDirectSQLQueryExecutor sqlExecutor)
    {
        _sqlExecutor = sqlExecutor;
    }

    /// <summary>
    /// Recupera todos los productos de la base de datos de forma asincrónica.
    /// </summary>
    /// <returns>Una lista de objetos ProductResponse que contienen información de todos los productos disponibles.</returns>
    public async Task<List<ProductResponse>> GetAllProductsAsync()
    {
        // Define la consulta SQL para obtener el ID y el nombre de todos los productos.
        var sql = @"
                SELECT
                    ProductId,
                    ProductName
                FROM
                    StoreSample.Production.Products";

        // Ejecuta la consulta SQL y mapea el resultado a una lista de objetos ProductResponse.
        // Utiliza el executor SQL para realizar la consulta de manera asincrónica.
        // El mapeo se realiza mediante una función lambda que crea nuevos objetos ProductResponse
        // a partir de los datos obtenidos en cada fila del resultado de la consulta.
        return await _sqlExecutor.ExecuteQueryAsync(sql, new Dictionary<string, object>(), reader => new ProductResponse
        (
            ProductId: reader.GetInt32(reader.GetOrdinal("ProductId")),
            ProductName: reader.GetString(reader.GetOrdinal("ProductName"))
        ));
    }
}
