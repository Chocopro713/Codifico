//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="IDirectSQLQueryExecutor.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

using Application.Interfaces;
using Contracts.Employees.Response;

namespace Application.Services.Employees;

public class EmployeeQueryService
{
    // Variable privada para almacenar la referencia al ejecutor de consultas SQL.
    private readonly IDirectSQLQueryExecutor _sqlExecutor;

    // Constructor que inyecta la dependencia del ejecutor de consultas SQL.
    public EmployeeQueryService(IDirectSQLQueryExecutor sqlExecutor)
    {
        _sqlExecutor = sqlExecutor; // Asigna el ejecutor inyectado a la variable local.
    }

    /// <summary>
    /// Recupera todos los empleados de la base de datos de forma asincrónica.
    /// </summary>
    /// <returns>Una lista de objetos EmployeeResponse que contienen la información de todos los empleados.</returns>
    public async Task<List<EmployeeResponse>> GetAllEmployeesAsync()
    {
        // Define la consulta SQL para obtener el ID y el nombre completo de los empleados.
        string sql = @"
                SELECT
                    EmpId,
                    FirstName + ' ' + LastName AS FullName
                FROM
                    StoreSample.HR.Employees";

        // Ejecuta la consulta SQL y mapea el resultado a una lista de objetos EmployeeResponse.
        // Utiliza un executor SQL para ejecutar la consulta de forma asincrónica.
        // El mapeo se realiza mediante una función lambda que crea nuevos objetos EmployeeResponse
        // a partir de los datos obtenidos en cada fila del resultado de la consulta.
        return await _sqlExecutor.ExecuteQueryAsync(sql, new Dictionary<string, object>(), reader => new EmployeeResponse
        (
            EmpId: reader.GetInt32(reader.GetOrdinal("EmpId")),
            FullName: reader.GetString(reader.GetOrdinal("FullName"))
        ));
    }
}
