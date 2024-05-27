
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Products> Products {set;get;}
        public DbSet<ProductBrand> ProductBrand {set;get;}
        public DbSet<ProductType> ProductType {set;get;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //convert entity decimal to double because sqlite not support decimal
            if(Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(
                        p => p.PropertyType == typeof(decimal)
                        );
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                        .HasConversion<double>();
                    }

                }
            }
        }
    }
}