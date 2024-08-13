//-----------------------------------------------------------------------
// <author name = "Cristian Barbosa" email = "Cristianbr7@live.com">
// <copyright file="SQLServerContext.cs">
//     Copyright (c). Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------

namespace Infrastructure.Persistence.Context;

using Microsoft.EntityFrameworkCore;
using Domain.Entities.HR;
using Domain.Entities.Production;
using Domain.Entities.Sales;

/// <summary>
/// Contexto de base de datos para la conexión con SQL Server.
/// Este contexto gestiona las entidades del dominio y las mapea a las tablas correspondientes en la base de datos.
/// </summary>
public class SQLServerContext : DbContext
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="SQLServerContext"/> con las opciones proporcionadas.
    /// </summary>
    /// <param name="options">Opciones de configuración para el contexto de base de datos.</param>
    public SQLServerContext(DbContextOptions<SQLServerContext> options)
        : base(options)
    {}
    
    /// <summary>
    /// Obtiene o establece la colección de entidades <see cref="Employee"/> que se mapean a la tabla "Employees".
    /// </summary>
    public DbSet<Employee> Employees { get; set; }
        
    /// <summary>
    /// Obtiene o establece la colección de entidades <see cref="Category"/> que se mapean a la tabla "Categories".
    /// </summary>
    public DbSet<Category> Categories { get; set; }
        
    /// <summary>
    /// Obtiene o establece la colección de entidades <see cref="Product"/> que se mapean a la tabla "Products".
    /// </summary>
    public DbSet<Product> Products { get; set; }
        
    /// <summary>
    /// Obtiene o establece la colección de entidades <see cref="Supplier"/> que se mapean a la tabla "Suppliers".
    /// </summary>
    public DbSet<Supplier> Suppliers { get; set; }
        
    /// <summary>
    /// Obtiene o establece la colección de entidades <see cref="Customer"/> que se mapean a la tabla "Customers".
    /// </summary>
    public DbSet<Customer> Customers { get; set; }
        
    /// <summary>
    /// Obtiene o establece la colección de entidades <see cref="Order"/> que se mapean a la tabla "Orders".
    /// </summary>
    public DbSet<Order> Orders { get; set; }
        
    /// <summary>
    /// Obtiene o establece la colección de entidades <see cref="OrderDetail"/> que se mapean a la tabla "OrderDetails".
    /// </summary>
    public DbSet<OrderDetail> OrderDetails { get; set; }
        
    /// <summary>
    /// Obtiene o establece la colección de entidades <see cref="Shipper"/> que se mapean a la tabla "Shippers".
    /// </summary>
    public DbSet<Shipper> Shippers { get; set; }
    
}