using System;

namespace laba10
{
    class Program
    {       
 
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            #region 1 задание

            #region Последовательность строк с длиной строки равной n
            int n = 4;
            Console.WriteLine($"---\tЗадание 1\t---\n\n");
            Console.WriteLine($"---\tПоследовательность строк с длиной строки равной {n}\t---");
            string[] array = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            IEnumerable<string> findedStringsByLength = array.Where<string>(i => (i.Length == n));

            Train.foreacher(findedStringsByLength);
            #endregion



            #region только летние и зимние месяцы

            Console.WriteLine("---\tЗимние месяцы\t---");
            IEnumerable<string> findedStringsByWinter = array.Where<string>(i => (i == "January" || i == "February" || i == "December"));
            Train.foreacher(findedStringsByWinter);

            Console.WriteLine("---\tЛетние месяцы\t---");
            IEnumerable<string> findedStringsBySummer = array.Where<string>(i => (i == "June" || i == "July" || i == "August"));
            Train.foreacher(findedStringsBySummer);

            #endregion



            #region запрос вывода месяцев в алфавитном порядке
            Console.WriteLine("---\tМесяцы в алфавитном порядке\t---");
            IEnumerable<string> outputMonthesByAlphabet = array.OrderBy(i => i);
            Train.foreacher(outputMonthesByAlphabet);
            #endregion



            #region запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х
            Console.WriteLine("---\tСодержится буква «u» и длиной имени >=4\t---");
            IEnumerable<string> countMonthesWithU = array.Where(i => (i.Contains("u") && (i.Length >= 4)));
            Train.foreacher(countMonthesWithU);
            #endregion



            #endregion



            #region 2 задание
            Console.WriteLine($"---\tЗадание 2\t---\n\n");
            Train[] trainArray = new Train[10];
            for (int i = 0; i < 10; i++)
            {
                trainArray[i] = new Train(DateTime.Now, "Дзержинск", i);
            }

            List<Train> trains = new List<Train>();
            trains.AddRange(trainArray);
            #endregion



            #region 3 задание
            Console.WriteLine($"---\tЗадание 3\t---\n\n");
            //вариант 11
            /*Вывести:
                список поездов, следующих до заданного пункта назначения;
                список поездов, следующих до заданного пункта назначения и
                отправляющихся после заданного часа;
                максимальный поезд по количеству мест
                последние пять поездов по времени отправления
                упорядоченный список поездов по пункту назначения в
                алфавитном порядке
            */
            string stopPointCheck = "Дзержинск";
            DateTime timeCheck = DateTime.Now;
            int placesCheck = 10;

            Console.WriteLine($"Поезда останавливающиеся в [{stopPointCheck}]: ");
            IEnumerable<Train> stopPointChecked = trains.Where<Train>(i => (i.stopPoint == stopPointCheck));
            Train.foreacher(stopPointChecked);

            Console.WriteLine($"Поезда, останавливающиеся в [{stopPointCheck}] и отправляющиеся в [{timeCheck}]: ");
            IEnumerable<Train> stopPointAndTimeChecked = trains.Where<Train>(i => (i.stopPoint == stopPointCheck && i.startTime == timeCheck));
            Train.foreacher(stopPointAndTimeChecked);

            Console.WriteLine("Максимальное число мест у поезда: ");
            int trainsByPlacesChecked = trains.Max(i => i.places[0] + i.places[1] + i.places[2] + i.places[3]);
            Console.WriteLine(trainsByPlacesChecked);

            Console.WriteLine($"Последние пять поездов по времени отправки в [{timeCheck}]: ");
            IEnumerable<Train> lastFiveTrainsByStartTime = from i in trains where i.startTime == timeCheck orderby i select i;
            lastFiveTrainsByStartTime = lastFiveTrainsByStartTime.TakeLast(5);
            Train.foreacher(lastFiveTrainsByStartTime);

            Console.WriteLine("Упорядоченный список поездов по пункту назначения в алфавитном порядке: ");
            IEnumerable<Train> alphabetOrderTrains = from i in trains 
                                                            orderby i.stopPoint 
                                                            select i;
            Train.foreacher(alphabetOrderTrains);

            #endregion



            #region 4 задание
            Console.WriteLine($"---\tЗадание 4\t---\n\n");
            /*            Придумайте и напишите свой собственный запрос, в котором было 
                        бы не менее 5 операторов из разных категорий: условия, проекций, 
                        упорядочивания, группировки, агрегирования, кванторов и разбиения*/
            IEnumerable<IGrouping<string, Train>> sobstvenniyZapros = from i in trains where i.trainNumber >= 5 orderby i.startTime group i by i.stopPoint;
            int number = sobstvenniyZapros.Count();
            bool kvantorov = trains.All(i => i.trainNumber >= 0);
            IEnumerable<Train> razbieniya = trains.Skip(5);
            //► Пропускает указанное количество элементов из входной последовательности, начиная с ее начала, и выводит остальные
            #endregion



            #region 5 задание
            Console.WriteLine($"---\tЗадание 5\t---\n\n");

            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
            };

            Company[] companies =
            {
                new Company("Microsoft", "C#"),
                new Company("Google", "Go"),
                new Company("Oracle", "Java")
            };


            var joins = from p in people join c in companies on p.company equals c.name select new { name = p.name, company = c.name, language = c.language };
            foreach (var item in joins)
            {
                Console.WriteLine($"{item.name} работает в {item.company} с языком программирования {item.language}");
            }
            #endregion

        }
    }
}
