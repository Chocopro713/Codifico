//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ProductQueryHandler.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Handlers.Products.Queries.Products;

// Importa las clases necesarias para trabajar con los servicios de productos, respuestas de productos, manejo de errores y MediatR.
using Application.Services.Products;
using Contracts.Products.Response;
using ErrorOr;
using MediatR;

/// <summary>
/// Maneja las consultas para obtener todos los productos disponibles.
/// </summary>
public class ProductQueryHandler : IRequestHandler<ProductQuery, ErrorOr<List<ProductResponse>>>
{
    // Servicio que provee la lógica para acceder a los productos en la base de datos.
    private readonly ProductQueryService _productQueryService;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="ProductQueryHandler"/> con un servicio para consultar productos.
    /// </summary>
    /// <param name="productQueryService">El servicio que proporciona acceso a los productos en la base de datos.</param>
    public ProductQueryHandler(ProductQueryService productQueryService)
    {
        _productQueryService = productQueryService;
    }

    /// <summary>
    /// Asíncronamente maneja la consulta de productos, utilizando el servicio inyectado para obtener todos los productos.
    /// </summary>
    /// <param name="query">La consulta de tipo ProductQuery que no lleva parámetros adicionales.</param>
    /// <param name="cancellationToken">Token de cancelación que permite interrumpir la operación.</param>
    /// <returns>Una lista de respuestas de productos o un error si no se encuentran productos o hay un problema en la base de datos.</returns>
    public async Task<ErrorOr<List<ProductResponse>>> Handle(ProductQuery query, CancellationToken cancellationToken)
    {
        try
        {
            // Solicita al servicio de consulta de productos que recupere todos los productos disponibles.
            List<ProductResponse> results = await _productQueryService.GetAllProductsAsync();

            // Verifica si la consulta devolvió algún resultado.
            if (results.Count == 0)
                // Devuelve un error indicando que no se encontraron productos.
                return Error.NotFound("Products.NotFound", "Products not found.");

            // Si se encontraron resultados, devuelve la lista de respuestas de productos.
            return results;
        }
        catch (Exception ex) // Captura cualquier excepción que ocurra durante la ejecución de la consulta.
        {
            // Devuelve un error general indicando un problema con la base de datos.
            return Error.Failure("Database.Error", $"An error occurred while accessing the database: {ex.Message}");
        }
    }
}
