//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="COWPQueryHandler.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Handlers.Orders.Commands.CreateOrderWithProduct;

// Importa las interfaces y clases necesarias para la ejecución del comando.
using Application.Interfaces;
using Contracts.Common.StoreProcedure.Response;
using ErrorOr;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;

/// <summary>
/// Maneja el comando para crear una orden y sus detalles de producto asociados en la base de datos.
/// </summary>
public class COWPQueryHandler : IRequestHandler<COWPQuery, ErrorOr<StoreProcedureResponse>>
{
    // Referencia al ejecutor de procedimientos almacenados para interactuar con la base de datos.
    private readonly IStoreProcedureExecutor _spExecutor;

    /// <summary>
    /// Inicializa una nueva instancia de la clase COWPQueryHandler con el ejecutor de procedimientos almacenados necesario.
    /// </summary>
    /// <param name="spExecutor">El servicio que ejecuta los procedimientos almacenados.</param>
    public COWPQueryHandler(IStoreProcedureExecutor spExecutor)
    {
        _spExecutor = spExecutor;
    }

    /// <summary>
    /// Asíncronamente maneja el comando COWPQuery para crear una orden y sus detalles de producto en la base de datos.
    /// </summary>
    /// <param name="query">El comando que contiene los datos necesarios para la creación de la orden y los detalles del producto.</param>
    /// <param name="cancellationToken">Token de cancelación que puede ser usado para cancelar la operación de ejecución del procedimiento almacenado.</param>
    /// <returns>Una tarea que, al completarse, devuelve un ErrorOr con una respuesta de procedimiento almacenado o un error.</returns>
    public async Task<ErrorOr<StoreProcedureResponse>> Handle(COWPQuery query, CancellationToken cancellationToken)
    {
        try
        {
            // Ejecuta el procedimiento almacenado 'InsertOrderAndDetails' configurando los parámetros necesarios.
            var response = await _spExecutor.ExecuteStoredProcedureAsync("InsertOrderAndDetails", cmd =>
            {
                // Configura los parámetros del procedimiento almacenado basados en los datos de entrada de la orden.
                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@CustId", SqlDbType.Int) { Value = query.createOrderAndDetailInput.CreateOrderInput.CustId },
                    new SqlParameter("@EmpId", SqlDbType.Int) { Value = query.createOrderAndDetailInput.CreateOrderInput.EmpId },
                    new SqlParameter("@ShipperId", SqlDbType.Int) { Value = query.createOrderAndDetailInput.CreateOrderInput.ShipperId },
                    new SqlParameter("@ShipName", SqlDbType.NVarChar, 100) { Value = query.createOrderAndDetailInput.CreateOrderInput.ShipName },
                    new SqlParameter("@ShipAddress", SqlDbType.NVarChar, 100) { Value = query.createOrderAndDetailInput.CreateOrderInput.ShipAddress },
                    new SqlParameter("@ShipCity", SqlDbType.NVarChar, 100) { Value = query.createOrderAndDetailInput.CreateOrderInput.ShipCity },
                    new SqlParameter("@OrderDate", SqlDbType.Date) { Value = query.createOrderAndDetailInput.CreateOrderInput.OrderDate },
                    new SqlParameter("@RequiredDate", SqlDbType.Date) { Value = query.createOrderAndDetailInput.CreateOrderInput.RequiredDate },
                    new SqlParameter("@ShippedDate", SqlDbType.Date) { Value = query.createOrderAndDetailInput.CreateOrderInput.ShippedDate ?? (object)DBNull.Value },
                    new SqlParameter("@Freight", SqlDbType.Decimal) { Value = query.createOrderAndDetailInput.CreateOrderInput.Freight },
                    new SqlParameter("@ShipCountry", SqlDbType.NVarChar, 100) { Value = query.createOrderAndDetailInput.CreateOrderInput.ShipCountry },
                    // Parámetros relacionados con los detalles del producto.
                    new SqlParameter("@ProductId", SqlDbType.Int) { Value = query.createOrderAndDetailInput.OrderDetailInput.ProductId },
                    new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = query.createOrderAndDetailInput.OrderDetailInput.UnitPrice },
                    new SqlParameter("@Qty", SqlDbType.Int) { Value = query.createOrderAndDetailInput.OrderDetailInput.Qty },
                    new SqlParameter("@Discount", SqlDbType.Decimal) { Value = query.createOrderAndDetailInput.OrderDetailInput.Discount }
                });
            });

            // Devuelve una respuesta de éxito del procedimiento almacenado.
            return new StoreProcedureResponse()
            {
                Message = "Exit_Success"
            };
        }
        catch (Exception ex) // Captura cualquier excepción que ocurra durante la ejecución del procedimiento almacenado.
        {
            // Devuelve un error que describe el problema ocurrido durante el acceso a la base de datos.
            return Error.Failure("DatabaseError", $"An error occurred: {ex.Message}");
        }
    }
}