using System;
using System.Collections.Generic;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "Иван", "Пётр", "Василий" };

            Console.WriteLine(string.Join(", ", names));

            names.Insert(0, "Ольга");

            Console.WriteLine(string.Join(", ", names));

            names.Add("Виктория");

            Console.WriteLine(string.Join(", ", names));

            names.Sort();

            Console.WriteLine(string.Join(", ", names));


            names.Contains("Пётр");

            Console.WriteLine(names.Contains("Пётр"));

        }
    }
}
