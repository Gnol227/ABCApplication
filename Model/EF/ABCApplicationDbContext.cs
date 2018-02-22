namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ABCApplicationDbContext : DbContext
    {
        public ABCApplicationDbContext()
            : base("name=ABCApplicationDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Query> Queries { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CatName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CatDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CusName)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CusPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CusEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CusAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Make)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Query>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
