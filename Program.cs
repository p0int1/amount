using System;
using System.Text.Json;

namespace amount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nВычисление суммы четных или нечетных чисел в заданном диапазоне.\n==========");
            bool Source = Methods.AskSource();
            Config sets = Source ? Methods.ReadJson() : Methods.Input();
            Console.WriteLine($"\nНачальное число {sets.StartNumber}, конечное {sets.EndNumber}");
            long Sum = Methods.Calc(sets.StartNumber, sets.EndNumber, sets.IsEven);
            Console.WriteLine($"\nСума чисел равна {Sum}");
            Methods.SaveJson(sets);
        }
    }
}
