//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="StoredProcedureExecutor.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Infrastructure.Common.Executor;

using System.Data;
using Microsoft.Data.SqlClient;
using Contracts.Common.StoreProcedure.Response;
using Application.Interfaces;

/// <summary>
/// Clase que ejecuta procedimientos almacenados en una base de datos SQL Server.
/// Implementa la interfaz <see cref="IStoreProcedureExecutor"/> para proporcionar funcionalidad de ejecución de procedimientos almacenados.
/// </summary>
public class StoredProcedureExecutor : IStoreProcedureExecutor
{
    private readonly string _connectionString;
    
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="StoredProcedureExecutor"/> con la cadena de conexión proporcionada.
    /// </summary>
    /// <param name="connectionString">La cadena de conexión a la base de datos SQL Server.</param>
    public StoredProcedureExecutor(
        string connectionString)
    {
        _connectionString = connectionString;
    }
    
    /// <summary>
    /// Ejecuta un procedimiento almacenado de manera asincrónica en la base de datos.
    /// </summary>
    /// <param name="storedProcedureName">El nombre del procedimiento almacenado a ejecutar.</param>
    /// <param name="configureParameters">Una acción que configura los parámetros del comando <see cref="SqlCommand"/>.</param>
    /// <returns>Una tarea que representa la operación asincrónica. El resultado es un string vacío en este caso.</returns>
    public async Task<string> ExecuteStoredProcedureAsync(string storedProcedureName, Action<SqlCommand> configureParameters)
    {
        try
        {
            // Crea una nueva instancia de SPResponse que contendrá la respuesta del procedimiento almacenado.
            StoreProcedureResponse spResponse = new();

            // Crear la conexión a SQL Server
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Crear el comando asociado a la conexión
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    // Abrir la conexión si no está ya abierta
                    if (connection.State != ConnectionState.Open)
                    {
                        await connection.OpenAsync();
                    }

                    // Establecer el nombre del procedimiento almacenado
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Configurar los parámetros utilizando la acción proporcionada
                    configureParameters(cmd);

                    // Ejecutar el comando de manera asincrónica
                    await cmd.ExecuteNonQueryAsync();

                    // Aquí puedes obtener parámetros de salida si los tienes
                    // Por ejemplo, si tu procedimiento almacenado tiene parámetros de salida:
                    if (cmd.Parameters.Contains("@p_msg"))
                    {
                        spResponse.Message = cmd.Parameters["@p_msg"].Value.ToString();
                    }

                    if (cmd.Parameters.Contains("@p_response"))
                    {
                        spResponse.Content = cmd.Parameters["@p_response"].Value.ToString();
                    }

                    // Cerrar la conexión
                    await connection.CloseAsync();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return "";
    }
}