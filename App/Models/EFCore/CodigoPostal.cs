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
            try
            {
                using (CPContext context = new CPContext())
                {
                    return await context.CodigoPostals.Where(x => string.IsNullOrEmpty(x.d_x) &&
                                                             x.id >= 64140 &&
                                                             x.id < 71444).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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
