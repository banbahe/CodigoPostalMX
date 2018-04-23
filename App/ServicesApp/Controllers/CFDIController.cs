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
       // private ICFDI_RECORDS ctrl;


        public CFDIController()
        {
            ctrl = new CFDI_RECORDS();
        }

        // GET: api/CFDI
        public IEnumerable<string> Get()
        {
            ctrl.
            return new string[] { "value1", "value2" };
        }

     
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"> </param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
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
