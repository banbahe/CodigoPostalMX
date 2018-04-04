namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CFDI_PeopleAddress
    {
        public int Id { get; set; }

        public int Id_People { get; set; }

        public int Id_Address { get; set; }

        public virtual CFDI_ADDRESS CFDI_ADDRESS { get; set; }

        public virtual CFDI_PEOPLE CFDI_PEOPLE { get; set; }
    }
}
