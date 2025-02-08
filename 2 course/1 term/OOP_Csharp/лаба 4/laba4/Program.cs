using laba4;

namespace laba4
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            //11 вариант - Автомобиль, Поезд, Транспортное средство, Экспресс, Двигатель, Вагон
            Car car1 = new Car();
            Express expressTrain = new Express();
            IEngine engine = new IEngine();
            Vagon vagon = new Vagon();



            car1.Move();
            Console.WriteLine("----");

            expressTrain.ExpressOrNot();
            expressTrain.Move();
            Console.WriteLine("----");

            engine.Work();
            Console.WriteLine("----");

            vagon.Move();
            Console.WriteLine("----");


            //5
            Train train1 = new Train();

            Console.WriteLine($"Поезд экспресс? - {train1 is Express}");
            Express? expressTrain1 = train1 as Express;
            if (expressTrain1 == null)
            {
                Console.WriteLine("Неудачно!");
            }
            car1.ToString();
            expressTrain.ToString();

            //7
            var printer = new Printer();
            Transport[] transports = new Transport[3];
            transports[0] = train1;
            transports[1] = car1;
            transports[2] = expressTrain;

            foreach (Transport item in transports)
            {
                printer.IAmPrinting(item);
            }


            var man1 = new Man();

            man1.Move();
            ((ITransportMove)man1).Move();

            man1.ToString();
            ((ITransportMove)man1).ToString();

        }
    }
}


//композиция, костр в аб кл, методы в интерфейсе, одноименные методы
