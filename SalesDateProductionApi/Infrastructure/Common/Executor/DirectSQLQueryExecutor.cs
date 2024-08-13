//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="DirectSQLQueryExecutor.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------


namespace Infrastructure.Common.Executor;

using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Application.Interfaces;

/// <summary>
/// Clase que ejecuta cadenas de consulta en una base de datos SQL Server.
/// Implementa la interfaz <see cref="IDirectSQLQueryExecutor"/> para proporcionar funcionalidad de ejecución de procedimientos almacenados.
/// </summary>
public class DirectSQLQueryExecutor : IDirectSQLQueryExecutor
{
    private readonly string _connectionString;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="DirectSQLQueryExecutor"/> con la cadena de conexión proporcionada.
    /// </summary>
    /// <param name="connectionString">La cadena de conexión a la base de datos SQL Server.</param>
    public DirectSQLQueryExecutor(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Ejecuta una consulta SQL que devuelve un único valor de tipo T de forma asincrónica.
    /// </summary>
    /// <typeparam name="T">El tipo del valor que la consulta espera retornar.</typeparam>
    /// <param name="sql">La consulta SQL a ejecutar.</param>
    /// <param name="parameters">Diccionario de parámetros utilizados en la consulta SQL.</param>
    /// <param name="cancellationToken">Token opcional para cancelar la operación.</param>
    /// <returns>Un valor de tipo T obtenido de la ejecución de la consulta.</returns>
    public async Task<T> ExecuteScalarAsync<T>(string sql, Dictionary<string, object> parameters, CancellationToken cancellationToken = default)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync(cancellationToken);
            using (var command = new SqlCommand(sql, connection))
            {
                AddParameters(command, parameters);
                return (T)await command.ExecuteScalarAsync(cancellationToken);
            }
        }
    }

    /// <summary>
    /// Ejecuta una instrucción SQL que afecta a una o varias filas de forma asincrónica.
    /// </summary>
    /// <param name="sql">La instrucción SQL a ejecutar.</param>
    /// <param name="parameters">Diccionario de parámetros utilizados en la instrucción SQL.</param>
    /// <param name="cancellationToken">Token opcional para cancelar la operación.</param>
    /// <returns>El número de filas afectadas por la ejecución de la instrucción.</returns>
    public async Task<int> ExecuteNonQueryAsync(string sql, Dictionary<string, object> parameters, CancellationToken cancellationToken = default)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync(cancellationToken);
            using (var command = new SqlCommand(sql, connection))
            {
                AddParameters(command, parameters);
                return await command.ExecuteNonQueryAsync(cancellationToken);
            }
        }
    }

    /// <summary>
    /// Ejecuta una consulta SQL que devuelve una lista de objetos de tipo T de forma asincrónica.
    /// </summary>
    /// <typeparam name="T">El tipo de objetos que la consulta espera retornar.</typeparam>
    /// <param name="sql">La consulta SQL a ejecutar.</param>
    /// <param name="parameters">Diccionario de parámetros utilizados en la consulta SQL.</param>
    /// <param name="map">Función que mapea cada fila del SqlDataReader a un objeto de tipo T.</param>
    /// <param name="cancellationToken">Token opcional para cancelar la operación.</param>
    /// <returns>Una lista de objetos de tipo T obtenidos de la ejecución de la consulta.</returns>
    public async Task<List<T>> ExecuteQueryAsync<T>(string sql, Dictionary<string, object> parameters, Func<SqlDataReader, T> map, CancellationToken cancellationToken = default)
    {
        var results = new List<T>();
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync(cancellationToken);
            using (var command = new SqlCommand(sql, connection))
            {
                AddParameters(command, parameters);
                using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    while (await reader.ReadAsync(cancellationToken))
                    {
                        results.Add(map(reader));
                    }
                }
            }
        }
        return results;
    }

    /// <summary>
    /// Añade parámetros al comando SQL para evitar la inyección de SQL y mejorar la seguridad de la consulta.
    /// </summary>
    /// <param name="command">El comando SQL al cual se añadirán los parámetros.</param>
    /// <param name="parameters">Diccionario que contiene los nombres y valores de los parámetros.</param>
    private void AddParameters(SqlCommand command, Dictionary<string, object> parameters)
    {
        foreach (var param in parameters)
        {
            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
        }
    }
}
