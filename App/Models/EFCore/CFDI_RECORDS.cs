using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Models.I;
using Models;

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
                    var res = await context.CFDI_RECORDS.Where(x => x.Id == id).FirstOrDefaultAsync<CFDI_RECORDS>();
                    return res;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<CFDI>> CFDIList()
        {
            List<CFDI> listCFDI = new List<CFDI>();
            try
            {
                using (CPContext context = new CPContext())
                {
                    var result = await context.CFDI_RECORDS.ToListAsync<CFDI_RECORDS>();
                    foreach (var item in result)
                    {
                        CFDI cfdi = new CFDI();
                        cfdi.id = item.Id;
                        cfdi.version = item.version;
                        cfdi.serie = item.serie;
                        cfdi.folio = item.folio;
                        cfdi.fecha = item.fecha.Value.ToString();
                        cfdi.formaDePago = item.formaDePago;
                        cfdi.subTotal = item.formaDePago;
                        cfdi.TipoCambio = item.TipoCambio.ToString();
                        cfdi.Moneda = item.Moneda;
                        cfdi.total = item.total.ToString();
                        cfdi.metodoDePago = item.metodoDePago;
                        cfdi.UUID = item.UUID;

                        // Emisor
                        cfdi.emisor = new Emisor();

                        if (item.Id_Emisor > 0)
                        {
                            CFDI_PEOPLE objCFDI_PEOPLE = new CFDI_PEOPLE();
                            objCFDI_PEOPLE.Id = item.Id_Emisor;
                            // test
                            objCFDI_PEOPLE = objCFDI_PEOPLE.Get();
                            cfdi.emisor.id = objCFDI_PEOPLE.Id;
                            cfdi.emisor.nombre = objCFDI_PEOPLE.Nombre;
                            cfdi.emisor.rfc = objCFDI_PEOPLE.RFC;
                            // get address to emisor
                            cfdi.emisor.domicilio = new Domicilio();

                        }

                        listCFDI.Add(cfdi);
                    }
                }
                return listCFDI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
