//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="IStoreProcedureExecutor.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Interfaces;

using Microsoft.Data.SqlClient;

/// <summary>
/// Define una interfaz para la ejecución de procedimientos almacenados en una base de datos SQL Server.
/// </summary>
public interface IStoreProcedureExecutor
{
    /// <summary>
    /// Ejecuta de manera asincrónica un procedimiento almacenado en la base de datos.
    /// </summary>
    /// <param name="storedProcedureName">El nombre del procedimiento almacenado que se va a ejecutar.</param>
    /// <param name="configureParameters">Una acción que configura los parámetros del comando SQL.</param>
    /// <returns>Una tarea asincrónica que devuelve el resultado como una cadena.</returns>
    Task<string> ExecuteStoredProcedureAsync(string storedProcedureName, Action<SqlCommand> configureParameters);
}