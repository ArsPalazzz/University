using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab15
{
    class Program
    {
        static void SieveEratosthenes(int n, CancellationToken token)  // поиск простых чисел
        {
            var numbers = new List<int>();
            for (var i = 2; i < n; i++)                    //заполнение списка числами от 2 до n-1
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2; j < n; j++)
                {
                    numbers.Remove(numbers[i] * j);         //удаляем кратные числа из списка
                }
            }

            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Операция прервана токеном");
                return;
            }
            //Thread.Sleep(3000);
            Console.WriteLine(string.Join("\n", numbers));

            Console.WriteLine($"Выполняется задача {Task.CurrentId} в блоке с решетом Эратосфена");
            Thread.Sleep(3000);
            //static int x = 0;
        }

        static int Square(int s) => s * s;

        static void FourthTask(int square)
        {
            Console.WriteLine($"Плащадь квадрата: {square}");
        }

        static void Arr(int x)
        {
            int[] array = new int[100000];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(); // [0 - 2^31)
            Console.WriteLine($"Массив №{x} сформирован");
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]);
            //}
        }
        static void Display()
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId} в методе Display");
            Thread.Sleep(3000);
        }
        static BlockingCollection<string> product = new BlockingCollection<string>(50);
        static void producer(string x)
        {
            product.Add(x);
            Console.WriteLine($"Поставщик завёз товар - {x}");
            Thread.Sleep(300);
            product.CompleteAdding();
        }
        static void consumer(int y)
        {
            while (!product.IsCompleted)
            {
                if (product.TryTake(out string x))
                {
                    Console.WriteLine($"{y}-ый покупатель приобрёл {x}");
                }
                else
                {
                    Console.WriteLine($"{y}-ый покупатель ушёл");
                }
            }
            Thread.Sleep(300);
        }
        static void Main(string[] args)
        {

            // 1
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();              //для прерывания выполняемых задач
            CancellationToken token = cancelTokenSource.Token;

            Console.Write("Введите n: ");

            var timer = new Stopwatch();        // проверяем производительность                     // две строки можно записать одной var timer = Stopwatch.StartNew();
            timer.Start();

            var n = Convert.ToInt32(Console.ReadLine());
            Task Eratosfen = new Task(() => SieveEratosthenes(n, token));
            Console.WriteLine(
                $"-> Идентификатор текущей задачи: {Eratosfen.Id}\n" +
                $"-> Завершина ли задача? {Eratosfen.IsCompleted}\n" +
                $"-> Статус задачи: {Eratosfen.Status}\n");
            Eratosfen.Start();

            // 2
            Console.WriteLine("Введите Y для отмены операции или любой другой символ для ее продолжения:");
            string s = Console.ReadLine();
            if (s == "Y")
                cancelTokenSource.Cancel();

            timer.Stop(); // прекращаем проверку на производительность
            TimeSpan timeTaken = timer.Elapsed; // получаем общее затраченное время
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);

            // 3
            Console.WriteLine("Введите сторону 1-го квадрата: ");
            int s1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сторону 2-го квадрата: ");
            int s2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите сторону 3-го квадрата: ");
            int s3 = Convert.ToInt32(Console.ReadLine());

            Task<int> task1 = new Task<int>(() => Square(s1));
            task1.Start();
            Task<int> task2 = new Task<int>(() => Square(s2));
            task2.Start();
            Task<int> task3 = new Task<int>(() => Square(s3));
            task3.Start();

            // 4
            Task task4_1 = task1.ContinueWith(square => FourthTask(square.Result));
            Task task4_2 = task2.ContinueWith(square => FourthTask(square.Result));
            Task task4_3 = task3.ContinueWith(square => FourthTask(square.Result));
            task4_1.Wait();
            task4_2.Wait();
            task4_3.Wait();

            // 5
            Parallel.For(1, 3, Arr);

            ParallelLoopResult result = Parallel.ForEach<int>(new List<int>() { 1, 2 },
                Arr);

            // 6
            Parallel.Invoke(Display,
                () =>
                {
                    Console.WriteLine($"Выполняется задача {Task.CurrentId} в блоке Invoke");
                    Thread.Sleep(3000);
                },
                () => SieveEratosthenes(200, token));

            /*или можно так*/
            Parallel.Invoke(new Action[]
            {
                () => SieveEratosthenes(10,token),
                () => SieveEratosthenes(5,token)
            });

            // 7
            var shop = new BlockingCollection<Product>();


            BlockingCollection<string> bc = new BlockingCollection<string>(5);

            Task[] sellers = new Task[10]
            {
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Стол");
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Шкаф");
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Зеркало");
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Бра");
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Подоконник");
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Микроволновка");
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Кровать");
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Дверь");
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Вазон");
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Стул");
                    }
                })
            };

            Task[] consumers = new Task[5]
            {
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(300);
                        bc.Take();
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(500);
                        bc.Take();
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(500);
                        bc.Take();
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(400);
                        bc.Take();
                    }
                }),
                new Task(() => {
                    while (true)
                    {
                        Thread.Sleep(250);
                        bc.Take();
                    }
                })
            };

            foreach (var i in sellers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            foreach (var i in consumers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            int count = 1;
            int answer = 1;
            while (answer != 0)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("---Склад---");

                    foreach (var i in bc)
                        Console.WriteLine(i);
                    Console.WriteLine("Заполнить Склад? 1 - да, 0 - нет");
                    answer = Convert.ToInt32(Console.ReadLine());
                }
            }


            // 8
            // Асинхронность позволяет вынести отдельные задачи из основного потока в специальные асинхронные методы и при этом более
            // экономно использовать потоки. Асинхронные методы выполняются в отдельных потоках.

            void Factorial()
            {
                int result = 1;
                for (int i = 1; i <= 6; i++)
                    result *= i;
                Thread.Sleep(1000);
                Console.WriteLine($"6! = {result}");
            }

            async void FactorialAsync()
            {
                Console.WriteLine("Factorial start");
                await Task.Run(() => Factorial());
                Console.WriteLine("Factorial ends");
            }

            FactorialAsync();
            Console.ReadKey();

            //for (int i = 0; i < 4; i++)
            //{
            //    shop.Add(new Product(i, "Another one product"));
            //}
            //Task.Run(() =>
            //{
            //    while (!shop.IsCompleted)
            //    {
            //        Thread.Sleep(100);
            //        if (shop.TryTake(out Product prod)) // если получается взять товар из списка
            //        {
            //            Console.WriteLine(prod.Name);
            //        }
            //    }
            //});
            //}).Wait();
            Console.ReadLine();


            //BlockingCollection<int> blockcoll = new BlockingCollection<int>();
            //for (int producer = 0; producer < 5; producer++)
            //{
            //    Task.Factory.StartNew(() =>
            //    {
            //        x++;
            //        for (int ii = 0; ii < 3; ii++)
            //        {
            //            x++;
            //            Thread.Sleep(100);
            //            int id = x;
            //            blockcoll.Add(id);
            //            Console.WriteLine("Produser add " + id);
            //        }
            //    });
            //}
            //Task consumer = Task.Factory.StartNew(
            //() =>
            //{
            //    foreach (var item in blockcoll.GetConsumingEnumerable())
            //    {
            //        Console.WriteLine(" Reading " + item);
            //    }
            //});
            //consumer.Wait();

        }
    }
}
