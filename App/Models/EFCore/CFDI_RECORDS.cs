﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Models.EF
{

    partial class CFDI_RECORDS
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
                            flag =  false;
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
                    flag = context.CFDI_RECORDS.SingleOrDefault(x => x.UUID == this.UUID) == null ? false : true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exist {0} detail: ", ex.Message, ex.InnerException.Message));
                flag = false;
            }
            return flag;
        }

        public List<CFDI_RECORDS> List()
        {
            try
            {
                using (CPContext context = new CPContext())
                {
                    return context.CFDI_RECORDS.ToList<CFDI_RECORDS>();
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

    }
}