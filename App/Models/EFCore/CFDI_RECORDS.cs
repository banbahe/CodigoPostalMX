using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Models.I;
namespace Models.EF
{

    partial class CFDI_RECORDS : ICFDI_RECORDS
    {
        public bool AddSet()
        {
            bool flag = true;
            try
            {
                using (CPContext context = new CPContext())
                {
                    if (this.Id > 0)
                        context.Entry(this).State = EntityState.Modified;
                    else
                    {
                        if (!Exist())
                        {
                            context.Entry(this).State = EntityState.Added;
                            context.SaveChanges();
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }

                }
                return flag;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public bool Remove()
        {
            try
            {
                using (CPContext context = new CPContext())
                {
                    context.Entry(this).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return true;
        }

        public bool Exist()
        {
            bool flag;
            try
            {
                using (CPContext context = new CPContext())
                {
                    flag = context.CFDI_RECORDS.Where(x => x.UUID == this.UUID).FirstOrDefault() == null ? false : true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exist {0} detail: ", ex.Message, ex.InnerException.Message));
                flag = false;
            }
            return flag;
        }

        public async Task<List<CFDI_RECORDS>> List()
        {
            try
            {
                using (CPContext context = new CPContext())
                {
                    return await context.CFDI_RECORDS.ToListAsync<CFDI_RECORDS>();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<CFDI_RECORDS> Get()
        {

            try
            {
                using (CPContext context = new CPContext())
                {
                    if (!string.IsNullOrEmpty(UUID))
                    {
                        return await context.CFDI_RECORDS.SingleOrDefaultAsync(x => x.UUID == UUID);
                    }

                    if (this.Id > 0)
                        return await context.CFDI_RECORDS.SingleOrDefaultAsync(x => x.Id == Id);

                }
                throw new Exception("No cumplio filtro");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        async Task<List<CFDI_RECORDS>> ICFDI_RECORDS.Get()
        {
            try
            {
                using (CPContext context = new CPContext())
                {
                    var res = await context.CFDI_RECORDS.ToListAsync<CFDI_RECORDS>();
                    return res;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
 

        async Task<CFDI_RECORDS> ICFDI_RECORDS.GetPerId(int id)
        {
            try
            {
                using (CPContext context = new CPContext())
                {
                    var res = await context.CFDI_RECORDS.Where( x=> x.Id == id).FirstOrDefaultAsync<CFDI_RECORDS>();
                    return res;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
