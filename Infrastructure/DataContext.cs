using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ShopSettings> ShopSettings { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);

            entity.HasIndex(x => x.Email).IsUnique();

            entity.Property(x => x.PhoneNumber).HasMaxLength(10).IsRequired();


        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.FirstName).IsRequired().HasMaxLength(100);

            entity.Property(x => x.LastName).IsRequired().HasMaxLength(100);

            entity.HasIndex(x => x.Email).IsUnique();

            entity.Property(x => x.PhoneNumber).HasMaxLength(10).IsRequired();

            entity.Property(x => x.Address1).IsRequired().HasMaxLength(200);

            entity.Property(x => x.Address2).HasMaxLength(200);

            entity.Property(x => x.City).IsRequired().HasMaxLength(100);

            entity.Property(x => x.State).IsRequired().HasMaxLength(100);

            entity.Property(x => x.Country).IsRequired().HasMaxLength(100);

            entity.Property(x => x.PinCode).IsRequired();

        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.TransactionType).IsRequired();

            entity.Property(x => x.Amount).IsRequired();

            entity.Property(x => x.Description).HasMaxLength(250);

        });

        modelBuilder.Entity<ShopSettings>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.ShopName).IsRequired().HasMaxLength(150);

            entity.Property(x => x.OwnerName).IsRequired().HasMaxLength(100);

            entity.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(10);

            entity.Property(x => x.Email).IsRequired().HasMaxLength(150);

            entity.HasIndex(x => x.Email).IsUnique();

            entity.Property(x => x.GstNumber).HasMaxLength(20);


        });

         modelBuilder.Entity<User>()
            .Property(x => x.Role)
            .HasConversion<string>();

        //modelBuilder.Entity<Transaction>()
        //    .Property(x => x.TransactionType)
        //    .HasConversion<string>();



    }

}