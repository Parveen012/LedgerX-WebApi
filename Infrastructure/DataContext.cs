using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<User > Users { get; set; }
    public DbSet<ShopSettings > ShopSettings { get; set; }
    public DbSet<Transaction  > Transactions { get; set; }

}