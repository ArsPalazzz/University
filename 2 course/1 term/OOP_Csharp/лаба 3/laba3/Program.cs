using System;
using laba3;

class Program
{
    static void Main(string[] args)
    {
       
            Console.WriteLine("Введите размер списка:");               //задаём размерность списков
        int n = int.Parse(Console.ReadLine());

            int[] a = new int[n];                                           //создаём список А
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент списка А: ");
                a[i] = int.Parse(Console.ReadLine());
            }
            MyList spisA = new MyList(a);

            Console.WriteLine("");

            int[] b = new int[n];                                            //создаём список В
            Console.WriteLine($"Задайте список B для определения пересечения со списком А");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент списка А: ");
                b[i] = int.Parse(Console.ReadLine());
            }
            MyList spisB = new MyList(b);

            Console.WriteLine("");

            int check;
            Console.WriteLine("Введите элемент(число), которое хотите найти в списке А: "); // проверяем принадлежность элемента в списке А
            check = int.Parse(Console.ReadLine());
            if (spisA > check)
            {
                Console.WriteLine("Элемент принадлежит списку А :)");
            }
            else
            {
                Console.WriteLine("Элемент НЕ принадлежит списку А :(");
            }

            Console.WriteLine("");

            Console.WriteLine("Проверим, пересекаются ли списки А и В: ");                            // Проверка на пересечение списков А и B
            bool peresechenie;
            peresechenie = spisA * spisB;
            Console.WriteLine(peresechenie);

            Console.WriteLine("Проверим, является ли список {1,2} подмножеством А: ");                            // Проверка на пересечение списков А и B
            bool podsetRez;
            int[] podset = { 1, 2 };
            podsetRez = spisA + podset;
            Console.WriteLine(podsetRez);


            Production prod = new Production(03858396, "myProd");
            prod.getInfo();

            MyList.Developer dev = new MyList.Developer("ars", "pal", "vikt", 39583, "best");
            dev.getInf();

            Console.WriteLine("<-----Методы расширения. Задание №4----->");
            int sum = StatisticOperation.Summa(spisA);
            Console.WriteLine($"Сумма элементов списков равна: {sum}");

            int maxminDif = StatisticOperation.MaxMinDif(spisA);
            Console.WriteLine($"Разница между максимальным и минимальным элементами списков равна: {maxminDif}");

            int count = StatisticOperation.Counter(spisA);
            Console.WriteLine($"Подсчёт кол-ва элементов: {count}");

            Console.WriteLine("<-----Методы расширения. Задание №5----->");
            string str = "Строка, в которой где7-то должно быть число";
            char[] s = ("jdjd").FindNum();
            Console.WriteLine($"Выделение первого числа, содержащегося в строке: {new String(s)}");

            int[] c = new int[n];
            c = StatisticOperation.DelPlus(spisA);
            Console.WriteLine("Обнуление положительных элементов множества: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{c[i]} ");
            }

            Console.ReadKey();
        
    }
}
