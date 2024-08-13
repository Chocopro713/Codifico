//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="HttpContextItemKeys.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application;

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using Common.Behavior;
using Application.Interfaces;
using Application.Services.Customers;
using Application.Services.Orders;
using Application.Services.Employees;
using Application.Services.Shippers;
using Application.Services.Products;

/// <summary>
/// Proporciona métodos de extensión para configurar servicios de la aplicación.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Agrega servicios específicos de la aplicación a la <see cref="IServiceCollection"/> especificada.
    /// </summary>
    /// <param name="services">La colección de descriptores de servicio.</param>
    /// <returns>La <see cref="IServiceCollection"/> actualizada.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Agrega MediatR a la colección de servicios, escaneando los manejadores de solicitudes en el ensamblado actual.
        services.AddMediatR(cfg => 
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });
        // Agrega el comportamiento de validación a la cadena de manejadores de MediatR.
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); 

        // Agregamos el servicio de consulta de clientes a la colección de servicios.
        services.AddScoped<CustomerQueryService>();

        // Agregamos el servicio de consulta de ordenes a la colección de servicios.
        services.AddScoped<OrderQueryService>();

        // Agregamos el servicio de consulta de empleados a la colección de servicios.
        services.AddScoped<EmployeeQueryService>();

        // Agregamos el servicio de consulta de transportistas a la colección de servicios.
        services.AddScoped<ShipperQueryService>();

        // Agregamos el servicio de consulta de productos a la colección de servicios.
        services.AddScoped<ProductQueryService>();


        // Agrega todos los validadores de FluentValidation definidos en el ensamblado actual a la colección de servicios.
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }
}