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

        public virtual DbSet<CFDI_ADDRESS> CFDI_ADDRESS { get; set; }
        public virtual DbSet<CFDI_PEOPLE> CFDI_PEOPLE { get; set; }
        public virtual DbSet<CFDI_PeopleAddress> CFDI_PeopleAddress { get; set; }
        public virtual DbSet<CFDI_RECORDS> CFDI_RECORDS { get; set; }
        public virtual DbSet<CodigoPostal> CodigoPostals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.calle)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.colonia)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.municipio)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.pais)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.codigoPostal)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.noExterior)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.extra0)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.extra01)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.extra02)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.extra03)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.extra04)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.extra05)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.extra06)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .Property(e => e.extra07)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_ADDRESS>()
                .HasMany(e => e.CFDI_PeopleAddress)
                .WithRequired(e => e.CFDI_ADDRESS)
                .HasForeignKey(e => e.Id_Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CFDI_PEOPLE>()
                .Property(e => e.RFC)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_PEOPLE>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_PEOPLE>()
                .HasMany(e => e.CFDI_PeopleAddress)
                .WithRequired(e => e.CFDI_PEOPLE)
                .HasForeignKey(e => e.Id_People)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CFDI_RECORDS>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_RECORDS>()
                .Property(e => e.serie)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_RECORDS>()
                .Property(e => e.folio)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_RECORDS>()
                .Property(e => e.formaDePago)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_RECORDS>()
                .Property(e => e.subtotal)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CFDI_RECORDS>()
                .Property(e => e.TipoCambio)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CFDI_RECORDS>()
                .Property(e => e.Moneda)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_RECORDS>()
                .Property(e => e.total)
                .HasPrecision(18, 4);

            modelBuilder.Entity<CFDI_RECORDS>()
                .Property(e => e.tipoDeComprobante)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_RECORDS>()
                .Property(e => e.metodoDePago)
                .IsUnicode(false);

            modelBuilder.Entity<CFDI_RECORDS>()
                .Property(e => e.UUID)
                .IsUnicode(false);

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
