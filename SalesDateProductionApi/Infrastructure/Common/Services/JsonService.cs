//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="DependencyInjection.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Infrastructure.Common.Services;

using Newtonsoft.Json;

/// <summary>
/// Servicios para la serialización y deserialización de objetos JSON.
/// </summary>
public class JsonService
{
    /// <summary>
    /// Deserializa una cadena JSON a un objeto del tipo especificado.
    /// </summary>
    /// <typeparam name="T">El tipo del objeto a deserializar.</typeparam>
    /// <param name="json">La cadena JSON a deserializar.</param>
    /// <returns>El objeto deserializado del tipo especificado.</returns>
    public T DeserializeObject<T>(string json)
    {
        // Deserializar la cadena JSON al tipo especificado.
        return JsonConvert.DeserializeObject<T>(json);
    }

    /// <summary>
    /// Serializa un objeto a una cadena JSON.
    /// </summary>
    /// <typeparam name="T">El tipo del objeto a serializar.</typeparam>
    /// <param name="objeto">El objeto a serializar.</param>
    /// <returns>Una cadena que representa el objeto serializado en formato JSON.</returns>
    public string SerializeObject<T>(T objeto)
    {
        // serializar el objeto a formato JSON.
        return JsonConvert.SerializeObject(objeto);
    }
}