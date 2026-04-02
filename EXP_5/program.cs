using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Program Started...");

        await DoWorkAsync();

        Console.WriteLine("Program Finished...");
    }

    static async Task DoWorkAsync()
    {
        Console.WriteLine("Work Started...");
        await Task.Delay(3000);
        Console.WriteLine("Work Completed...");
    }
}