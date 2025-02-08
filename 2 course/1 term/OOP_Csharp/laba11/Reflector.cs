using laba9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Text.Json;
using System.Configuration;
using System.IO;

namespace laba11
{
    class Person
    {
        public void Output(string str)
        {
            Console.WriteLine(str);
        }
    }
    class Configuration
    {
        public string funcname { get; set; }
        public string className { get; set; }
        public string param { get; set; }
    }
    public static class Reflector
    {
        private static StreamWriter? fileForInformation = null;
        private static StreamReader? fileForInvoke = null;


        //1

        #region a - определение имени сборки, в которой определён класс

        public static string GetAssemblyName(Type CurrentClass)
        {
            return CurrentClass.Assembly.ToString();
        }

        #endregion



        #region b - есть публичные конструкторы

        public static bool HasPublicConstructors(Type CurrentClass)
        {
            foreach (var item in CurrentClass.GetConstructors(System.Reflection.BindingFlags.Public))
            {
                if (item.IsPublic)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion



        #region c - извлекает все общедоступные публичные методы класса
        // (возвращает IEnumerable<string>);

        public static IEnumerable<string> GetPublicMethodsOfClass(Type CurrentClass)
        {
            List<string> publicMethods = new List<string>();
            foreach (var item in CurrentClass.GetMethods(System.Reflection.BindingFlags.Public))
            {
                if (item.IsPublic)
                {
                    publicMethods.Add(item.ToString());
                }
            }

            return publicMethods;
        }

        #endregion



        #region d - получает информацию о полях и свойствах класса (возвращает IEnumerable<string>)

        public static IEnumerable<string> GetFieldsAndPropsOfClass(Type CurrentClass)
        {
            return new List<string> { CurrentClass.GetFields(System.Reflection.BindingFlags.Public).ToString(), CurrentClass.GetFields(System.Reflection.BindingFlags.NonPublic).ToString(), CurrentClass.GetFields(System.Reflection.BindingFlags.Instance).ToString(), CurrentClass.GetProperties(System.Reflection.BindingFlags.Public).ToString(), CurrentClass.GetProperties(System.Reflection.BindingFlags.NonPublic).ToString(), CurrentClass.GetProperties(System.Reflection.BindingFlags.Instance).ToString() };
        }

        #endregion



        #region e - получает все реализованные классом интерфейсы (возвращает IEnumerable<string>);

        public static IEnumerable<string> GetAllInterfacesOfClass(Type CurrentClass)
        {
            List<string> interfaces = new List<string>();
            foreach (var item in CurrentClass.GetInterfaces())
            {
                if (item.IsPublic)
                {
                    interfaces.Add(item.IsPublic.ToString());
                }
            }
            return interfaces;
        }

        #endregion



        #region f - выводит по имени класса имена методов, которые содержат заданный(пользователем) тип параметра(имя класса передается в качестве аргумента);

        public static IEnumerable<string> OutputDataByClassName(Type CurrentClass, string Parameter)
        {
            List<string> Methods = new List<string>();
            var currentClassMethods = CurrentClass.GetMethods();

            foreach (var item in currentClassMethods)
            {
                var itemParams = item.GetParameters();

                if (itemParams.Length == 0)
                {
                    if (Parameter == "")
                    {
                        Methods.Add(item.ToString());
                        continue;
                    }
                }

                if (itemParams.Any(param => (param.Name == Parameter)))
                {
                    Methods.Add(item.ToString());
                }
            }
            return Methods;
        }

        #endregion



        #region g - метод Invoke, который вызывает метод класса, при этом значения 
        //для его параметров необходимо 1) прочитать из текстового файла
        //(имя класса и имя метода передаются в качестве аргументов) 2) 
        //сгенерировать, используя генератор значений для каждого типа.
        //Параметрами метода Invoke должны быть : объект, имя метода, массив параметров


        public static void Invoke(string currentClassName, string currentMethodName)
        {
            Type? classType = Type.GetType(currentClassName, false, true);
            object? obj = Activator.CreateInstance(classType);
            var methodInfo = classType.GetMethod(currentMethodName);
            fileForInvoke = new StreamReader(fileForInvokePath);
            object? result = methodInfo.Invoke(obj, new object[] { int.Parse(fileForInvoke.ReadLine()), int.Parse(fileForInvoke.ReadLine()) });
            fileForInvoke.Close();


            //Configuration conf;
            //// открываем новый поток и в stream записываем путь к нашему файлу
            //// новый поток нужен для того, чтобы не нагружать основной 
            //using (var stream = new StreamReader(@"D:\Study\ООПиП(Экзамен)\laba11\InfoFile.json"))
            //{
            //    // в cont записываем инфу с нашего файла
            //    var content = stream.ReadToEnd();
            //    // Deserialize десериализует строку json в объект типа Configuration и возвращает его в conf
            //    conf = JsonSerializer.Deserialize<Configuration>(content);
            //    // теперь наша переменная conf содержит экземпляр типа Configuration со значениями, которые были записаны в файле:
            //    // funcname: Show
            //    // className: Display
            //    // param: "my str"
            //}
            //Display obj = new Display();
            //// получает доступ к методу Show типа Configuration и производит его Invoke
            //// Invoke - вызывает метод или конструктор, представленный текущим экземпляром, используя указанные параметры
            //// Здесь первый параметр представляет объект, для которого вызывается метод, а второй - набор параметров в виде массива object[].
            //Type.GetType($"laba11.{conf.className}").GetMethod(conf.funcname).Invoke(obj, new object[] { conf.param });

            //Configuration conf;
            //using (var stream = new StreamReader("InfoFile.json"))
            //{
            //    var cont = stream.ReadToEnd();
            //    conf = JsonSerializer.Deserialize<Configuration>(cont);
            //}
            //var obj = new Person();
            //Type.GetType($"laba11.{conf.className}").GetMethod(conf.funcname).Invoke(obj, new object[] { conf.param });
        }
        #endregion



        //---
        #region demo
        private static readonly string fileForInformationPath = @"D:\Study\ООПиП(Экзамен)\laba11\Reflection.txt";
        private static readonly string fileForInvokePath = @"D:\Study\ООПиП(Экзамен)\laba11\Invoke.txt";

        public static void NameWrite(string CurrentClassName)
        {
            string? AssemblyName = GetAssemblyName(Type.GetType(CurrentClassName, true, true));
            FileOpen();
            fileForInformation?.WriteLine($"Current class:\t{CurrentClassName}\nCurrent assembly name:\t{AssemblyName}");
            FileClose();
        }

        public static void ConstructorCheckWrite(string currentClassName)
        {
            bool? HasAnyPublicConstructors = HasPublicConstructors(Type.GetType(currentClassName, true, false));
            FileOpen();
            fileForInformation?.WriteLine($"Contains public constructors:\t{HasAnyPublicConstructors}");
            FileClose();
        }

        public static void PublicMethodsEnumerationWrite(string currentClassName)
        {
            IEnumerable<string> publicMethods = new List<string>(GetPublicMethodsOfClass(Type.GetType(currentClassName, true, false)));
            FileOpen();
            fileForInformation?.WriteLine($"Public methods:");
            foreach (var item in publicMethods)
            {
                fileForInformation?.WriteLine(item);
            }
            FileClose();
        }

        public static void FieldsAndPropsWrite(string currentClassName)
        {
            FileOpen();
            IEnumerable<string> FieldsAndPropsList = new List<string>(GetFieldsAndPropsOfClass(Type.GetType(currentClassName, true, false)));
            fileForInformation?.WriteLine($"Fields and Props:");
            foreach (var item in FieldsAndPropsList)
            {
                fileForInformation?.WriteLine(item);
            }
            FileClose();
        }

        public static void InterfacesOfClassWrite(string currentClassName)
        {
            FileOpen();
            IEnumerable<string> InterfacesList = new List<string>(GetAllInterfacesOfClass(Type.GetType(currentClassName, true, false)));
            fileForInformation?.WriteLine($"Interfaces:");
            foreach (var item in InterfacesList)
            {
                fileForInformation?.WriteLine(item);
            }
            FileClose();
        }

        public static void OutputDataByClassNameWrite(string currentClassName, string Parametr)
        {
            FileOpen();
            IEnumerable<string> DataList = new List<string>(OutputDataByClassName(Type.GetType(currentClassName, true, false), Parametr));
            fileForInformation?.WriteLine($"Methods with parametr {Parametr}:");
            foreach (var item in DataList)
            {
                fileForInformation?.WriteLine(item);
            }
            FileClose();
        }
        #region работа с файлами(разделение каждого входа функций для удобства)
        private static void FileOpen()
        {
            if (fileForInformationPath != null)
            {
                fileForInformation = new StreamWriter(fileForInformationPath, true);
            }
        }

        private static void FileClose()
        {
            fileForInformation?.WriteLine("\n=\t=\t=\t=========\t=\t=\t=\n");
            fileForInformation?.Close();
        }
        #endregion


        #endregion
        //---


        //2

        public static object Create(int width, int height)
        {
            Type type = typeof(GeometricFigure);

            ConstructorInfo info = type.GetConstructor(new Type[] { typeof(int), typeof(int) });
            object obj = info.Invoke(new object[] { width, height });
            return obj;
        }
    }
}
