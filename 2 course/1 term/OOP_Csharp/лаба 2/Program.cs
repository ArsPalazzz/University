using System;


namespace laba2
{
    partial class Train
    {
        private readonly int id;   //уникальный номер каждого человека
        private string destination; //пункт назначения
        private short train_Number; //номер поезда
        private short departure_time_hours; //время отправления
        private short departure_time_minutes; //время отправления
        private short number_Of_Shared_Seats; //число общих мест
        private short number_Of_Seats_For_The_Compartment; //в купе
        private short number_Of_Seats_For_The_Reserved_Seat; //в плацкарте
        private short number_Of_Seats_For_The_Suite; //люкс
        public int ee;

        public int Id                                // get/set - методы для реализации инкапсуляции
        {
            get
            {
                if (id > 0) return id;
                else return 0;
            }                                       //ограничено по set
        }

        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public short Train_Number
        {
            get { return train_Number; }
            set { train_Number = value; }
        }

        public short Departure_time_hours
        {
            get { return departure_time_hours; }
            set { departure_time_hours = value; }
        }

        public short Departure_time_minutes
        {
            get { return departure_time_minutes; }
            set { departure_time_minutes = value; }
        }

        public short Number_Of_Shared_Seats { get; set; }                   //авоматическое свойство
        public short Number_Of_Seats_For_The_Compartment { get; set; }
        public short Number_Of_Seats_For_The_Reserved_Seat { get; set; }
        public short Number_Of_Seats_For_The_Suite { get; set; }

        //конструктор по умолчанию - конструктор, который не имеет параметов и не имеет тела, создаётся автоматически
        //средой разработки, если в классе не определено ни одного конструктора

        public Train()
        {

        }

        public Train(string destination, short train_Number, short departure_time_hours, short departure_time_minutes, short number_Of_Shared_Seats, 
            short number_Of_Seats_For_The_Compartment, short number_Of_Seats_For_The_Reserved_Seat, short number_Of_Seats_For_The_Suite)
        {
            this.destination = destination;              //с помощью this обращаемся к той переменной, которая является полем класса
            this.train_Number = train_Number;
            this.departure_time_hours = departure_time_hours;
            this.departure_time_minutes = departure_time_minutes;
            this.number_Of_Shared_Seats = number_Of_Shared_Seats;
            this.number_Of_Seats_For_The_Compartment = number_Of_Seats_For_The_Compartment;
            this.number_Of_Seats_For_The_Reserved_Seat = number_Of_Seats_For_The_Reserved_Seat;
            this.number_Of_Seats_For_The_Suite = number_Of_Seats_For_The_Suite;
            numberOfObj++;
        }

        public const int seats = 300;

        public int Seats
        {
            get { return seats; }
        }

        private Train(ref int seats) //закрытый констуктор
        {
             
            Console.WriteLine($"Стартовое количество мест: {seats}");
        }

        public static int numberOfObj;  //статическое поле, хранящее количество созданных объектов

        static void classInfo()          //статический метод вывода информации о классе
        {
            Console.WriteLine(numberOfObj);
        }

        static Train()                   //статический конструктор
        {
            Console.WriteLine("Cтатический конструктор");
            numberOfObj = 0;
        }

        public virtual void text()
        {
            Console.WriteLine("first method");
        }

        static string nameOfCompany = "Eurostar";
        public static string NameOfCompany
        {
            get { return nameOfCompany; }
            set { if (value != null) nameOfCompany = value; }
        }

    }

    partial class Train2 : Train
    {
        public override void text()
        {
            Console.WriteLine("second method");
        }
    }
    public class Program
    {
        static void ToDouble(ref int n, out int nx2)
        {
            nx2 = n * 2;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте количество поездов: ");
            int numberOfUsers = int.Parse(Console.ReadLine());

            Train[] DB = new Train[numberOfUsers];          //создаём массив классов с БД о пользователях

            Train.numberOfObj = 2;
            Console.WriteLine(Train.numberOfObj);

            for (int i = 0; i < numberOfUsers; i++)
            {
                DB[0] = new Train();
            DB[1] = new Train();

            Console.WriteLine("Введите пункт назначения: ");
            DB[i].Destination = Console.ReadLine();

            Console.WriteLine("Введите номер поезда: ");
            DB[i].Train_Number = short.Parse(Console.ReadLine());

            Console.WriteLine("Введите время отправления (часы): ");
            DB[i].Departure_time_hours = short.Parse(Console.ReadLine());

            Console.WriteLine("Введите время отправления (минуты): ");
            DB[i].Departure_time_minutes = short.Parse(Console.ReadLine());

            Console.WriteLine("Введите число общих мест: ");
            DB[i].Number_Of_Shared_Seats = short.Parse(Console.ReadLine());

            Console.WriteLine("Введите число мест для купэ: ");
            DB[i].Number_Of_Seats_For_The_Compartment = short.Parse(Console.ReadLine());

            Console.WriteLine("Введите число мест для плацкарта: ");
            DB[i].Number_Of_Seats_For_The_Reserved_Seat = short.Parse(Console.ReadLine());

            Console.WriteLine("Введите число мест для люкса: ");
            DB[i].Number_Of_Seats_For_The_Suite = short.Parse(Console.ReadLine());


            Console.WriteLine();
        }

        //а) список поездов, следующих до заданного пункта назначения

        Console.WriteLine("Введите пункт назначения, чтобы узнать какие поезда до него едут: ");
            string checkMyDestination1 = Console.ReadLine();
            for (int j = 0; j<numberOfUsers; j++)
            {
                if (DB[j].Destination == checkMyDestination1)
                {
                    Console.WriteLine($"Поезд с номером '{DB[j].Train_Number}' прибывает в данный пункт назначения");
                }
}

Console.WriteLine();

//b) список поездов, следующих до заданного пункта назначения и отправляющихся после заданного часа
Console.WriteLine("Введите пункт назначения, чтобы узнать какие поезда до него едут и время(часы): ");
string checkMyDestination2 = Console.ReadLine();
short checkMyHours = short.Parse(Console.ReadLine());
for (int j = 0; j < numberOfUsers; j++)
{
    if ((DB[j].Destination == checkMyDestination2) && (DB[j].Departure_time_hours > checkMyHours))
    {
        Console.WriteLine($"Поезд с номером '{DB[j].Train_Number}' прибывает в данный пункт назначения и отправляется после заданного часа");
    }
}

Console.WriteLine();

//метод вывода общего числа мест в поезде
const int seats = Train.seats;
for (int j = 0; j < numberOfUsers; j++)
{
    Console.WriteLine($"Количество общих мест: {DB[j].Number_Of_Shared_Seats}");
}

Train train1 = new Train("Дзержинск", 53, 46, 256, 1111, 50, 20, 500);
Train train2 = new Train("Фаниполь", 76, 65, 34, 2222, 50, 20, 0);

Console.WriteLine(train1.GetHashCode());               //для алгоритма вычисления хэша руководствуйтесь стандартными рекомендациями
Console.WriteLine(train1.ToString());                  //вывода строки – информации об объекте
Console.WriteLine(train1.Equals(train2));             //для сравнения объектов

Console.WriteLine(train1.GetType());                   //проверьте тип созданного объекта

var user = new { Destination = "Пинск", Train_Number = 453, Number_Of_Shared_Seats = 1757 }; // анонимный тип = var + инициализатор объекта (создание объекта без определения класса)
Console.WriteLine($"Объект, созданный без определения класса(анонимный тип): {user.Destination} {user.Train_Number} с количеством общих мест {user.Number_Of_Shared_Seats}");

Console.ReadKey();

// ref и out

int number = 5;
            int numberx2 = 0;
            Console.WriteLine($"number - {number}");
            Console.WriteLine($"numberx2 - {numberx2}");
            ToDouble(ref number, out numberx2);
            Console.WriteLine($"number - {number}");
            Console.WriteLine($"numberx2 - {numberx2}");
            Console.WriteLine("Переопределение методов:");

            Train tr1 = new Train();
            tr1.text();
            Train2 tr2 = new Train2();
            tr2.text();

            Console.WriteLine($"nameOfCompany - {Train.NameOfCompany}");
            Train.NameOfCompany = "Renfe";
            Console.WriteLine($"nameOfCompany - {Train.NameOfCompany}");
        }
    }
}
