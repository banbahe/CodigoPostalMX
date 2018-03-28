using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Tasks;
using Models.EF;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public async Task GetLatLng(List<CodigoPostal> list)
        {
            try
            {
                foreach (var item in list)
                {
                    var res = await WebRequest(item.d_asenta, item.d_mnpio, item.d_estado, item.d_ciudad);
                    JObject jObject = JObject.Parse(res);
                    try
                    {
                        var reqItem = jObject["results"][0]["geometry"]["location"];
                        foreach (var itemJson in reqItem)
                        {
                            if (((Newtonsoft.Json.Linq.JProperty)itemJson).Name == "lat")
                                item.d_x = ((Newtonsoft.Json.Linq.JProperty)itemJson).Value.ToString();
                            if (((Newtonsoft.Json.Linq.JProperty)itemJson).Name == "lng")
                                item.d_y = ((Newtonsoft.Json.Linq.JProperty)itemJson).Value.ToString();
                        }
                        await item.AddSet();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        
                    }
                    
                    //Console.WriteLine(res);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task<string> WebRequest(string item0, string item1, string item2, string item3)
        {
            string WEBSERVICE_URL = string.Concat("https://maps.googleapis.com/maps/api/geocode/json?address=", item0, "+", item1, "+", item2, "+", item3, "&key=AIzaSyBSRUW5pYvODm4xuX6_gZC2EcPbxm9kdjQ");
            // https://maps.googleapis.com/maps/api/geocode/json?address=Las Águilas+Nezahualcóyotl+México+Ciudad Nezahualcóyotl&key=AIzaSyBSRUW5pYvODm4xuX6_gZC2EcPbxm9kdjQ

            string result = string.Empty;
            Thread.Sleep(300);
            var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
            try
            {


                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 18000;
                    webRequest.ContentType = "application/json";
                    //webRequest.Headers.Add("Authorization", Authorization);

                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        //  total = s.Length;
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            result = await sr.ReadToEndAsync();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
