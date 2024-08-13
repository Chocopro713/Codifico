//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="IDirectSQLQueryExecutor.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Interfaces;

using Microsoft.Data.SqlClient;

/// <summary>
/// Define una interfaz para la ejecución de cadenas de consulta en una base de datos SQL Server.
/// </summary>
public interface IDirectSQLQueryExecutor
{
    /// <summary>
    /// Ejecuta una consulta SQL que devuelve un único valor de tipo T de forma asincrónica.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<T> ExecuteScalarAsync<T>(string sql, Dictionary<string, object> parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Ejecuta una instrucción SQL que afecta a una o varias filas de forma asincrónica.
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> ExecuteNonQueryAsync(string sql, Dictionary<string, object> parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Ejecuta una consulta SQL que devuelve una lista de objetos de tipo T de forma asincrónica.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <param name="map"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<T>> ExecuteQueryAsync<T>(string sql, Dictionary<string, object> parameters, Func<SqlDataReader, T> map, CancellationToken cancellationToken = default);
}
