//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="EmployeesQueryHandler.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Handlers.Employees.Queries.Employees;

// Importaciones necesarias para el manejo de respuestas, servicios, y MediatR.
using Application.Services.Employees;
using Contracts.Employees.Response;
using ErrorOr;
using MediatR;

// La clase EmployeesQueryHandler implementa la interfaz IRequestHandler de MediatR,
// especificando que maneja consultas de tipo EmployeesQuery y devuelve un ErrorOr que puede contener una lista de EmployeeResponse.
public class EmployeesQueryHandler : IRequestHandler<EmployeesQuery, ErrorOr<List<EmployeeResponse>>>
{
    // Campo privado para almacenar la referencia al servicio que se utiliza para consultar datos de empleados.
    private readonly EmployeeQueryService _employeeQueryService;

    // Constructor que inyecta el EmployeeQueryService para ser utilizado en el manejo de la consulta.
    // Este servicio es responsable de obtener datos de empleados desde la base de datos o cualquier otra fuente de datos configurada.
    public EmployeesQueryHandler(EmployeeQueryService employeeQueryService)
    {
        _employeeQueryService = employeeQueryService;
    }

    /// <summary>
    /// Procesa la consulta EmployeesQuery de forma asincrónica, utilizando el servicio inyectado para obtener todos los empleados.
    /// </summary>
    /// <param name="query">La consulta de tipo EmployeesQuery que no lleva parámetros adicionales.</param>
    /// <param name="cancellationToken">Token de cancelación que permite interrumpir la operación en ejecución.</param>
    /// <returns>Una tarea que, al completarse, devuelve un ErrorOr que contiene una lista de EmployeeResponse o un error.</returns>
    public async Task<ErrorOr<List<EmployeeResponse>>> Handle(EmployeesQuery query, CancellationToken cancellationToken)
    {
        try
        {
            // Llama al método GetAllEmployeesAsync del servicio para obtener una lista de respuestas de empleados.
            List<EmployeeResponse> results = await _employeeQueryService.GetAllEmployeesAsync();

            // Comprueba si la lista obtenida está vacía y, en ese caso, devuelve un error indicando que no se encontraron empleados.
            if (results.Count == 0)
                return Error.NotFound("Employees.NotFound", "Employees not found."); 

            // Si se encontraron empleados, devuelve la lista como parte de un objeto ErrorOr exitoso.
            return results;
        }
        catch (Exception ex) // Captura cualquier excepción que ocurra durante la recuperación de los datos.
        {
            // Devuelve un error indicando que hubo un problema al acceder a la base de datos, incluyendo el mensaje de la excepción.
            return Error.Failure("Database.Error", $"An error occurred while accessing the database: {ex.Message}");
        }
    }
}
