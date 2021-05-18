using System;
using System.IO;
using System.Text.Json;
class Methods
{   Config sets = new Config();
    public static Config Input()
    {   // ввод ручной параметров вычисления в консоли
        int number;
        Console.Write("Введите   начальное число диапазона: ");
        bool result = int.TryParse(Console.ReadLine(), out number);
        int _StartNumber = result ? number : 0;
        Console.Write("Введите    конечное число диапазона: ");
        result = int.TryParse(Console.ReadLine(), out number);
        int _EndNumber = result ? number : 0;
        Console.Write("Будем сумировать четные числа(Y/N)?: ");
        bool _IsEven = (Console.ReadLine().ToUpper() == "Y") ? true : false;
        Config entered = new Config{StartNumber = _StartNumber, EndNumber = _EndNumber, IsEven = _IsEven};
        return entered;
    }
    public static long Calc(int a, int b, bool isEven)
    {   // вычисление сумы чётных или не четных чисел в диапазоне
        long result = 0;
        if ( a > b)
            return result;
        for (int i = a; i < b + 1; i++)
        {
            if (isEven && (i % 2 == 0))
                result += i;
            if (!isEven && (i % 2 == 1))
                result += i;
        }
        return result;
    }
    public static void SaveJson(Config save)
    {   // сохранение данных в json файл
        using (FileStream fs = new FileStream("config.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.SerializeAsync<Config>(fs, save);
            Console.WriteLine("* Данные сохранены в config.json\n==========");
        }
    }
    public static Config ReadJson()
    {   // чтение параметров из json файл
        string readText = File.ReadAllText("config.json");
        Config restored = JsonSerializer.Deserialize<Config>(readText);
        return restored;
    }
    public static bool AskSource()
    {   // метод выбора источника данных
        Console.Write("Берем данные из json(2) или вводим новые значения(1)?: ");
        if (Console.ReadLine() == "2")
            return true;
        else return false;
    }
}