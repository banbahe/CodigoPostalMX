using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Models.I;
using Models.EF;

namespace ServicesApp.Controllers
{
    public class CFDIController : ApiController
    {
        private ICFDI_RECORDS ctrl;


        public CFDIController()
        {
            ctrl = new CFDI_RECORDS();
        }

        // GET: api/CFDI
        /// <summary>
        /// Obtiene facturas
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> Get()
        {
            //Task task = new Task(() => ctrl.Get());
            //task.Start();
            //task.Wait();
            //var result = Task.FromResult(task);

            var taskCFDIList = await ctrl.CFDIList();
            

            var list = await ctrl.Get();

            var res = JsonConvert.SerializeObject(list, Formatting.None);
            List<string> result = new List<string>();
            result.Add(res);
            return result;
        }


        public async Task<string> Get(int id)
        {
            var item = await ctrl.GetPerId(id);
            var res = JsonConvert.SerializeObject(item, Formatting.None);
            return res;
        }

        // POST: api/CFDI
        /// <summary>
        /// Metodo post
        /// </summary>
        /// <param name="value">valor vallue</param>
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CFDI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CFDI/5
        public void Delete(int id)
        {
        }
    }
}
