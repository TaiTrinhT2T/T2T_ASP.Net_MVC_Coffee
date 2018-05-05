namespace MySite.Areas.Data_Access.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Responsibilty> Responsibilties { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Responsibilty>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Responsibilty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Responsibilty>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Responsibilties)
                .Map(m => m.ToTable("Responsibilty_Role").MapLeftKey("ID Res").MapRightKey("ID Role"));
        }
    }
}
