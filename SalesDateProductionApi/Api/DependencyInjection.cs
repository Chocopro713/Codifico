//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="DependencyInjection.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Api;

/// <summary>
/// Proporciona métodos de extensión para configurar servicios de la Presentación.
/// </summary>
public static class  DependencyInjection
{
    /// <summary>
    /// Agrega servicios específicos de la aplicación a la <see cref="IServiceCollection"/> especificada.
    /// </summary>
    /// <param name="services">La colección de descriptores de servicio.</param>
    /// <returns>La <see cref="IServiceCollection"/> actualizada.</returns>
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        
        return services;
    }
}