using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;


namespace laba14
{
    class Program
    {
        // для 4 задания
        static EventWaitHandle evenReady;   // предствялет поток синхронизированного события
        static EventWaitHandle oddReady;

        // для 4 задания
        private static object locker = new object();


        static void Main()
        {
            // 1. Определите и выведите на консоль все запущенные процессы:id, имя, приоритет, 
            // время запуска, текущее состояние, сколько всего времени использовал процессор и т.д


            // для 5 задания
            TimerCallback tm = new TimerCallback(MethodForTimer);  // устанавливаем метод обратного вызова
            Timer timer = new Timer(tm, null, 0, 7000); // объект TimerCallback
                                                        // объект, передаваемый в качестве параметра в метод Count
                                                        // количество миллисекунд, через которое таймер будет запускаться. В данном случае таймер будет запускать немедленно после создания, так как в качестве значения используется 0
                                                        // интервал между вызовами метода Count

            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    Console.WriteLine(
                    $"ID: {process.Id}\n" +
                    $"Имя: {process.ProcessName}\n" +
                    $"Приоритет: {process.PriorityClass}\n" +
                    $"Время запуска: {process.StartTime}\n" +
                    $"Текущее состояние(объем памяти, который выделен для данного процесса): {process.VirtualMemorySize64}\n" +
                    $"Отвечает ли пользовательский интерфейс: {process.Responding}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Имя: {process.ProcessName} {ex.Message}");
                }
            }


            // 2. Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки,
            //    загруженные в домен.Создайте новый домен.Загрузите туда сборку.Выгрузите домен.


            Console.WriteLine("----------== 2 задание ==-----------");
            AppDomain domain = AppDomain.CurrentDomain; // возвращает текущий домен приложения для текущего объекта Thread, AppDomain - домен приложения, ктр является изолированной средой, в которой приложение

            Console.WriteLine(
                $"Имя домена приложения: {domain.FriendlyName}\n" +
                $"Конфигурация домена приложения: {domain.SetupInformation}\n" +
                $"Базовый каталог, который используется для получения сборок: {domain.BaseDirectory}\n");

            Console.WriteLine("Все сборки, загруженные в домен: ");
            Assembly[] assembly = domain.GetAssemblies(); // получаем все сборки 

            foreach (Assembly asm in assembly)
                Console.WriteLine(
                    $"Имя сборки -- {asm.GetName().Name}\n" + 
                    $"Версия сборки -- {asm.GetName().Version}"
                    );

            // создаем новый домен
            CreateNewDomain();

            // 3. Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для 
            //    задержки) и записи в файл и на консоль простых чисел от 1 до n(задает пользователь). 
            //    Вызовите методы управления потоком(запуск, приостановка, возобновление и т.д.) Во
            //    время выполнения выведите информацию о статусе потока, имени, приоритете, числовой
            //    идентификатор и т.д.


            Console.WriteLine("Введите число n:");
            int number1 = int.Parse(Console.ReadLine());

            Thread myThread = new Thread(new ParameterizedThreadStart(SimpleNumbers)); //при запуске метода передает ему данные в виде объекта
            myThread.Name = "SimpleNumbersThread";
            myThread.Start(number1);    // запуск потока




            // 4. Создайте два потока. Первый выводит четные числа, второй нечетные до n и 
            //    записывают их в общий файл и на консоль. Скорость расчета чисел у потоков – разная.
            //      a.Поменяйте приоритет одного из потоков.
            //      b. Используя средства синхронизации организуйте работу потоков, таким образом, чтобы
            //        i.выводились сначала четные, потом нечетные числа
            //        ii.последовательно выводились одно четное, другое нечетное.


            Console.WriteLine("Введите n:");
            int number2 = int.Parse(Console.ReadLine());

            // создаем поток для четных чисел
            Thread myThread1 = new Thread(new ParameterizedThreadStart(EvenAndOdd));//при запуске метода передает ему данные в виде объекта
            myThread1.Name = "EvenNumbersThread";
            myThread1.Priority = ThreadPriority.Normal;
            Console.WriteLine($"Поток: {myThread1.Name}   Приоритет: {myThread1.Priority}");
            myThread1.Start(number2);

            // создаем поток для нечетных чисел
            Thread myThread2 = new Thread(new ParameterizedThreadStart(EvenAndOdd));//при запуске метода передает ему данные в виде объекта
            myThread2.Name = "OddNumbersThread";
            myThread2.Priority = ThreadPriority.BelowNormal;                                    //изменили приоритет одного из потоков
            Console.WriteLine($"Поток: {myThread2.Name}   Приоритет: {myThread2.Priority}");
            myThread2.Start(number2);


            // 4-2

            bool countOdd = true; // показывает начинаем работу или нет
            bool countEven = true;

            if (countOdd && countEven)
            {
                evenReady = new AutoResetEvent(false); // объект-событие - позволяет при получении сигнала переключить данный объект-событие из сигнального в несигнальное состояние. false обозначает что объект сразу находится в несигнальном состоянии
                oddReady = new AutoResetEvent(true); // Must be true for the starting thread.
            }
            else
            {
                evenReady = new ManualResetEvent(true);//Представляет событие синхронизации потока, которое при получении сигнала необходимо сбросить вручную
                oddReady = new ManualResetEvent(true);
            }

            Thread countThreadOdd = new Thread(oddThread);
            Thread countThreadEven = new Thread(evenThread);

            //Thread Start
            if (countOdd)
                countThreadOdd.Start(number2);

            if (countEven)
                countThreadEven.Start(number2);

            //main thread will untill below thread is in exection mode

            if (countOdd)
                countThreadOdd.Join();

            if (countEven)
                countThreadEven.Join();

            Console.WriteLine("Done");

        }





        // 2
        static void CreateNewDomain()
        {
            //AppDomain newDomain = AppDomain.CreateDomain("MyNewAppDomain");
            //InfoDomainApp(newDomain);
            //newDomain.Load("lab14");
            //AppDomain.Unload(newDomain);
        }

        static void InfoDomainApp(AppDomain defaultD)
        {
            Console.WriteLine("<--- Информация о новом домене приложения --->\n");
            Console.WriteLine(
                $"Имя: {defaultD.FriendlyName}\n" +
                $"ID: {defaultD.Id}\n" +
                $"По умолчанию? {defaultD.IsDefaultAppDomain()}\n" +
                $"Путь: {defaultD.BaseDirectory}\n"
                );

            Console.WriteLine("Загружаемые сборки: \n");                                       // Извлекаем информацию о загружаемых сборках с помощью LINQ-запроса
            var infAsm = from asm in defaultD.GetAssemblies()
                         orderby asm.GetName().Name
                         select asm;
            foreach (var a in infAsm)
                Console.WriteLine(
                    $"-> Имя: \t{a.GetName().Name}\n" +
                    $"-> Версия: \t{a.GetName().Version}"
                    );
        }



        // 3
        public static void SimpleNumbers(object num)
        {
            string Path = @"D:\Study\ООПиП(Экзамен)\laba14.3\лаба 14\lab14\lab14\bin\Debug\net6.0\SimpleNumbers.txt";
            Thread t = Thread.CurrentThread;    // сейчас запущенный поток
            for (int i = 2; i <= (int)num; i++)
            {
                bool b = true;
                for (int j = 2; j < i; j++)     // получение простых чисел
                {
                    if (i % j == 0 & i % 1 == 0)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    Console.WriteLine(i);
                    using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(i);
                    }
                    Thread.Sleep(400);  // приостановка
                }
                if (i == (int)num)  // вывод информации о потоке
                {
                    Console.WriteLine($"Имя потока: {t.Name}");
                    Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
                    Console.WriteLine($"Приоритет потока: {t.Priority}");
                    Console.WriteLine($"Статус потока: {t.ThreadState}");
                }
            }
        }



        // 4-1
        public static void EvenAndOdd(object num)
        {
            string Path = @"D:\Study\ООПиП(Экзамен)\laba14.3\лаба 14\lab14\lab14\bin\Debug\net6.0\EvenAndOddNumbers.txt";
            Thread t = Thread.CurrentThread;
            lock (locker)
            {
                for (int i = 0; i < (int)num; i++)
                {
                    if (t.Name == "EvenNumbersThread")
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine(i);
                            using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(i);
                            }
                        }
                        Thread.Sleep(300);
                    }

                    if (t.Name == "OddNumbersThread")
                    {
                        if (i % 2 != 0)
                        {
                            Console.WriteLine(i);
                            using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(i);
                            }
                        }
                        Thread.Sleep(400);
                    }
                }
            }
        }


        // 4-2

        public static void oddThread(object num)
        {
            string Path = @"D:\Study\ООПиП(Экзамен)\laba14.3\лаба 14\lab14\lab14\bin\Debug\net6.0\EvenAndOddNumbers.txt";

            for (int i = 1; i < (int)num; i += 2)
            {
                evenReady.WaitOne();    // блокируем текущий поток (evenReady), пока текущий WaitHandle получает сигнал (потому что состояние события находится в несигнальном состоянии)
                Console.WriteLine(i);
                using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(i);
                }
                oddReady.Set();     // позволяет продолжиться одному или нескольким ожидаемым потокам (сигнализируем что oddReady в сигнальном состоянии)
            }
        }

        public static void evenThread(object num)
        {
            string Path = @"D:\Study\ООПиП(Экзамен)\laba14.3\лаба 14\lab14\lab14\bin\Debug\net6.0\EvenAndOddNumbers.txt";

            for (int i = 0; i < (int)num; i += 2)
            {
                oddReady.WaitOne();
                Console.WriteLine(i);
                using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(i);
                }
                evenReady.Set();
            }
        }


        // 5
        static void MethodForTimer(object param)
        {
            Console.WriteLine("This is a loop function");
        }
    }
}
