//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="CustomerQueryService.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Services.Customers;

using Application.Interfaces;
using Contracts.Customers.Response;

public class CustomerQueryService
{
    // Variable privada para almacenar la referencia al ejecutor de consultas SQL.
    private readonly IDirectSQLQueryExecutor _sqlExecutor;

    // Constructor que inyecta la dependencia del ejecutor de consultas SQL.
    public CustomerQueryService(IDirectSQLQueryExecutor sqlExecutor)
    {
        _sqlExecutor = sqlExecutor; // Asigna el ejecutor inyectado a la variable local.
    }

    // Método asincrónico que retorna la próxima fecha de orden para todos los clientes.
    public async Task<List<NextOrderDateResponse>> GetAllNextOrderDatesAsync()
    {
        // Define la consulta SQL que calcula la última y la próxima fecha de orden basada en el historial de órdenes.
        string sql = @"
                WITH OrderIntervals AS (
                    SELECT 
                        c.custid,
                        c.companyname,
                        o.orderdate,
                        LAG(o.OrderDate) OVER (PARTITION BY c.custid ORDER BY o.OrderDate) AS PreviousOrderDate
                    FROM 
                        StoreSample.Sales.Customers c
                    INNER JOIN 
                        StoreSample.Sales.Orders o ON c.custid = o.custid
                ),
                AverageIntervals AS (
                    SELECT 
                        custid,
                        ROUND(AVG(DATEDIFF(day, PreviousOrderDate, OrderDate)), 0) AS AvgDaysBetweenOrders,
                        MAX(OrderDate) AS LastOrderDate
                    FROM 
                        OrderIntervals
                    WHERE 
                        PreviousOrderDate IS NOT NULL
                    GROUP BY 
                        custid
                )
                SELECT 
                    c.custid,
                    c.companyname,
                    a.LastOrderDate,
                    DATEADD(day, a.AvgDaysBetweenOrders, a.LastOrderDate) AS NextPredictedOrder
                FROM 
                    StoreSample.Sales.Customers c
                INNER JOIN 
                    AverageIntervals a ON c.custid = a.custid";

        // Ejecuta la consulta SQL y mapea los resultados a objetos NextOrderDateResponse
        return await _sqlExecutor.ExecuteQueryAsync(sql, new Dictionary<string, object>(), reader => new NextOrderDateResponse(
            CustId: reader.GetInt32(reader.GetOrdinal("custid")),
            CustomerName: reader.GetString(reader.GetOrdinal("companyname")),
            LastOrderDate: reader.GetDateTime(reader.GetOrdinal("LastOrderDate")),
            NextPredictedOrder: reader.GetDateTime(reader.GetOrdinal("NextPredictedOrder"))
        ));
    }
}