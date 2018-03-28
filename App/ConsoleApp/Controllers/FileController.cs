using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Tasks;
using Models.EF;
namespace ConsoleApp.Controllers
{
    public class FileController
    {

        public async Task<List<CodigoPostal>> Read()
        {
            List<CodigoPostal> list = new List<CodigoPostal>();
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\inmotion\Documents\GitHub\CodigoPostalMX\App\ConsoleApp\Assets\CPdescarga.txt"))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] parts = line.Split('|');
                        CodigoPostal codigoPostal = new CodigoPostal();
                        codigoPostal.d_codigo = parts[0];
                        codigoPostal.d_asenta = parts[1];
                        codigoPostal.d_tipo_asenta = parts[2];
                        codigoPostal.d_mnpio = parts[3];
                        codigoPostal.d_estado = parts[4];
                        codigoPostal.d_ciudad = parts[5];
                        codigoPostal.d_zona = parts[13];
                        codigoPostal.d_x = string.Empty;
                        codigoPostal.d_y = string.Empty;
                        list.Add(codigoPostal);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

        public async Task<bool> Create(List<CodigoPostal> list)
        {
            bool flag = false;
            try
            {
                foreach (var item in list)
                    await item.AddSet();

                flag = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            return flag;
        }

        public async Task<List<CodigoPostal>> Get()
        {
            return await new CodigoPostal().Get();
        }

        public async Task GetLatLng()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
