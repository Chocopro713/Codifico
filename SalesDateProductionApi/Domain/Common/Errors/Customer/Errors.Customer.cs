//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="Errors.Customer.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Domain.Common.Error.Customer;

using ErrorOr;

/// <summary>
/// Contiene definiciones para los errores relacionados con clientes.
/// </summary>
public static partial class Errors
{
    /// <summary>
    /// Clase para manejar errores específicos de clientes.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Error que indica que un cliente no fue encontrado.
        /// </summary>
        public static Error CustomerNotFound => Error.NotFound(
            code: "Customer.NotFound",
            description: "Usuario no encontrado");
    }
}