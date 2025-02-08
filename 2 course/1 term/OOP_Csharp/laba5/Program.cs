using laba5;

namespace laba5
{
    internal partial class Program
    {

        static void Main(string[] args)
        {
            //11 вариант - Автомобиль, Поезд, Транспортное средство, Экспресс, Двигатель, Вагон

            Car car1 = new Car();
            Express expressTrain = new Express();
            IEngine engine = new IEngine();
            Vagon vagon = new Vagon();
            Car[] cars = new Car[5];
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = new Car();
            }
            Train[] trains = new Train[5];
            for (int i = 0; i < trains.Length; i++)
            {
                trains[i] = new Train();
            }

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
            //carsConsume(ref cars);
            Controller.sort(ref cars);
            Controller.CW();
            Container container = new Container();

            for (int i = 0; i < cars.Length; i++)
            {
                Controller.Adder(ref cars[i], ref container);
            }
            for (int i = 0; i < cars.Length; i++)
            {
                Controller.Adder(ref trains[i], ref container);
            }
            Controller.findbySpeed(12, 1000, ref container);
       
        }
    }
}


