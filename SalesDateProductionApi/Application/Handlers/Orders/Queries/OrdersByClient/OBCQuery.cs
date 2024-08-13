//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="OBCQuery.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Handlers.Orders.Queries.OrdersByClient;

// Importa las clases necesarias para la gestión de errores, MediatR y las respuestas de las consultas.
using ErrorOr;
using MediatR;
using Contracts.Orders.Response;

/// <summary>
/// Representa una consulta para obtener todas las órdenes asociadas a un cliente específico.
/// </summary>
/// Este record se utiliza en el contexto de CQRS dentro de la arquitectura de MediatR para separar las
/// responsabilidades de lectura de las de escritura. La inmutabilidad del record asegura que los datos
/// de la consulta no pueden ser modificados una vez instanciados, proporcionando un manejo de estado seguro.
/// <param name="custId"></param>
public record OBCQuery(int custId) : IRequest<ErrorOr<List<OrderByClientResponse>>>;
