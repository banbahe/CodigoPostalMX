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
                        context.Entry(this).State = EntityState.Added;
                        flag = true;
                    }
                    context.SaveChanges();
                }
                return flag;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
