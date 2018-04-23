using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.I
{
    interface ICFDI_RECORDS
    {
          Task<List<CFDI_RECORDS>> Get();
    }
}
