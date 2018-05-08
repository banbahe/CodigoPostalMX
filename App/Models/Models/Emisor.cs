using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Emisor
    {
        public int id { get; set; }
        public string rfc { get; set; }
        public string nombre { get; set; }
        public Domicilio domicilio { get; set; }
    }
}
