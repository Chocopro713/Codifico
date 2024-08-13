//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ApiController.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Api.Controllers.Base;

using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Domain.Common.Statics.Keys;

/// <summary>
/// Controlador base para la API, proporciona métodos para manejar errores y generar respuestas adecuadas.
/// </summary>
[ApiController]
[Route("/")]
public class ApiController : ControllerBase
{
    /// <summary>
    /// Genera una respuesta de problema con detalles de validación específicos.
    /// </summary>
    /// <param name="errors">Lista de errores de validación.</param>
    /// <returns>Una respuesta de problema con detalles de validación.</returns>
    public IActionResult ValidationProblem(List<Error> errors)
    {
        // Crea un nuevo diccionario de estado del modelo.
        ModelStateDictionary modelStateDictionary = new();

        // Itera sobre cada error en la lista de errores.
        foreach (var error in errors)
        {
            // Agrega un error de modelo al diccionario.
            modelStateDictionary.AddModelError(
                error.Code, // Clave del error.
                error.Description); // Descripción del error.
        }

        // Devuelve una respuesta de problema con detalles de validación.
        return ValidationProblem(modelStateDictionary);
    }

    /// <summary>
    /// Genera una respuesta de problema basada en un único error.
    /// </summary>
    /// <param name="error">El error que se utilizará para generar la respuesta de problema.</param>
    /// <returns>Una respuesta de problema basada en el error proporcionado.</returns>
    public IActionResult Problem(Error error)
    {
        // Evalúa el tipo de error y asigna un código de estado HTTP correspondiente.
        int statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,  // Conflict (409).s
            ErrorType.Validation => StatusCodes.Status400BadRequest, // Bad Request (400).
            ErrorType.NotFound => StatusCodes.Status404NotFound, // Not Found (404).
            _ => StatusCodes.Status500InternalServerError // Internal Server Error (500) como valor predeterminado.
        };

        // Devuelve una respuesta de problema con el código de estado y la descripción del error.
        return Problem(statusCode: statusCode, title: error.Description);
    }

    /// <summary>
    /// Maneja la generación de respuestas HTTP basadas en una lista de errores proporcionada.
    /// </summary>
    /// <param name="errors">Lista de errores que se utilizarán para generar la respuesta.</param>
    /// <returns>Una respuesta HTTP adecuada basada en los errores proporcionados.</returns>
    protected IActionResult Problem(List<Error> errors) 
    {
        // Comprueba si la lista de errores está vacía.
        if (errors.Count is 0)
        {
            // Devuelve una respuesta de problema genérica.
            return Problem();
        }

        // Comprueba si todos los errores son de tipo validación.
        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            // Devuelve una respuesta de problema de validación.
            return ValidationProblem(errors);
        }
        
        // Almacena los errores en el contexto HTTP.
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        // Obtiene el primer error de la lista.
        Error firstError = errors[0];

        // Devuelve una respuesta de problema basada en el primer error.
        return Problem(firstError);
    }
    
    /// <summary>
    /// Un método de prueba simple que responde con un mensaje de estado OK.
    /// </summary>
    /// <returns>Una respuesta <see cref="IActionResult"/> con un mensaje de estado OK.</returns>
    [HttpGet]
    public IActionResult Hello() 
    { 
        return Ok(new { status = "ok", msg = "Esto corriendo" });
    }
}