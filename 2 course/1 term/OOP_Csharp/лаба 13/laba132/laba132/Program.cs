using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace laba123
{
    class Program
    {
        static void Main()
        {
            // Выполните сериализацию/десериализацию объекта используя форматы:
            // a.Binary
            Rectangle rectangle1 = new Rectangle(20, 12, 5);
            Square square1 = new Square(50, 15, "cyan");

            BinaryFormatter binaryFormatter = new BinaryFormatter(); //создаём объект BinaryFormatter

            using (var file = new FileStream("rectangle.bin", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованный объект
            {
                binaryFormatter.Serialize(file, rectangle1);
                Console.WriteLine($"Объект rectangle1 сериализован через Binary формат");
            }

            using (var file = new FileStream("rectangle.bin", FileMode.OpenOrCreate))
            {
                Rectangle newRectangle = (Rectangle)binaryFormatter.Deserialize(file);
                Console.WriteLine($"Объект rectangle1 десериализован");
                Console.WriteLine($"Данные newRectangle:\nSquare: {newRectangle.SquareValue}, Perimeter: {newRectangle.Perimeter}, Border: {newRectangle.Border}");
            }


            // b.SOAP

            //SoapFormatter soapFormatter = new SoapFormatter(); //создаём объект SoapFormatter

            //using (var file = new FileStream("rectangle.soap", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованный объект
            //{
            //    soapFormatter.Serialize(file, rectangle1);
            //    Console.WriteLine($"Объект rectangle1 сериализован через SOAP формат");
            //}

            //using (var file = new FileStream("rectangle.soap", FileMode.OpenOrCreate))
            //{
            //    Rectangle newRectangle = (Rectangle)soapFormatter.Deserialize(file);
            //    Console.WriteLine($"Объект rectangle1 десериализован");
            //    Console.WriteLine($"Данные newRectangle:\nSquare: {newRectangle.SquareValue}, Perimeter: {newRectangle.Perimeter}, Border: {newRectangle.Border}");
            //}


            // с.JSON

            var jsonFormatter = new DataContractJsonSerializer(typeof(Square)); //создаём объект DataContractJsonSerializer

            using (var file = new FileStream("square.json", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованный объект
            {
                jsonFormatter.WriteObject(file, square1);
                Console.WriteLine($"\nОбъект rectangle1 сериализован через JSON формат");
            }

            using (var file = new FileStream("square.json", FileMode.OpenOrCreate))
            {
                Square newSquare = (Square)jsonFormatter.ReadObject(file);
                Console.WriteLine($"Объект rectangle1 десериализован");
                Console.WriteLine($"Данные newRectangle:\nSquare: {newSquare.SquareValue}, Perimeter: {newSquare.Perimeter}, Color: {newSquare.Color}");
            }


            // d.XML

            var xmlFormatter = new XmlSerializer(typeof(Rectangle)); //создаём объект XmlSerializer

            using (var file = new FileStream("rectangle.xml", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованный объект
            {
                xmlFormatter.Serialize(file, rectangle1);
                Console.WriteLine($"\nОбъект rectangle1 сериализован через XML формат");
            }

            using (var file = new FileStream("rectangle.xml", FileMode.OpenOrCreate))
            {
                Rectangle newRectangle = (Rectangle)xmlFormatter.Deserialize(file);
                Console.WriteLine($"Объект rectangle1 десериализован");
                Console.WriteLine($"Данные newRectangle:\nSquare: {newRectangle.SquareValue}, Perimeter: {newRectangle.Perimeter}, Border: {newRectangle.Border}");
            }


            // 2 Создайте коллекцию (массив) объектов и выполните сериализацию / десериализацию

            Square mySquare1 = new Square(11, 12, "black");
            Square mySquare2 = new Square(12, 13, "white");
            Square mySquare3 = new Square(13, 14, "aquamarin");

            List<Square> mySquareList = new List<Square>(3);
            mySquareList.Add(mySquare1);
            mySquareList.Add(mySquare2);
            mySquareList.Add(mySquare3);

            var jsonListFormatter = new DataContractJsonSerializer(typeof(List<Square>));

            using (var file = new FileStream("SquareList.json", FileMode.OpenOrCreate))
            {
                jsonListFormatter.WriteObject(file, mySquareList);
                Console.WriteLine("\nКоллекция сериализована через формат JSON");
            }

            using (var file = new FileStream("SquareList.json", FileMode.OpenOrCreate))
            {
                List<Square> newSquareList = jsonListFormatter.ReadObject(file) as List<Square>;
                if (newSquareList != null)
                {
                    Console.WriteLine("Элементы коллекции: ");
                    int i = 1;
                    foreach (var Square in newSquareList)
                    {
                        Console.WriteLine($"{i}. Название: {Square.SquareValue}, Цена: {Square.Perimeter}, Цвет: {Square.Color}");
                        i++;
                    }
                    Console.WriteLine("Коллекция десериализована");
                }
            }

            // 3 Используя XPath напишите два селектора для вашего XML документ
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"D:\Study\ООПиП(Экзамен)\лаба 13\laba132\laba132\bin\Debug\net6.0\rectangle.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            Console.WriteLine("\nВсе элементы, у которых значение тега SquareValue равно 20: ");
            XmlNode childnode = xRoot.SelectSingleNode("//Rectangle/SquareValue");         //Выберем узел, у которого вложенный элемент "SquareValue" имеет значение "20":
            if (childnode != null && Convert.ToInt32(childnode.InnerText) == 20)
                Console.WriteLine(childnode.OuterXml);
            else
                Console.WriteLine($"\nНе найден узел, у которого вложенный элемент 'SquareValue' имеет значение 10\n");

            XmlNodeList childnodes = xRoot.SelectNodes("//Rectangle/Border");                      //Для этого надо Осуществляем выборку вниз по иерархии элементов для получения начинок
            foreach (XmlNode n in childnodes)
                Console.WriteLine($"\nНайден объект по пути '//Rectangle/Border', его Ширина Обводки: {n.InnerText}");


            // 4 Используя Linq to XML (или Linq to JSON) создайте новый xml (json) - документ и напишите несколько запросов
            Console.WriteLine();
            XDocument xdoc = new XDocument(new XElement("dudes",
                new XElement("dude",
                new XAttribute("lastname", "Жиляк"),
                new XElement("firstname", "Надежда Александровна"),
                new XElement("old", "47")),
                new XElement("dude",
                new XAttribute("lastname", "Белодед"),
                new XElement("firstname", "Николай Иванович"),
                new XElement("old", "66")),
                new XElement("dude",
                new XAttribute("lastname", "Барковский"),
                new XElement("firstname", "Евгений Борисович"),
                new XElement("old", "32"))));
            xdoc.Save("dudes.xml");

            XDocument xdoc1 = XDocument.Load("dudes.xml");
            foreach (XElement childElement in xdoc1.Element("dudes").Elements("dude"))
            {
                XAttribute lastnameAttribute = childElement.Attribute("lastname");
                XElement firstnameElement = childElement.Element("firstname");
                XElement oldElement = childElement.Element("old");

                if (lastnameAttribute != null && firstnameElement != null && oldElement != null)
                {
                    Console.WriteLine($"Фамилия: {lastnameAttribute.Value}");
                    Console.WriteLine($"Имя: {firstnameElement.Value}");
                    Console.WriteLine($"Возраст: {oldElement.Value}");
                    Console.WriteLine();
                }
            }

            XDocument xdoc2 = XDocument.Load("dudes.xml");
            var items1 = from xel in xdoc2.Element("dudes").Elements("dude")
                         where xel.Element("firstname").Value == "Надежда Александровна"
                         select new Child
                         {
                             Lastname = xel.Attribute("lastname").Value,
                             Firstname = xel.Element("firstname").Value,
                             Old = xel.Element("old").Value
                         };
            foreach (var item in items1)
                Console.WriteLine($"{item.Firstname} {item.Lastname} ({item.Old} лет)");

            
            XDocument xdoc3 = XDocument.Load("dudes.xml");
            var items2 = from xel in xdoc2.Element("dudes").Elements("dude")
                         where xel.Element("old").Value == "32"
                         select new Child
                         {
                             Lastname = xel.Attribute("lastname").Value,
                             Firstname = xel.Element("firstname").Value,
                             Old = xel.Element("old").Value
                         };
            foreach (var item in items2)
                Console.WriteLine($"{item.Firstname} {item.Lastname} ({item.Old} лет)");

            XDocument xdoc4 = XDocument.Load("dudes.xml");
            var items3 = from xel in xdoc4.Element("dudes").Elements("dude")
                         where xel.Attribute("lastname").Value == "Белодед"
                         select new Child
                         {
                             Lastname = xel.Attribute("lastname").Value,
                             Firstname = xel.Element("firstname").Value,
                             Old = xel.Element("old").Value
                         };
            foreach (var item in items3)
                Console.WriteLine($"{item.Firstname} {item.Lastname} ({item.Old} лет)");
        }
    }
}
