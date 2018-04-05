using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp.Controllers
{
    public interface ICFDI
    {
        Models.CFDI Read(string path);

        bool Exist(Models.CFDI cfdi);

        Task<bool> AddAsync(Models.CFDI cfdi);

        bool Move(string source, string destination, string name);

        int Status(Models.CFDI cdfi);

        List<string> GetFiles(string path, List<string> kind);

        //List<Repository.CFDI_RECORDS> List();
        List<Models.CFDI> List();

        //Models.CFDI Get();
        Task<Models.CFDI> Get(int id);

        //async  AddAsync
    }
}
