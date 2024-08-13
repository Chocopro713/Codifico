//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="StoreProcedureResponse.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Contracts.Common.StoreProcedure.Response;

/// <summary>
/// Representa la respuesta de un procedimiento almacenado (SP).
/// </summary>
public class StoreProcedureResponse
{
    /// <summary>
    /// Mensaje de respuesta del SP
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Contenido del SP
    /// </summary>
    public string Content { get; set; }
}