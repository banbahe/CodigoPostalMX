namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CFDI_RECORDS
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string version { get; set; }

        [StringLength(10)]
        public string serie { get; set; }

        [StringLength(50)]
        public string folio { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(50)]
        public string formaDePago { get; set; }

        public decimal? subtotal { get; set; }

        public decimal? TipoCambio { get; set; }

        [StringLength(10)]
        public string Moneda { get; set; }

        public decimal? total { get; set; }

        [StringLength(50)]
        public string tipoDeComprobante { get; set; }

        [StringLength(50)]
        public string metodoDePago { get; set; }

        [Required]
        [StringLength(50)]
        public string UUID { get; set; }

        public int Id_Emisor { get; set; }

        public int Id_Receptor { get; set; }
    }
}
