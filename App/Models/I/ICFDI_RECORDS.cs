using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.I
{
    public interface ICFDI_RECORDS
    {
        Task<List<CFDI_RECORDS>> Get();
        Task<CFDI_RECORDS> GetPerId(int id);
        Task<List<CFDI>> CFDIList();
    }
}
