using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Crear un array de números para sumar
        int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Calcular la suma utilizando programación paralela
        int sumaParalela = SumaParalela(numeros);

        Console.WriteLine($"La suma paralela es: {sumaParalela}");

        // Calcular la suma sin programación paralela (secuencial)
        int sumaSecuencial = SumaSecuencial(numeros);

        Console.WriteLine($"La suma secuencial es: {sumaSecuencial}");

        Console.ReadLine();
    }

    static int SumaParalela(int[] array)
    {
        int sumaTotal = 0;

        // Utilizar Parallel.ForEach para sumar en paralelo
        Parallel.ForEach(array, numero =>
        {
            // Asegurar la atomicidad de la operación de suma
            Interlocked.Add(ref sumaTotal, numero);
        });

        return sumaTotal;
    }

    static int SumaSecuencial(int[] array)
    {
        int sumaTotal = 0;

        // Sumar los elementos de manera secuencial
        foreach (var numero in array)
        {
            sumaTotal += numero;
        }

        return sumaTotal;
    }
}
