//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="CreateOrderAndDetailInput.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Contracts.Orders.Inputs;

/// <summary>
/// Representa los datos de entrada necesarios para crear una orden y sus detalles asociados.
/// </summary>
/// <param name="CreateOrderInput">Datos necesarios para la creación de la orden.</param>
/// <param name="OrderDetailInput">Datos detallados del producto asociado a la orden.</param>
public record CreateOrderAndDetailInput(
    CreateOrderInput CreateOrderInput,
    OrderDetailInput OrderDetailInput
    );