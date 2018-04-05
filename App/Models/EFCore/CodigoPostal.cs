using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Models.EF
{

    partial class CodigoPostal
    {
        public async Task<List<CodigoPostal>> Get()
        {
            List<CodigoPostal> list = new List<CodigoPostal>();
            try
            {
                using (CPContext context = new CPContext())
                {
                    if (this.d_codigo.Length == 5)
                        list = await context.CodigoPostals.Where(x => x.d_codigo == this.d_codigo).ToListAsync();
                    if (this.id > 0)
                        list = await context.CodigoPostals.Where(x => x.id == this.id).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }
        public async Task<bool> AddSet()
        {
            bool flag = false;
            try
            {
                using (CPContext context = new CPContext())
                {
                    if (this.id > 0)
                    {
                        context.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(this).State = EntityState.Added;
                    }
                    await context.SaveChangesAsync();

                }
                flag = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            return flag;
        }
    }
}
