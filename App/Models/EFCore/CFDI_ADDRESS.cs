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
                    return context.CFDI_ADDRESS.SingleOrDefault(x => x.Id == this.Id);
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

        public async Task<bool> AddSetAsync()
        {
            bool flag = false;
            try
            {
                using (CPContext context = new CPContext())
                {
                    if (this.Id > 0)
                    {
                        context.Entry(this).State = EntityState.Modified;
                        
                    }
                    else
                    {
                        context.Entry(this).State = EntityState.Added;
                    }

                    // add new configuration
                    CodigoPostal codigoPostal = new CodigoPostal();
                    codigoPostal.d_codigo = this.codigoPostal;
                    var result = await codigoPostal.Get();

                    if (result.Count() > 1)
                    {
                        var tmp = result.Where(x => x.d_asenta.ToLower().Contains(this.colonia.ToLower())).FirstOrDefault();
                        this.extra0 = (tmp == null) ? string.Empty : tmp.id.ToString();
                    }
                    if (result.Count() == 1)
                    {
                        var tmp = result.FirstOrDefault();
                        this.extra0 = tmp.id.ToString();
                    }
                    if (result.Count() == 0)
                        this.extra0 = string.Empty;

                    context.SaveChanges();
                    flag = true;
                }
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
