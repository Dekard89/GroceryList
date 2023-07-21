using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList
{
    public static class ConsoleHelper
    {
        public static void PrintLine(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static string InputAnswer (string str)
        {
            PrintLine(str, ConsoleColor.Green);
            var answer=Console.ReadLine();
            return answer;
        }
        public static void PrintMenu()
        {
            PrintLine("M a i n *** M e n u", ConsoleColor.Green);
            PrintLine("1 Импорировать оптимального списка покупок из файла",ConsoleColor.Green);
            PrintLine("2 Добавить новый пункт в оптимальный список",ConsoleColor.Green);
            PrintLine("3 Выбрать предстоящее событие",ConsoleColor.Green);
            PrintLine("4 Добавить в список покупок рекомендованные позиции",ConsoleColor.Green);
            PrintLine("5 Экспортировать список покупок в файл", ConsoleColor.Green);
            PrintLine("6 Этот день закончился", ConsoleColor.Green);
            PrintLine("0 Выход", ConsoleColor.Green);
        }
        
    }
}
