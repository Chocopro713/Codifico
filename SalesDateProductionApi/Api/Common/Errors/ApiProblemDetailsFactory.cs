//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ApiProblemDetailsFactory.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Api.Common.Errors;

using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Domain.Common.Statics.Keys;

/// <summary>
/// Clase personalizada para generar detalles de problemas (ProblemDetails) en respuestas HTTP.
/// </summary>
public class ApiProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;
    
    /// <summary>
    /// Constructor de la clase <see cref="PeripherialProblemDetailsFactory"/>.
    /// </summary>
    /// <param name="options">Opciones de comportamiento de la API.</param>
    /// <exception cref="ArgumentNullException">Se lanza si <paramref name="options"/> es nulo.</exception>
    public  ApiProblemDetailsFactory(
        IOptions<ApiBehaviorOptions> options)
    {
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
    }
    
    /// <summary>
    /// Crea un objeto <see cref="ProblemDetails"/> con información sobre un problema específico.
    /// </summary>
    /// <param name="httpContext">El contexto HTTP actual.</param>
    /// <param name="statusCode">El código de estado HTTP asociado con el problema. Si es nulo, se establece en 500.</param>
    /// <param name="title">El título del problema.</param>
    /// <param name="type">Un URI identificando el tipo de problema.</param>
    /// <param name="detail">Detalles específicos sobre el problema.</param>
    /// <param name="instance">Un URI que identifica de forma única la instancia del problema.</param>
    /// <returns>Un objeto <see cref="ProblemDetails"/> que contiene la descripción del problema.</returns>
    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext, 
        int? statusCode = null,
        string? title = null,
        string? type = null, 
        string? detail = null, 
        string? instance = null)
    {
        // Si no se proporciona un código de estado, se establece en 500.
        statusCode ??= 500;

        // Crear un nuevo objeto ProblemDetails con los valores proporcionados.
        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance,
        };

        // Aplicar valores predeterminados al objeto ProblemDetails.
        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        // Devolver el objeto ProblemDetails configurado.
        return problemDetails;
    }
    
    /// <summary>
    /// Crea un objeto <see cref="ValidationProblemDetails"/> que describe errores de validación.
    /// </summary>
    /// <param name="httpContext">El contexto HTTP actual.</param>
    /// <param name="modelStateDictionary">El diccionario de estado del modelo que contiene errores de validación.</param>
    /// <param name="statusCode">El código de estado HTTP asociado con el problema. Si es nulo, se establece en 400.</param>
    /// <param name="title">El título del problema.</param>
    /// <param name="type">Un URI identificando el tipo de problema.</param>
    /// <param name="detail">Detalles específicos sobre el problema.</param>
    /// <param name="instance">Un URI que identifica de forma única la instancia del problema.</param>
    /// <returns>Un objeto <see cref="ValidationProblemDetails"/> que contiene la descripción del problema de validación.</returns>
    /// <exception cref="ArgumentNullException">Se lanza si <paramref name="modelStateDictionary"/> es nulo.</exception>
    public override ValidationProblemDetails CreateValidationProblemDetails(
        HttpContext httpContext,
        ModelStateDictionary modelStateDictionary, 
        int? statusCode = null, 
        string? title = null, 
        string? type = null,
        string? detail = null, 
        string? instance = null)
    {
        // Lanza una excepción si el diccionario de estado del modelo es nulo.
        ArgumentNullException.ThrowIfNull(modelStateDictionary);

        // Si no se proporciona un código de estado, se establece en 400.
        statusCode ??= 400;

        // Crear un nuevo objeto ValidationProblemDetails con el diccionario de estado del modelo.
        var problemDetails = new ValidationProblemDetails(modelStateDictionary)
        {
            Status = statusCode,
            Type = type,
            Detail = detail,
            Instance = instance,
        };

        // Si se proporciona un título, se establece en el objeto ValidationProblemDetails.
        if (title != null)
        {
            // Para problemas de validación, no sobrescribir el título predeterminado con null.
            problemDetails.Title = title;
        }

        // Aplicar valores predeterminados al objeto ValidationProblemDetails.
        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        // Devolver el objeto ValidationProblemDetails configurado.
        return problemDetails;
    }
    
    /// <summary>
    /// Aplica valores predeterminados a un objeto <see cref="ProblemDetails"/>.
    /// </summary>
    /// <param name="httpContext">El contexto HTTP actual.</param>
    /// <param name="problemDetails">El objeto <see cref="ProblemDetails"/> a modificar.</param>
    /// <param name="statusCode">El código de estado HTTP asociado con el problema.</param>
    private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        // Si el estado no está establecido, se establece en el código de estado proporcionado.
        problemDetails.Status ??= statusCode;

        // Si el código de estado tiene un mapeo de error del cliente, se establecen el título y el tipo.
        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        // Obtener el identificador de rastreo de la actividad actual o del contexto HTTP.
        var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
        if (traceId != null)
        {
            // Añadir el identificador de rastreo a las extensiones del objeto ProblemDetails.
            problemDetails.Extensions["traceId"] = traceId;
        }

        // Obtener la lista de errores del contexto HTTP.
        var errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;

        if (errors != null)
        {
            // Añadir la descripción de los errores a las extensiones del objeto ProblemDetails.
            problemDetails.Extensions.Add("errorDescription", errors.Select(s => s.Code));
        }
    }
}