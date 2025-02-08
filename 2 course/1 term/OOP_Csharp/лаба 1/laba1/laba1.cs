using System;

namespace laba1
{ 
    class Program
    {
        enum Subjects
        {
            Databases,
            ComputerNetworks,
            ObjectOrientedDesignAndProgramming,
            ProbabilityTheoryAndMathematicalStatistics
        }

        public struct Point3D
        {
            public double X;
            public double Y;
            public double Z;
            public override string ToString()
            {
                return $"({X},{Y},{Z})";
            }
        };

        static void Main(string[] args)
        {
            Zadanie1(args);
            Zadanie2(args);
            Zadanie3(args);
            Zadanie4(args);
            Zadanie5(args);
            Zadanie6(args);
        }

        static void Zadanie1(string[] args)
        {
            Console.WriteLine("Задание 1(Типы)");
            Console.WriteLine("a)Определите переменные всех возможных примитивных типов С# и проинициализируйте их. Осуществите ввод и вывод их\n значений используя консоль\n");
            Console.Write("Введите значение типа byte(только неотрицательные): ");
            byte mybyte = Convert.ToByte(Console.ReadLine());
            Console.WriteLine($"Результат: {mybyte}");

            Console.Write("Введите значение типа sByte: ");
            sbyte mysbyte = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine($"Результат: {mysbyte}");

            Console.Write("Введите значение типа bool(true OR false): ");
            bool mybool = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine($"Результат: {mybool}");

            Console.Write("Введите значение типа short: "); //Целые числа
            short myshort = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"Результат: {myshort}");

            Console.Write("Введите значение типа ushort: ");
            ushort myushort = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine($"Результат: {myushort}");

            Console.Write("Введите значение типа int: ");
            int myint = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Результат: {myint}");

            Console.Write("Введите значение типа nint: ");
            nint mynint = 93;
            Console.WriteLine($"Результат: {mynint}");

            Console.Write("Введите значение типа uint: ");
            uint myuint = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine($"Результат: {myuint}");

            Console.Write("Введите значение типа nuint: ");
            nuint mynuint = 584;
            Console.WriteLine($"Результат: {mynuint}");

            Console.Write("Введите значение типа long: ");
            long mylong = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"Результат: {mylong}");

            Console.Write("Введите значение типа ulong: ");
            ulong myulong = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine($"Результат: {myulong}");

            Console.Write("Введите значение типа float: "); //Дробные числа
            float myfloat = Convert.ToSingle(Console.ReadLine()); //ToSingle - Преобразует заданное значение в число с 
            Console.WriteLine($"Результат: {myfloat}");           //плавающей запятой одиночной точности

            Console.Write("Введите значение типа double: ");
            double mydouble = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Результат: {mydouble}");

            Console.Write("Введите значение типа char: ");
            char mychar = Convert.ToChar(Console.ReadLine());
            Console.WriteLine($"Результат: {mychar}");

            Console.Write("Введите значение типа decimal: ");
            decimal mydecimal = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"Результат: {mydecimal}");

            Console.Write("Введите значение типа string: ");
            string mystring = Console.ReadLine();
            Console.WriteLine($"Результат: {mystring}");


            Console.WriteLine("\nb)Выполните 5 операций явного и 5 неявного приведения. Изучите возможности класса Convert\n");
            Console.WriteLine("Неявное преобразование");
            Console.Write("Введите данные, типа byte: ");

            byte explicitConversionByte = Convert.ToByte(Console.ReadLine());
            Console.WriteLine($"Тип byte: {explicitConversionByte}");
            short explicitConversionShort = explicitConversionByte;
            Console.WriteLine($"Тип short: {explicitConversionShort}");
            int explicitConversionInt = explicitConversionShort;
            Console.WriteLine($"Тип int: {explicitConversionInt}");
            long explicitConversionLong = explicitConversionInt;
            Console.WriteLine($"Тип long: {explicitConversionLong}");
            float explicitConversionFloat = explicitConversionLong;
            Console.WriteLine($"Тип float: {explicitConversionFloat}");
            double explicitConversionDouble = explicitConversionFloat;
            Console.WriteLine($"Тип double: {explicitConversionDouble}");

            Console.WriteLine("\nЯвное преобразование");
            Console.Write("Введите данные, типа double: ");

            double implicitConversionDouble = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Тип double: {implicitConversionDouble}");
            float implicitConversionFloat = (float)implicitConversionDouble;
            Console.WriteLine($"Тип float: {implicitConversionFloat}");
            long implicitConversionLong = (long)implicitConversionFloat;
            Console.WriteLine($"Тип long: {implicitConversionLong}");
            int implicitConversionInt = (int)implicitConversionLong;
            Console.WriteLine($"Тип int: {implicitConversionInt}");
            short implicitConversionShort = (short)implicitConversionInt;
            Console.WriteLine($"Тип short: {implicitConversionShort}");
            byte implicitConversionByte = (byte)implicitConversionShort;
            Console.WriteLine($"Тип byte: {implicitConversionByte}");

            Console.WriteLine("\nc)Выполните упаковку и распаковку значимых типов\n");
            Console.Write("Тип char: ");
            char boxCh = Convert.ToChar(Console.ReadLine());
            object myHeap = boxCh;
            char unboxCh = (char)myHeap;
            Console.WriteLine($"Результат: {unboxCh}");
            Console.Write("Тип int: ");
            int boxInt = Convert.ToInt32(Console.ReadLine());
            myHeap = boxInt;
            int unboxInt = (int)myHeap;
            Console.WriteLine($"Результат: {unboxInt}");
            Console.Write("Тип float: ");
            float boxFloat = Convert.ToSingle(Console.ReadLine());
            myHeap = boxFloat;
            float unboxFloat = (float)myHeap;
            Console.WriteLine($"Результат: {unboxFloat}");
            Console.Write($"{Subjects.Databases}(элемент перечисления): ");
            myHeap = Subjects.Databases;
            int unboxEnum = (int)myHeap;
            Console.WriteLine($"Результат: {unboxEnum}");

            Point3D Point;
            Point.X = 100;
            Point.Y = 100;
            Point.Z = 100;
            myHeap = Point;
            

            Console.WriteLine("\nd)Продемонстрируйте работу с неявно типизированной переменной\n");
            var amperage = 10;
            Console.WriteLine($"Значение силы тока: {amperage}");
            var resistance = 5;
            Console.WriteLine($"Значение сопротивления: {resistance}");
            var voltage = amperage * resistance;
            Console.WriteLine($"Напряжение - {amperage} * {resistance} = {voltage}");


            Console.WriteLine("\ne)Продемонстрируйте пример работы с Nullable переменной\n");
            int? x = 5;
            Console.WriteLine("int? x = 5;");
            //int z = x + 7;          // нельзя
            Console.WriteLine("int z = x + 7;          // нельзя");
            int? w = x + 7;         // можно
            Console.WriteLine("int? w = x + 7;         // можно");
            int d = x.Value + 7;    // можно
            Console.WriteLine("int d = x.Value + 7;    // можно");


            Console.WriteLine("\nf)Определите переменную типа var и присвойте ей любое значение.Затем следующей инструкцией \nприсвойте ей значение другого типа.Объясните причину ошибки\n");
            var changeType = 5;
            //changeType = "five";
            Console.WriteLine("var - это просто слово, благодаря которому компилятор понимает что тип нужно вычислить из значения справа.\nСамо вычисление происходит на этапе компиляции. Так что меняя тип ");
            Console.WriteLine("у неявно типизированной переменной мы пытаемся поменять тип обычной переменной");
        }

        static void Zadanie2(string[] args)
        {
            Console.WriteLine("Задание 2(Строки)\n");
            Console.WriteLine("a) Объявите строковые литералы. Сравните их");
            string strla = "la";
            string strba = "ba";
            Console.WriteLine($"strla - {strla}");
            Console.WriteLine($"strba - {strba}");
            Console.WriteLine($"str1 == str2? - {strla == strba}");
            int result = string.Compare(strba, strla);
            Console.Write($"Сравнение методом Compare - ");
            if (result < 0)
            {
                Console.WriteLine("Строка la стоит перед строкой ba");
            }
            else if (result > 0)
            {
                Console.WriteLine("Строка ba стоит перед строкой la");
            }
            else
            {
                Console.WriteLine("Строки идентичны");
            }
            Console.WriteLine("\nb) Создайте три строки на основе String. Выполните: сцепление, копирование, выделение подстроки, \nразделение строки на слова,вставки подстроки в заданную позицию, удаление заданнойподстроки\n");
            string str1 = "first";
            string str2 = "second";
            string str3 = "third";
            string str3copy = string.Copy(str3);
            string str3sub = str3.Substring(1, 2);
            Console.WriteLine($"\nСцепление {str1} и {str2} - {str1 + str2}");
            Console.WriteLine($"\nКопирование: str1 - {str1}\t str3 - {str3}");
            Console.WriteLine($"\nstring.Copy(str3) - {str3copy}");
            Console.WriteLine($"\nВыделение подстроки str3 с индекса 1 длинною 2 символа: {str3sub}\n");
            string allTheWords = "All the words";
            Console.WriteLine(allTheWords);
            Console.WriteLine("Разбиение на слова: ");
            string[] words = allTheWords.Split(' ');

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine($"\nВставка подстроки 'heh' в позицию с индексом 3: {allTheWords.Insert(3, "heh")}");
            Console.WriteLine($"\nУдаление подстроки длиною в 4 символа из позиции с индексом 4: {allTheWords.Remove(4, 4)}");

            Console.WriteLine("\nc) Создайте пустую и null строку. Продемонстрируйте использование метода string.IsNullOrEmpty");
            string emptyString = "";
            string nullString = null;
            string stringWithValue = "lalala";
            Console.WriteLine($"emptyString - ''\nnullString - null\nstringWithValue - {stringWithValue}\n");
            if (string.IsNullOrEmpty(emptyString))
            {
                Console.WriteLine($"emptyString is Null or empty");
            }
            else
            {
                Console.WriteLine($"emptyString is not Null or empty");
            }
            if (string.IsNullOrEmpty(nullString))
            {
                Console.WriteLine($"nullString is Null or empty");
            }
            else
            {
                Console.WriteLine($"nullString is not Null or empty");
            }
            if (string.IsNullOrEmpty(stringWithValue))
            {
                Console.WriteLine($"stringWithValue is Null or empty");
            }
            else
            {
                Console.WriteLine($"stringWithValue is not Null or empty");
            }

            Console.WriteLine("\nd) Создайте строку на основе StringBuilder. Удалите определенные \nпозиции и добавьте новые символы в начало и конец строки");

            System.Text.StringBuilder sb = new System.Text.StringBuilder("Macarena");
            Console.WriteLine($"sb - {sb}");
            sb = sb.Remove(1, 2);
            Console.WriteLine($"After removing(1,2): sb - {sb}");
            sb = sb.Insert(0, "start");
            Console.WriteLine($"After inserting(0,'start'): sb - {sb}");
            sb = sb.Append("end");
            Console.WriteLine($"After appending('end'): sb - {sb}");
        }

        static void Zadanie3(string[] args)
        {
            Console.WriteLine("3)Массивы\n");
            Console.WriteLine("a) Создайте целый двумерный массив и выведите его на консоль в отформатированном виде(матрица)");

            int[,] array1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int rows = array1.GetUpperBound(0) + 1;    // количество строк //GetUpperBound - возвращает верхнюю границу массива
            int columns = array1.Length / rows;        // количество столбцов
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array1[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nb) Создайте одномерный массив строк. Выведите на консоль его содержимое, длину массива.\nПоменяйте произвольный элемент(пользователь определяет позицию и значение)");

            string[] array2 = { "my", "name", "is", "Gustavo" };
            Console.WriteLine("array2:");

            foreach (string s in array2)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Length is {array2.Length}");

            Console.Write($"Index is ");
            int ind = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Your word is ");
            string yourWord = Console.ReadLine();
            array2[ind] = yourWord;
            Console.WriteLine("array2:");

            foreach (string s in array2)
            {
                Console.Write(s + " ");
            }

            Console.WriteLine("\nc) Создайте ступечатый (не выровненный) массив вещественных чисел с 3 - мя строками, в каждой из \nкоторых 2, 3 и 4 столбцов соответственно.Значения массива введите с консоли.");

            double[][] array3 = new double[3][];
            array3[0] = new double[2];
            array3[1] = new double[3];
            array3[2] = new double[4];

            for (int i = 0; i < array3.Length; i++)
            {
                for (int j = 0; j < array3[i].Length; j++)
                {
                    Console.Write("Enter the array elements: ");
                    array3[i][j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            Console.WriteLine("Array:");

            for (int i = 0; i < array3.Length; i++)
            {
                for (int j = 0; j < array3[i].Length; j++)
                {
                    Console.Write(array3[i][j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("d) Создайте неявно типизированные переменные для хранения массива и строки");
            var array4 = "varStr";
            Console.WriteLine($"String: {array4}");
            var array5 = new[] { "var", "Array" };
            Console.WriteLine("Array: ");
            foreach (var item in array5)
            {
                Console.Write(item + " ");
            }

        }

        static void Zadanie4(string[] args)
        {
            Console.WriteLine("\n\n4)Кортежи\n");
            Console.WriteLine("\na) Задайте кортеж из 5 элементов с типами int, string, char, string, ulong");
            Console.WriteLine(" (int, string, char, string, ulong) tuple1 = (5, 'str1', 'h', 'str2', 384);");
            (int, string, char, string, ulong) tuple1 = (5, "str1", 'h', "str2", 384);
            Console.WriteLine("\nb) Выведите кортеж на консоль целиком и выборочно ( например 1, 3, 4 элементы)");
            Console.WriteLine("Весь кортеж:");
            Console.Write(tuple1.Item1 + "\t");
            Console.Write(tuple1.Item2 + "\t");
            Console.Write(tuple1.Item3 + "\t");
            Console.Write(tuple1.Item4 + "\t");
            Console.Write(tuple1.Item5 + "\t");

            Console.WriteLine($"\nТолько 3 элемент: {tuple1.Item3}");

            Console.WriteLine("\nc) Выполните распаковку кортежа в переменные. Продемонстрируйте различные способы распаковки кортежа. \nПродемонстрируйте использование переменной(_). (доступно начиная с C#7.3)");

            var (one, two, three, four, five) = tuple1;

            var oneone = tuple1.Item1;
            var twotwo = tuple1.Item2;
            var threethree = tuple1.Item3;
            var fourfour = tuple1.Item4;
            var fivefive = tuple1.Item5;

            (int ii, string ss, char pp, string ss2, ulong ul) = tuple1;

            (int iii, _, char ppp, _, ulong ull) = tuple1;


            Console.WriteLine("d) Сравните два кортежа");
            var tuple2 = (14, "hah", 't', "sr", 5);
            var tuple3 = (34, "hah", 'f', "tr", 3);
            Console.WriteLine($"tuple2 == tuple3 - {tuple2 == tuple3}");
        }

        static void Zadanie5(string[] args)
        {
            Console.WriteLine("5) Создайте локальную функцию в main и вызовите ее. Формальные параметры функции – массив \nцелых и строка.Функция должна вернуть кортеж, содержащий:максимальный и минимальный элементы массива, \nсумму элементов массива и первую букву строки.");
            int[] myarrfor5 = { 4, 6, 3, 9, 2 };
            string mystrfor5 = "heh";
            var result = ForFifth(myarrfor5, mystrfor5);
            Console.Write("Исходный массив: ");
            foreach (int i in myarrfor5)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine($"\nСтрока: {mystrfor5}");
            Console.WriteLine($"Result: {result}");
        }

        static (int max, int min, int sum, char firstChar) ForFifth(int[] arr, string str)
        {
            int max = arr[0];
            int min = arr[0];
            int sum = 0;
            char firstChar = str[0];

            foreach (int i in arr)
            {
                if (i > max)
                {
                    max = i;
                }
                sum += i;
            }

            foreach (int i in arr)
            {
                if (i < min)
                {
                    min = i;
                }
            }

            var result = (max, min, sum, firstChar);
            return result;
        }

        static void Zadanie6(string[] args)
        {
            Console.WriteLine("6) Работа с checked/unchecked\n");

            Console.WriteLine("a) Определите две локальные функции");
            fun1();
            fun2();

            static void fun1()
            {
                checked
                {
                    int max = int.MaxValue;
                    Console.WriteLine($"В блоке checked при переполнении выдается ошибка - {max} + 1 - error");

                }
            }

            static void fun2()
            {
                unchecked
                {
                    int max = int.MaxValue;
                    Console.WriteLine($"В блоке unchecked при переполнении в верхней границе число становится \nминимальным - {max} + 1 = {max + 1} и наоборот");
                }
            }
        }

    }
}
