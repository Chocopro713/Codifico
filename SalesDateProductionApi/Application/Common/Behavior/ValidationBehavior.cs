//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ValidationBehavior.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Common.Behavior;

using ErrorOr;
using MediatR;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// Comportamiento de validación para las solicitudes de MediatR.
/// </summary>
/// <typeparam name="TRequest">El tipo de la solicitud.</typeparam>
/// <typeparam name="TResponse">El tipo de la respuesta.</typeparam>
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    /// <summary>
    /// Campo que contiene el validador para el tipo de solicitud TRequest, si se proporciona uno.
    /// </summary>
    private readonly IValidator<TRequest>? _validator;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ValidationBehavior{TRequest, TResponse}"/>.
    /// </summary>
    /// <param name="validator">El validador para la solicitud, si existe.</param>
    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    /// <summary>
    /// Maneja la solicitud, validándola antes de pasarla al siguiente manejador en la cadena.
    /// </summary>
    /// <param name="request">La solicitud a validar y manejar.</param>
    /// <param name="next">El siguiente manejador en la cadena.</param>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>Una tarea que representa la respuesta de la solicitud.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Si no hay un validador proporcionado, pasa la solicitud al siguiente manejador.
        if (_validator is null)
        {
            return await next();
        }

        // Realiza la validación de la solicitud utilizando el validador proporcionado.
        ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        // Convierte los errores de validación en una lista de errores personalizados.
        List<Error> errors = validationResult.Errors
            .ConvertAll(ValidationFailure => Error.Validation(
                ValidationFailure.PropertyName,
                ValidationFailure.ErrorMessage));

        // Devuelve la lista de errores como respuesta de la solicitud.
        return (dynamic)errors;
    }
}