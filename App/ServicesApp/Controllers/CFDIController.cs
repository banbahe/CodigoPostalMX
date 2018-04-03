using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace ServicesApp.Controllers
{
    public class CFDIController : ApiController
    {
        // GET: api/CFDI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CFDI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CFDI
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
