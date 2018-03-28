namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    [Table("CodigoPostal")]
    public partial class CodigoPostal
    {
        public int id { get; set; }

        [Required]
        [StringLength(5)]
        public string d_codigo { get; set; }

        [StringLength(250)]
        public string d_asenta { get; set; }

        [StringLength(250)]
        public string d_tipo_asenta { get; set; }

        [StringLength(250)]
        public string d_mnpio { get; set; }

        [StringLength(250)]
        public string d_estado { get; set; }

        [StringLength(250)]
        public string d_ciudad { get; set; }

        [StringLength(250)]
        public string d_zona { get; set; }

        [StringLength(250)]
        public string d_x { get; set; }

        [StringLength(250)]
        public string d_y { get; set; }

        public async Task<bool> AddSet()
        {
            try
            {
                using (CPContext context = new CPContext())
                {
                    if(this.id > 0)
                    {
                        context.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(this).State = EntityState.Added;
                    }
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<CodigoPostal>> Get()
        {
            try
            {
                using (CPContext context = new CPContext())
                {
                    return await context.CodigoPostals.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }


}
