﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Controllers;
using Models.EF;
namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Test to POSTMAN
            // FileController fileController = new FileController();
            // Task<List< CodigoPostal>> taskt = fileController.Read();
            // Console.WriteLine("0 quiuboles");
            // Console.WriteLine("1 quiuboles");
            // Console.WriteLine("2 quiuboles");
            // Console.WriteLine("3 quiuboles");
            // taskt.Wait();

            // var x = taskt.Result;

            // Task<bool> taskB = fileController.Create(x);
            // Console.WriteLine("4 quiuboles");
            // Console.WriteLine("5 quiuboles");
            // Console.WriteLine("6 quiuboles");
            // Console.WriteLine("7 quiuboles");
            // taskB.Wait();

            // var y = taskB.Result;
            // Console.WriteLine();
            // Console.ReadLine();
            // FileController fileController = new FileController();
            // Task<List<CodigoPostal>> list = fileController.Get();
            // list.Wait();
            // var resList = list.Result;

            //{
            //    //resList = resList.Take(1).ToList();
            //    Task task = fileController.GetLatLng(resList);
            //    Console.WriteLine("666 quiuboles");
            //    task.Wait();
            //    Console.WriteLine("GOD quiuboles");
            //    Console.ReadKey();
            //}
            Main2();
        }
        // TODO
        // READ FILE

        public static void Main2()
        {
            ICFDI _cfdi = new CFDIController();
            // Get all xml files
            List<Models.CFDI> listCFDI = new List<Models.CFDI>();
            _cfdi = new CFDIController();
            List<string> files = _cfdi.GetFiles(@"C:\Users\mefistofeles\Documents\emailmanagmentattachment\mail\dist", new List<string> { ".xml" });

            foreach (var item in files)
            {
                Models.CFDI cfdi = _cfdi.Read(item);
                if (cfdi != null)
                    listCFDI.Add(cfdi);
                //{

                //    if (!_cfdi.Exist(cfdi))
                //        _cfdi.AddAsync(cfdi).Wait();
                //    else
                //        _cfdi.Move(item, @"C:\Users\mefistofeles\Documents\GitHub\CodigoPostalMX\DataBase\exist", Path.GetFileName(item));
                //}
                Console.WriteLine("");
            }

            Console.ReadLine();
        }

        private static void UpdateZipCode()
        {
            //CFDI_ADDRESS cfdi_address = new CFDI_ADDRESS();
            //zipcodesmx zipcodesmx = new zipcodesmx();
            //var resAddress = cfdi_address.List();
            //var resZipCode = zipcodesmx.List();

            //Console.WriteLine("start");
            //foreach (var item in resAddress)
            //{
            //    //zipcodesmx.codigo = item.codigoPostal;
            //    foreach (var item2 in resZipCode)
            //    {
            //        if (item2.asentamiento.Contains(item.colonia))
            //        {
            //            Console.WriteLine(item2.asentamiento);
            //            Console.WriteLine(item.colonia);
            //            Console.WriteLine("*************************************");

            //        }
            //    }

            //}
        }
    }
}
