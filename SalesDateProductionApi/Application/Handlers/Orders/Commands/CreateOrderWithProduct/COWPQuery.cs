//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="COWPQuery.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

// Define el espacio de nombres que agrupa funcionalidades relacionadas con la creación de órdenes y productos.
namespace Application.Handlers.Orders.Commands.CreateOrderWithProduct;

// Importaciones necesarias para utilizar clases relacionadas con respuestas de procedimientos almacenados,
// entradas de órdenes, el manejador de errores y MediatR.
using Contracts.Common.StoreProcedure.Response;
using Contracts.Orders.Inputs;
using ErrorOr;
using MediatR;


/// <summary>
/// Representa una consulta de tipo command para crear una orden junto con detalles del producto.
/// </summary>
/// <remarks>
/// Este comando se utiliza para encapsular todos los datos necesarios para la creación de una orden
/// y sus detalles de producto asociados en un único objeto. Al ser un record, garantiza la inmutabilidad
/// de los datos una vez instanciado, promoviendo prácticas seguras en ambientes concurrentes.
/// </remarks>
/// <param name="createOrderAndDetailInput"></param>
public record COWPQuery(CreateOrderAndDetailInput createOrderAndDetailInput) : IRequest<ErrorOr<StoreProcedureResponse>>;
