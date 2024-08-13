//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="DependencyInjection.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using Infrastructure.Common.Executor;

/// <summary>
/// Clase estática que proporciona métodos de extensión para la configuración 
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Configura los servicios de infraestructura en el contenedor de inyección de dependencias.
    /// </summary>
    /// <param name="services">La colección de servicios a la que se añadirán las configuraciones.</param>
    /// <param name="configuration">La instancia de <see cref="ConfigurationManager"/> que contiene la configuración.</param>
    /// <returns>La colección de servicios con la configuración añadida.</returns>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        // Agregar la configuración de la conexión a SQL Server
        services.AddSQLServerConnection(configuration);

        // Registrar el QueryExecutor en el contenedor de servicios
        // services.AddScoped<IStoreProcedureExecutor, StoredProcedureExecutor>();

        // Retorna los servicios de manera actualizada.
        return services;
    }
    
    /// <summary>
    /// Configura la conexión a SQL Server en el contenedor de servicios.
    /// </summary>
    /// <param name="services">La colección de servicios a la que se añadirá la configuración.</param>
    /// <param name="configuration">La configuración que contiene la cadena de conexión.</param>
    /// <returns>La colección de servicios con la configuración añadida.</returns>
    public static IServiceCollection AddSQLServerConnection(this IServiceCollection services, IConfiguration configuration)
    {
        // Obtener la cadena de conexión desde la configuración
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Registrar el contexto de base de datos con la cadena de conexión
        services.AddDbContext<SQLServerContext>(options =>
            options.UseSqlServer(connectionString));

        // Registrar el QueryExecutor en el contenedor de servicios
        services.AddScoped<IDirectSQLQueryExecutor>(provider => new DirectSQLQueryExecutor(connectionString));
        services.AddScoped<IStoreProcedureExecutor>(provider => new StoredProcedureExecutor(connectionString));

        // Retorna los servicios de manera actualizada.
        return services;
    }
}