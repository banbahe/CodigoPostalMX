using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    partial class CFDI_ADDRESS
    {
        public CFDI_ADDRESS Get()
        {
            try
            {
                using (CPContext context = new CPContext())
                {
                    return context.CFDI_ADDRESS.SingleOrDefault(x => x.Id_CFDI_PEOPLE == this.Id_CFDI_PEOPLE);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<CFDI_ADDRESS> List()
        {
            using (CPContext context = new CPContext())
            {
                return context.CFDI_ADDRESS.Where(x => !string.IsNullOrEmpty(x.codigoPostal)).ToList();
            }
        }

        public bool AddSet()
        {
            bool flag = false;
            try
            {
                using (CPContext context = new CPContext())
                {
                    if (this.Id > 0)
                        context.Entry(this).State = EntityState.Modified;
                    else
                        context.Entry(this).State = EntityState.Added;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;
        }
    }
}
