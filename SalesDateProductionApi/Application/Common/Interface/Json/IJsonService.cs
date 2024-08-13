//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="IJsonService.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Common.Interface.Json;

/// <summary>
/// Interfaz que define los métodos para la serialización y deserialización de objetos JSON.
/// </summary>
public interface IJsonService
{
    /// <summary>
    /// Deserializa un string JSON en un objeto del tipo especificado.
    /// </summary>
    /// <typeparam name="T">El tipo del objeto en el que se deserializa el JSON.</typeparam>
    /// <param name="json">El string JSON que se deserializa.</param>
    /// <returns>El objeto deserializado del tipo especificado.</returns>

    T DeserializeObject<T>(string json);

    /// <summary>
    /// Serializa un objeto en un string JSON.
    /// </summary>
    /// <typeparam name="T">El tipo del objeto que se serializa.</typeparam>
    /// <param name="objeto">El objeto que se serializa a JSON.</param>
    /// <returns>El string JSON que representa el objeto.</returns>
    string SerializeObject<T>(T objeto);
}