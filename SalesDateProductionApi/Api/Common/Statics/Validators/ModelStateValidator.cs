//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="ModelStateValidator.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Api.Common.Statics.Validators;

using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

/// <summary>
/// Clase que contiene métods para validar y manejar modelos de estado de validación.
/// </summary>
public static class ModelStateValidator
{
    /// <summary>
    /// Valida una solicitud y maneja los errores de validación.
    /// </summary>
    /// <typeparam name="TRequest">El tipo de la solicitud a validar.</typeparam>
    /// <param name="request">La solicitud a validar.</param>
    /// <param name="validator">El validador que se utilizará para validar la solicitud.</param>
    /// <returns>
    /// Un <see cref="ModelStateDictionary"/> que contiene los errores de validación, si los hay; de lo contrario, <c>null</c>.
    /// </returns>
    public static async Task<ModelStateDictionary> ValidateModelAsync<TRequest>(
        TRequest request, IValidator<TRequest> validator) where TRequest : class
    {
        // Realiza la validación de la solicitud.
        ValidationResult validationResult = await validator.ValidateAsync(request);

        // Si la validación no es válida, maneja los errores.
        if (!validationResult.IsValid)
        {
            ModelStateDictionary modelStateDictionary = new();

            // Agrega cada error de validación al ModelStateDictionary.
            foreach (ValidationFailure failure in validationResult.Errors)
            {
                modelStateDictionary.AddModelError(
                    failure.PropertyName,
                    failure.ErrorMessage);
            }
            
            // retorna un listado de errores.
            return modelStateDictionary;
        }

        // Si la validación es válida, devuelve null.
        return null;
    }
}