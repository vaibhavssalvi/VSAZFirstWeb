namespace MyStudentDAL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class MyWebStudentContext : DbContext
    {
        //Data Source=CHIUMYRAH;Initial Catalog=MyWebNewDB;Integrated Security=True
        //Server=CHIUMYRAH;Database=MyWebNewDB;Trusted_Connection=True;Integrated Security=True;
        //Data Source = CHIUMYRAH; Initial Catalog = MyWebNewDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        public MyWebStudentContext() : base("name=ConnMyWebNewDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=CHIUMYRAH;Database=MyWebNewDB;Trusted_Connection=True;Integrated Security=True;");
        //    }
        //}
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ratings>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Ratings>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Ratings>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Ratings)
                .HasForeignKey(e => e.Rating);
        }

    }
}
