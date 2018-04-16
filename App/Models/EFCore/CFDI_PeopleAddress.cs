using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    partial class CFDI_PeopleAddress
    {
        public async Task<bool> AddSet()
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
                        context.Entry(this).State = EntityState.Added;
                        flag = true;
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return flag;

        }

        public async Task<CFDI_PeopleAddress> GetAsync()
        {
            CFDI_PeopleAddress result = new CFDI_PeopleAddress();
            try
            {
                using (CPContext context = new CPContext())
                {
                    if (this.Id > 0)
                    {
                        result = await context.CFDI_PeopleAddress.Include("CFDI_PEOPLE").Include("CFDI_ADDRESS").Where(x => x.Id == this.Id).FirstAsync();
                    }
                    if (this.Id_People > 0)
                    {
                        result = await context.CFDI_PeopleAddress.Include("CFDI_PEOPLE").Include("CFDI_ADDRESS").Where(x => x.Id_People == this.Id_People).FirstOrDefaultAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error {0} por {1}", ex.Message, ex.InnerException.Message));
                throw;
            }
            return result;
        }
    }
}
