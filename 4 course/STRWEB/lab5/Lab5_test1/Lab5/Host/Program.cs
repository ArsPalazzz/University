using lab5;
using System;
using System.ServiceModel;

// http://localhost:8733/Design_Time_Addresses/lab5/WCFSiplex/rest/Add?x=3&y=7
// http://localhost:8733/Design_Time_Addresses/lab5/WCFSiplex/rest/Concat?s=Hello&d=7
// http://localhost:8733/Design_Time_Addresses/lab5/WCFSiplex/rest/Sum
//{
//    "a1": { "S": "Test", "K": 5, "F": 2.5 },
//    "a2": { "S": "Sum", "K": 10, "F": 3.5 }
//}

namespace Host
{
    internal class Program
    {
        static void Main()
        {
            // Создание экземпляра ServiceHost с указанием типа сервиса и базового адреса
            using (ServiceHost host = new ServiceHost(typeof(WCFSiplex)))
            {
                try
                {
                    // Открытие хоста
                    host.Open();
                    Console.WriteLine("Service has been started");
                    
                    // Ожидание ввода пользователя для завершения работы
                    Console.WriteLine("Press Enter to terminate the service.");
                    Console.ReadLine();

                    // Корректное закрытие хоста
                    host.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    host.Abort();
                }
            }
        }
    }
}