using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacionParalelo
{
    class Program
    {
        static async void Main(string[] args)
        {
            //Ejercicio 1: Numeros Primos
            var limit = 4_000_000;
            var numbers = Enumerable.Range(0, limit).ToList();

            //medir el tiempo calculo de los numeros primos sin parallel
            var watch = Stopwatch.StartNew();
            var NumeroPrimosForeach = ListaNumerosPrimos(numbers);
            watch.Stop();

            //medir el tiempo calculo de los numeros primos con parallel
            var watchForParallel = Stopwatch.StartNew();
            var numerosPrimosparalleForeach = ListaNumerosPrimosConParallel(numbers);
            watchForParallel.Stop();

            Console.WriteLine($"Bucle foreach clasico | Total numeros primos: {NumeroPrimosForeach.Count} | time taken : {watch.ElapsedMilliseconds} ms. ");
            Console.WriteLine($"Bucle Parallel.foreach| Total numeros primos: {numerosPrimosparalleForeach.Count} | time taken : {watchForParallel.ElapsedMilliseconds} ms. ");

           

        }
        private static IList<int> ListaNumerosPrimos(IList<int> numbers) => numbers.Where(EsPrimo).ToList();

        private static IList<int> ListaNumerosPrimosConParallel(IList<int> numbers)
        {
            //Representa una colección segura para subprocesos desordenada de objetos.
            var primeNumbers = new ConcurrentBag<int>();
            Parallel.ForEach(numbers, number =>
            {
                if (EsPrimo(number))
                {
                    primeNumbers.Add(number);
                }
            });

            return primeNumbers.ToList();
        }

        //Calculo de los numeros primos
        private static bool EsPrimo(int number)
        {
            //Si el numero menor entre dos no es primo
            if (number < 2)
                return false;

            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                //Si el numero es divisible es igual a 0 no es primo
                if (number % divisor == 0)
                    return false;
            }
            return true;
        }

       
    }


}


