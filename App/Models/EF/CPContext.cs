namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CPContext : DbContext
    {
        public CPContext()
            : base("name=CPContext")
        {
        }

        public virtual DbSet<CodigoPostal> CodigoPostals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodigoPostal>()
                .Property(e => e.d_codigo)
                .IsUnicode(false);

            modelBuilder.Entity<CodigoPostal>()
                .Property(e => e.d_asenta)
                .IsUnicode(false);

            modelBuilder.Entity<CodigoPostal>()
                .Property(e => e.d_tipo_asenta)
                .IsUnicode(false);

            modelBuilder.Entity<CodigoPostal>()
                .Property(e => e.d_mnpio)
                .IsUnicode(false);

            modelBuilder.Entity<CodigoPostal>()
                .Property(e => e.d_estado)
                .IsUnicode(false);

            modelBuilder.Entity<CodigoPostal>()
                .Property(e => e.d_ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<CodigoPostal>()
                .Property(e => e.d_zona)
                .IsUnicode(false);

            modelBuilder.Entity<CodigoPostal>()
                .Property(e => e.d_x)
                .IsUnicode(false);

            modelBuilder.Entity<CodigoPostal>()
                .Property(e => e.d_y)
                .IsUnicode(false);
        }
    }
}
