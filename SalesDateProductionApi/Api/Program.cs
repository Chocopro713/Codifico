//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="Program.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

using Api;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics;

// Configura los servicios y la infraestructura de la aplicación API.
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        // Agregar la configuración de presentación o API.
        .AddPresentation()
        // Agregar la configuración de aplicación.
        .AddApplication()
        // Agregar la configuración de infraestructura.
        .AddInfrastructure(builder.Configuration);

    // Habilitar CORS para permitir solicitudes desde cualquier origen
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins",
            builder => builder
                .AllowAnyOrigin() // Permitir cualquier origen
                .AllowAnyMethod() // Permitir cualquier método (GET, POST, etc.)
                .AllowAnyHeader()); // Permitir cualquier encabezado
    });
}

// Configura el pipeline de la aplicación.
var app = builder.Build();
{
    // Configurar el manejo de excepciones
    app.UseExceptionHandler("/error");
    // Definir un endpoint para manejar los errores globalmente
    app.Map("/error", (HttpContext httpContext) =>
    {
        // Obtener la excepción ocurrida si existe
        Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Results.Problem();
    });

    // Habilitar CORS para permitir solicitudes desde cualquier origen
    app.UseCors("AllowAllOrigins");

    // Mapea los controladores definidos.
    app.MapControllers();
    // Redireccionar las solicitudes HTTP a HTTPS.
    app.UseHttpsRedirection();
    // Inicia la aplicación y comienza a escuchar las solicitudes entrantes.
    app.Run();
}

