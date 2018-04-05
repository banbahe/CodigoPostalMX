namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CFDI_ADDRESS
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string calle { get; set; }

        [StringLength(500)]
        public string colonia { get; set; }

        [StringLength(500)]
        public string municipio { get; set; }

        [StringLength(500)]
        public string estado { get; set; }

        [StringLength(500)]
        public string pais { get; set; }

        [StringLength(500)]
        public string codigoPostal { get; set; }

        [StringLength(500)]
        public string noExterior { get; set; }

        [StringLength(500)]
        public string extra0 { get; set; }

        [StringLength(500)]
        public string extra01 { get; set; }

        [StringLength(500)]
        public string extra02 { get; set; }

        [StringLength(500)]
        public string extra03 { get; set; }

        [StringLength(500)]
        public string extra04 { get; set; }

        [StringLength(500)]
        public string extra05 { get; set; }

        [StringLength(500)]
        public string extra06 { get; set; }

        [StringLength(500)]
        public string extra07 { get; set; }
    }
}
