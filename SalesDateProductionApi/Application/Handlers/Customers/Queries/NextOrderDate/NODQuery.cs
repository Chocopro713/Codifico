//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="NODCommand.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Handlers.Customers.Queries.NextOrderDate;

using ErrorOr;
using Contracts.Customers.Response;
using MediatR;

/// <summary>
/// Consulta para solicitar la fecha de la próxima orden de un cliente basado en su ID.
/// </summary>
/// <param name="custId">El ID del cliente para el cual se solicita la fecha de la próxima orden.</param>
/// <returns>Una respuesta que contiene un objeto <see cref="NextOrderDateResponse"/> o un error en caso de fallo.</returns>
public record NODQuery() : IRequest<ErrorOr<List<NextOrderDateResponse>>>;