//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ErrorController.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Api.Controllers.Base;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controlador para manejar errores generales en la API.
/// </summary>
public class ErrorController : ControllerBase
{
    /// <summary>
    ///  Maneja los errores generales y genera una respuesta de problema estándar.
    /// </summary>
    /// <returns>Una respuesta de problema estándar.</returns>
    [Route("/Error")]
    public IActionResult Index()
    {
        return Problem();
    }
}