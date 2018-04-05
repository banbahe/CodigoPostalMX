using ConsoleApp.Models;
using Models.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp.Controllers
{
    public class CFDIController : ICFDI
    {
        private CFDI_RECORDS _cfdi_records;
        private CFDI_PEOPLE _cfdi_people;
        private CFDI_ADDRESS _cfdi_address;

        public Models.CFDI Read(string path)
        {
            Models.CFDI cfdi = new Models.CFDI();
            XNamespace xCfdi = @"http://www.sat.gob.mx/cfd/3";
            XNamespace xTfd = @"http://www.sat.gob.mx/TimbreFiscalDigital";

            try
            {
                if (string.IsNullOrEmpty(path))
                    throw new Exception("* path es necesario");

                if (Path.GetExtension(path.ToLower()) != ".xml")
                    throw new Exception("* Solo se permiten archivos xml ");
                // start 
                XDocument xdoc = XDocument.Load(path);

                var headElement = xdoc.Element(xCfdi + "Comprobante");
                var emisorElement = xdoc.Element(xCfdi + "Comprobante").Element(xCfdi + "Emisor");
                var emisorDomicilioElement = xdoc.Element(xCfdi + "Comprobante").Element(xCfdi + "Emisor").Element(xCfdi + "DomicilioFiscal");

                var receptorElement = xdoc.Element(xCfdi + "Comprobante").Element(xCfdi + "Receptor");
                var receptorDomicilioElement = xdoc.Element(xCfdi + "Comprobante").Element(xCfdi + "Receptor").Element(xCfdi + "Domicilio");

                var elementouuid = xdoc.Element(xCfdi + "Comprobante").Element(xCfdi + "Complemento").Element(xTfd + "TimbreFiscalDigital");
                var elementrfc = xdoc.Element(xCfdi + "Comprobante").Element(xCfdi + "Emisor");

                cfdi.version = string.IsNullOrEmpty((string)headElement.Attribute("version")) ? (string)headElement.Attribute("Version") : (string)headElement.Attribute("version");
                cfdi.serie = string.IsNullOrEmpty((string)headElement.Attribute("serie")) ? (string)headElement.Attribute("Serie") : (string)headElement.Attribute("serie");

                cfdi.folio = string.IsNullOrEmpty((string)headElement.Attribute("folio")) ? (string)headElement.Attribute("Folio") : (string)headElement.Attribute("Folio");
                cfdi.fecha = (string)elementouuid.Attribute("FechaTimbrado");
                cfdi.formaDePago = string.IsNullOrEmpty((string)headElement.Attribute("formaDePago")) ? (string)headElement.Attribute("FormaPago") : (string)headElement.Attribute("formaDePago");
                cfdi.subTotal = string.IsNullOrEmpty((string)headElement.Attribute("subTotal")) ? (string)headElement.Attribute("SubTotal") : (string)headElement.Attribute("subTotal");
                cfdi.TipoCambio = (string)headElement.Attribute("TipoCambio");
                cfdi.Moneda = (string)headElement.Attribute("Moneda");
                cfdi.total = string.IsNullOrEmpty((string)headElement.Attribute("total")) ? (string)headElement.Attribute("Total") : (string)headElement.Attribute("total");
                cfdi.UUID = (string)elementouuid.Attribute("UUID");
                cfdi.metodoDePago = string.IsNullOrEmpty((string)headElement.Attribute("metodoDePago")) ? (string)headElement.Attribute("MetodoPago") : (string)headElement.Attribute("metodoDePago");
                cfdi.tipoDeComprobante = string.IsNullOrEmpty((string)headElement.Attribute("tipoDeComprobante")) ? (string)headElement.Attribute("TipoDeComprobante") : (string)headElement.Attribute("tipoDeComprobante");
                // Emisor
                cfdi.emisor = new Emisor();
                cfdi.emisor.nombre = string.IsNullOrEmpty((string)emisorElement.Attribute("nombre")) ? (string)emisorElement.Attribute("Nombre") : (string)emisorElement.Attribute("nombre");
                cfdi.emisor.rfc = string.IsNullOrEmpty((string)emisorElement.Attribute("rfc")) ? (string)emisorElement.Attribute("Rfc") : (string)emisorElement.Attribute("rfc");
                cfdi.emisor.domicilio = new Domicilio();
                try
                {
                    if (cfdi.version == "3.2")
                    {
                        cfdi.emisor.domicilio.calle = string.IsNullOrEmpty((string)emisorDomicilioElement.Attribute("calle")) ? string.Empty : (string)emisorDomicilioElement.Attribute("calle");
                        cfdi.emisor.domicilio.codigoPostal = string.IsNullOrEmpty((string)emisorDomicilioElement.Attribute("codigoPostal")) ? string.Empty : (string)emisorDomicilioElement.Attribute("codigoPostal");
                        cfdi.emisor.domicilio.colonia = string.IsNullOrEmpty((string)emisorDomicilioElement.Attribute("colonia")) ? string.Empty : (string)emisorDomicilioElement.Attribute("colonia");
                        cfdi.emisor.domicilio.estado = string.IsNullOrEmpty((string)emisorDomicilioElement.Attribute("estado")) ? string.Empty : (string)emisorDomicilioElement.Attribute("estado");
                        cfdi.emisor.domicilio.municipio = string.IsNullOrEmpty((string)emisorDomicilioElement.Attribute("municipio")) ? string.Empty : (string)emisorDomicilioElement.Attribute("municipio");
                        cfdi.emisor.domicilio.pais = string.IsNullOrEmpty((string)emisorDomicilioElement.Attribute("pais")) ? string.Empty : (string)emisorDomicilioElement.Attribute("pais");
                        cfdi.emisor.domicilio.noExterior = string.IsNullOrEmpty((string)emisorDomicilioElement.Attribute("noExterior")) ? string.Empty : (string)emisorDomicilioElement.Attribute("noExterior");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Emisor error {0} , more details {1}", ex.Message, ex.InnerException));
                }

                cfdi.receptor = new Receptor();
                cfdi.receptor.nombre = string.IsNullOrEmpty((string)receptorElement.Attribute("nombre")) ? (string)receptorElement.Attribute("Nombre") : (string)receptorElement.Attribute("nombre");
                cfdi.receptor.rfc = string.IsNullOrEmpty((string)receptorElement.Attribute("rfc")) ? (string)receptorElement.Attribute("Rfc") : (string)receptorElement.Attribute("rfc");
                cfdi.receptor.domicilio = new Domicilio();
                try
                {
                    if (cfdi.version == "3.2")
                    {
                        cfdi.receptor.domicilio.calle = string.IsNullOrEmpty((string)receptorDomicilioElement.Attribute("calle")) ? string.Empty : (string)receptorDomicilioElement.Attribute("calle");
                        cfdi.receptor.domicilio.codigoPostal = string.IsNullOrEmpty((string)receptorDomicilioElement.Attribute("codigoPostal")) ? string.Empty : (string)receptorDomicilioElement.Attribute("codigoPostal");
                        cfdi.receptor.domicilio.colonia = string.IsNullOrEmpty((string)receptorDomicilioElement.Attribute("colonia")) ? string.Empty : (string)receptorDomicilioElement.Attribute("colonia");
                        cfdi.receptor.domicilio.estado = string.IsNullOrEmpty((string)receptorDomicilioElement.Attribute("estado")) ? string.Empty : (string)receptorDomicilioElement.Attribute("estado");
                        cfdi.receptor.domicilio.municipio = string.IsNullOrEmpty((string)receptorDomicilioElement.Attribute("municipio")) ? string.Empty : (string)receptorDomicilioElement.Attribute("municipio");
                        cfdi.receptor.domicilio.pais = string.IsNullOrEmpty((string)receptorDomicilioElement.Attribute("pais")) ? string.Empty : (string)receptorDomicilioElement.Attribute("pais");
                        cfdi.emisor.domicilio.noExterior = string.IsNullOrEmpty((string)emisorDomicilioElement.Attribute("noExterior")) ? string.Empty : (string)receptorDomicilioElement.Attribute("noExterior");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Receptor error {0} , more details {1}", ex.Message, ex.InnerException));
                }
                return cfdi;

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public async Task<bool> AddAsync(Models.CFDI arg_cfdi)
        {
            bool flag;
            try
            {
                // add emisor
                _cfdi_people = new CFDI_PEOPLE()
                {
                    Nombre = arg_cfdi.emisor.nombre,
                    RFC = arg_cfdi.emisor.rfc,
                    Tipo = (int)CFDI_PEOPLE.TipoPersona.EMISOR
                };
                bool emisor = _cfdi_people.AddSet();

                // add receptor
                _cfdi_people = new CFDI_PEOPLE()
                {
                    Nombre = arg_cfdi.receptor.nombre,
                    RFC = arg_cfdi.receptor.rfc,
                    Tipo = (int)CFDI_PEOPLE.TipoPersona.RECEPTOR
                };
                bool receptor = _cfdi_people.AddSet();

                // add address emisor

                _cfdi_address = new CFDI_ADDRESS()
                {
                    calle = arg_cfdi.emisor.domicilio.calle,
                    colonia = arg_cfdi.emisor.domicilio.colonia,
                    municipio = arg_cfdi.emisor.domicilio.municipio,
                    estado = arg_cfdi.emisor.domicilio.estado,
                    pais = arg_cfdi.emisor.domicilio.pais,
                    codigoPostal = arg_cfdi.emisor.domicilio.codigoPostal,
                    noExterior = arg_cfdi.emisor.domicilio.noExterior,
                };
                var res = await _cfdi_address.AddSetAsync();


                // add address receptor
                _cfdi_address = new CFDI_ADDRESS()
                {
                    calle = arg_cfdi.receptor.domicilio.calle,
                    colonia = arg_cfdi.receptor.domicilio.colonia,
                    municipio = arg_cfdi.receptor.domicilio.municipio,
                    estado = arg_cfdi.receptor.domicilio.estado,
                    pais = arg_cfdi.receptor.domicilio.pais,
                    codigoPostal = arg_cfdi.receptor.domicilio.codigoPostal,
                    noExterior = arg_cfdi.receptor.domicilio.noExterior,
                };

                // add cfdi 
                _cfdi_records = new CFDI_RECORDS()
                {
                    version = arg_cfdi.version,
                    serie = arg_cfdi.serie,
                    folio = arg_cfdi.folio,
                    fecha = DateTime.Parse(arg_cfdi.fecha),
                    formaDePago = arg_cfdi.formaDePago,
                    subtotal = Decimal.Parse(arg_cfdi.subTotal),
                    TipoCambio = Decimal.Parse(arg_cfdi.TipoCambio),
                    Moneda = arg_cfdi.version,
                    total = Decimal.Parse(arg_cfdi.total),
                    tipoDeComprobante = arg_cfdi.tipoDeComprobante,
                    metodoDePago = arg_cfdi.metodoDePago,
                    UUID = arg_cfdi.UUID,
                    Id_Emisor = arg_cfdi.emisor.id,
                    Id_Receptor = arg_cfdi.receptor.id,
                };
                flag = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=============================================================");
                Console.WriteLine(string.Format("Error al add cfdi record", ex.Message));
                Console.WriteLine("=============================================================");
                flag = false;
            }
            return flag;
        }

        public bool Exist(Models.CFDI cfdi)
        {
            try
            {
                _cfdi_records = new CFDI_RECORDS();
                _cfdi_records.UUID = cfdi.UUID;
                return _cfdi_records.Exist();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("CFDIController Exist error {0} ", ex.Message));
                return false;
            }

        }

        public bool Move(string source, string destination, string name)
        {
            try
            {
                File.Copy(source, string.Concat(destination, "/", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString(), Path.GetExtension(name)));
                File.Delete(source);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //throw;
                return false;
            }
        }

        public int Status(Models.CFDI cdfi)
        {
            // falta implementacion del campo en la tabla CFDI_RECORDS
            // falta ver si funciona el servicio de estatus de cfdi consumido directamente en el servicio web del sat
            throw new NotImplementedException();
        }

        public List<string> GetFiles(string path, List<string> ext)
        {
            //var ext = new List<string> { "jpg", "gif", "png" };
            //DirectoryInfo directory = new DirectoryInfo();
            //var test = directory.GetFiles(,SearchOption.AllDirectories).Where( k => k.)
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(s => ext.Contains(Path.GetExtension(s))).ToList();
        }

        public List<CFDI_RECORDS> ListDTO()
        {
            _cfdi_records = new CFDI_RECORDS();
            return _cfdi_records.List();
        }

        public List<Models.CFDI> List()
        {
            List<Models.CFDI> listRes = new List<Models.CFDI>();
            _cfdi_people = new CFDI_PEOPLE();
            List<CFDI_PEOPLE> listPeople = _cfdi_people.List();
            List<CFDI_RECORDS> list = this.ListDTO();

            foreach (var item in list)
            {
                Models.CFDI obj = new Models.CFDI();
                obj.id = item.Id;
                _cfdi_people = new CFDI_PEOPLE();
                _cfdi_people.Id = item.Id_Emisor;
                _cfdi_people = listPeople.SingleOrDefault(x => x.Id == _cfdi_people.Id);
                obj.emisor = new Emisor();
                obj.emisor.id = _cfdi_people.Id;
                obj.emisor.nombre = _cfdi_people.Nombre;
                obj.emisor.rfc = _cfdi_people.RFC;

                //obj.emisor.domicilio = new Domicilio();
                //obj.emisor.domicilio.calle = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().calle;
                //obj.emisor.domicilio.codigoPostal = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().codigoPostal;
                //obj.emisor.domicilio.colonia = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().colonia;
                //obj.emisor.domicilio.estado = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().estado;
                //obj.emisor.domicilio.municipio = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().municipio;
                //obj.emisor.domicilio.noExterior = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().noExterior;
                //obj.emisor.domicilio.pais = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().pais;



                _cfdi_people = new CFDI_PEOPLE();
                _cfdi_people.Id = item.Id_Receptor;
                //_cfdi_people = _cfdi_people.Get();
                _cfdi_people = listPeople.SingleOrDefault(x => x.Id == _cfdi_people.Id);
                obj.receptor = new Receptor();
                obj.receptor.id = _cfdi_people.Id;
                obj.receptor.nombre = _cfdi_people.Nombre;
                obj.receptor.rfc = _cfdi_people.RFC;

                //obj.receptor.domicilio = new Domicilio();
                //obj.receptor.domicilio.calle =  string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().calle) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().calle;
                //obj.receptor.domicilio.codigoPostal = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().codigoPostal) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().codigoPostal;
                //obj.receptor.domicilio.colonia = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().colonia) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().colonia;
                //obj.receptor.domicilio.estado = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().estado) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().estado;
                //obj.receptor.domicilio.municipio = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().municipio) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().municipio;
                //obj.receptor.domicilio.noExterior = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().noExterior) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().noExterior;
                //obj.receptor.domicilio.pais = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().pais) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().pais;
                obj.receptor.domicilio = new Domicilio();
                //obj.receptor.domicilio.calle = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().calle;
                //obj.receptor.domicilio.codigoPostal = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().codigoPostal;
                //obj.receptor.domicilio.colonia = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().colonia;
                //obj.receptor.domicilio.estado = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().estado;
                //obj.receptor.domicilio.municipio = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().municipio;
                //obj.receptor.domicilio.noExterior = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().noExterior;
                //obj.receptor.domicilio.pais = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().pais;
                // Generic 
                obj.fecha = item.fecha.ToString();
                obj.folio = item.folio;
                obj.formaDePago = item.formaDePago;
                obj.metodoDePago = item.metodoDePago;
                obj.Moneda = item.Moneda;
                obj.serie = item.serie;
                obj.TipoCambio = item.TipoCambio.ToString();
                obj.UUID = item.UUID;
                obj.subTotal = item.subtotal.ToString();
                obj.tipoDeComprobante = item.tipoDeComprobante;
                obj.total = item.total.ToString();
                obj.version = item.version;

                listRes.Add(obj);
            }

            return listRes;
        }

        public async Task<Models.CFDI> Get(int id)
        {

            _cfdi_records = new CFDI_RECORDS();
            _cfdi_records.Id = id;
            var item = await _cfdi_records.Get();
            // start
            _cfdi_people = new CFDI_PEOPLE();
            var people = _cfdi_people.Get();
            Models.CFDI obj = new Models.CFDI();
            _cfdi_people = new CFDI_PEOPLE();
            _cfdi_people.Id = item.Id_Emisor;
            _cfdi_people = _cfdi_people.Get();
            obj.emisor = new Emisor();
            obj.emisor.id = _cfdi_people.Id;
            obj.emisor.nombre = _cfdi_people.Nombre;
            obj.emisor.rfc = _cfdi_people.RFC;

            obj.emisor.domicilio = new Domicilio();
            //obj.emisor.domicilio.calle = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().calle;
            //obj.emisor.domicilio.codigoPostal = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().codigoPostal;
            //obj.emisor.domicilio.colonia = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().colonia;
            //obj.emisor.domicilio.estado = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().estado;
            //obj.emisor.domicilio.municipio = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().municipio;
            //obj.emisor.domicilio.noExterior = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().noExterior;
            //obj.emisor.domicilio.pais = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().pais;



            _cfdi_people = new CFDI_PEOPLE();
            _cfdi_people.Id = item.Id_Receptor;
            _cfdi_people = _cfdi_people.Get();
            obj.receptor = new Receptor();
            obj.receptor.id = _cfdi_people.Id;
            obj.receptor.nombre = _cfdi_people.Nombre;
            obj.receptor.rfc = _cfdi_people.RFC;

            //obj.receptor.domicilio = new Domicilio();
            //obj.receptor.domicilio.calle =  string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().calle) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().calle;
            //obj.receptor.domicilio.codigoPostal = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().codigoPostal) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().codigoPostal;
            //obj.receptor.domicilio.colonia = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().colonia) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().colonia;
            //obj.receptor.domicilio.estado = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().estado) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().estado;
            //obj.receptor.domicilio.municipio = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().municipio) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().municipio;
            //obj.receptor.domicilio.noExterior = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().noExterior) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().noExterior;
            //obj.receptor.domicilio.pais = string.IsNullOrEmpty(_cfdi_people.CFDI_ADDRESS.FirstOrDefault().pais) ? string.Empty : _cfdi_people.CFDI_ADDRESS.FirstOrDefault().pais;
            obj.receptor.domicilio = new Domicilio();
            //obj.receptor.domicilio.calle = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().calle;
            //obj.receptor.domicilio.codigoPostal = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().codigoPostal;
            //obj.receptor.domicilio.colonia = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().colonia;
            //obj.receptor.domicilio.estado = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().estado;
            //obj.receptor.domicilio.municipio = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().municipio;
            //obj.receptor.domicilio.noExterior = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().noExterior;
            //obj.receptor.domicilio.pais = _cfdi_people.CFDI_ADDRESS.FirstOrDefault().pais;
            //// Generic 
            obj.fecha = item.fecha.ToString();
            obj.folio = item.folio;
            obj.formaDePago = item.formaDePago;
            obj.metodoDePago = item.metodoDePago;
            obj.Moneda = item.Moneda;
            obj.serie = item.serie;
            obj.TipoCambio = item.TipoCambio.ToString();
            obj.UUID = item.UUID;
            obj.subTotal = item.subtotal.ToString();
            obj.tipoDeComprobante = item.tipoDeComprobante;
            obj.total = item.total.ToString();
            obj.version = item.version;
            // end 
            return obj;
        }


    }
}
