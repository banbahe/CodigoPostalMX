using System;
using System.Collections.Generic;
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
            FileController fileController = new FileController();
            Task<List< CodigoPostal>> taskt = fileController.Read();
            Console.WriteLine("0 quiuboles");
            Console.WriteLine("1 quiuboles");
            Console.WriteLine("2 quiuboles");
            Console.WriteLine("3 quiuboles");
            taskt.Wait();

            var x = taskt.Result;

            Task<bool> taskB = fileController.Create(x);
            Console.WriteLine("4 quiuboles");
            Console.WriteLine("5 quiuboles");
            Console.WriteLine("6 quiuboles");
            Console.WriteLine("7 quiuboles");
            taskB.Wait();

            var y = taskB.Result;
            Console.WriteLine();
            Console.ReadLine();



        }
        // TODO
        // READ FILE
    }
}
