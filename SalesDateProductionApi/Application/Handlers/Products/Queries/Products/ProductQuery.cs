//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ProductQuery.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Handlers.Products.Queries.Products;

using Contracts.Products.Response;
using ErrorOr;
using MediatR;

/// <summary>
/// Representa una consulta que no necesita parámetros adicionales y se utiliza para solicitar una lista de todos los productos disponibles.
/// </summary>
/// <remarks>
/// Este record se utiliza en el contexto de CQRS dentro de la arquitectura de MediatR para manejar la separación de responsabilidades
/// en operaciones de lectura y escritura. La inmutabilidad del record asegura que los datos de la consulta no pueden ser modificados
/// una vez instanciados, promoviendo un manejo de estado seguro y consistente a lo largo de su uso en la aplicación.
/// </remarks>
public record ProductQuery() : IRequest<ErrorOr<List<ProductResponse>>>;