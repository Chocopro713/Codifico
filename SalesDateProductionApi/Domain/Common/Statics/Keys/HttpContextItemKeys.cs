//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="HttpContextItemKeys.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Domain.Common.Statics.Keys;

/// <summary>
/// Proporciona claves estáticas que se utilizan para almacenar y acceder a elementos en el <see cref="HttpContext"/>.
/// </summary>
public static class HttpContextItemKeys
{
    /// <summary>
    /// Clave utilizada para almacenar y acceder a errores en el <see cref="HttpContext"/>.
    /// </summary>
    public const string Errors = "errors";
}