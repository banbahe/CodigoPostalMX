using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CFDI
    {
        public int id { get; set; }
        public string version { get; set; }
        public string serie { get; set; }
        public string folio { get; set; }
        public string fecha { get; set; }
        public string formaDePago { get; set; }
        public string subTotal { get; set; }
        public string TipoCambio { get; set; }
        public string Moneda { get; set; }
        public string total { get; set; }
        public string tipoDeComprobante { get; set; }
        public string metodoDePago { get; set; }

        public string UUID { get; set; }

        public Emisor emisor { get; set; }
        public Receptor receptor { get; set; }

    }
}
