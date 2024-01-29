using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hilos
            Thread proceso1 = new Thread(Proceso1);
            Thread proceso2 = new Thread(Proceso2);

          

            Console.WriteLine("Proceso principal");
            proceso1.Start();
            proceso2.Start();

        }
        //Proceso para contar numeros del 0 al 10000
        public static void Proceso1()
        {
            int i = 0;
            while (i < 10000) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Estoy en el proceso 1 " + i.ToString());
                i++;
            }
           
        }
        public static void Proceso2()
        {
            int i = 0;
            while (i < 10000)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Estoy en el proceso 2 " + i.ToString());
                i++;
            }
        }
    }
    
      
}