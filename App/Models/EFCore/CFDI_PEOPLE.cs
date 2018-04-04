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
    partial class CFDI_PEOPLE
    {
        public enum TipoPersona { EMISOR = 0, RECEPTOR = 1 };

        public List<CFDI_PEOPLE> List()
        {
            try
            {
                using (CPContext context = new CPContext())
                {
                    //return context.CFDI_PEOPLE.Include(x => x.CFDI_ADDRESS).ToList<CFDI_PEOPLE>();
                    return context.CFDI_PEOPLE.ToList<CFDI_PEOPLE>();
                }
            }
            catch (Exception ex)
            {
                throw;
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

                    context.SaveChanges();
                }
                flag = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("CFDI_PEOPLE AddSet {0}  ==> {1}", ex.Message, ex.InnerException));
            }
            return flag;
        }
        public bool Exist()
        {
            bool flag = false;
            try
            {
                using (CPContext context = new CPContext())
                {
                    flag = context.CFDI_PEOPLE.SingleOrDefault(x => x.RFC == this.RFC) == null ? false : true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;
        }
        public CFDI_PEOPLE Get()
        {
            try
            {
                using (CPContext context = new CPContext())
                {
                    if (this.Id > 0)
                    {
                        return context.CFDI_PEOPLE.Include(fk => fk.CFDI_PeopleAddress)
                          .FirstOrDefault(x => x.Id == this.Id);
                    }
                    if (string.IsNullOrEmpty(this.RFC))
                    {
                        throw new Exception("Es requerido el RFC");
                    }
                    else if (this.RFC == "XAXX010101000" || this.RFC == "XEXX010101000")
                    {
                        return null;
                    }

                    else
                    {
                        return context.CFDI_PEOPLE.Include(fk => fk.CFDI_PeopleAddress)
                              .FirstOrDefault(x => x.RFC == this.RFC && x.Tipo == this.Tipo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}
