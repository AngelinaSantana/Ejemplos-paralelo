// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

var stopWatch = new Stopwatch();

//Lista de nombres
var nombres = new List<string>() { "Angelina", "Fernando", "Yudelka"};

Console.WriteLine("Ineficiente, uno por uno:");
//Comenzar a medir el tiempo
stopWatch.Start();

foreach (var nombre in nombres)
{
    await Metodo1(nombre);
    await Metodo2(nombre);
    await Metodo3(nombre);
   
}
stopWatch.Stop();
//Impresion para notar la inficiencia del metodo sin programacion concurrente
Console.WriteLine($"Duracion: {stopWatch.ElapsedMilliseconds} ms.", Console.ForegroundColor = ConsoleColor.Red);


stopWatch.Restart();

//Validamos la lista 
var validaciones = nombres.Select(nombre => RealizarValidaciones(nombre));
// espera y luego ejecuta la siguiente linea
await Task.WhenAll(validaciones);
//Impresion para notar la inficiencia del metodo con programacion concurrente
Console.WriteLine($"Duracion: {stopWatch.ElapsedMilliseconds} ms.", Console.ForegroundColor = ConsoleColor.Green);

async Task RealizarValidaciones(string nombre)
{
    await Metodo1(nombre);
    await Metodo2(nombre);
    await Metodo3(nombre);
}
async Task Metodo1(string nombre)
{
    await Task.Delay(5000);
    Console.WriteLine("Metodo 1: " + nombre);
}
async Task Metodo2(string nombr)
{
    await Task.Delay(5000);
    Console.WriteLine("Metodo 2: " + nombr);
}
async Task Metodo3(string nomb)
{
    await Task.Delay(5000);
    Console.WriteLine("Metodo 3: " + nomb);
}

